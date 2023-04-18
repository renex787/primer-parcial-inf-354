using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DecisionTreeCS {
  partial class PredictionActivity : Form {
    readonly DecisionTree tree = null;
    Row features = null;

    public PredictionActivity(DecisionTree tree, Action<object, FormClosingEventArgs> closingHandler = null) {
      InitializeComponent();
      // Set the Closing event handler
      if (closingHandler != null)
        FormClosing += new FormClosingEventHandler(closingHandler);
      // Save the tree to a local field
      this.tree = tree;
      // Render the new fields based on the dataset
      CreateFieldsFromDataset();
    }

    private void predictionBtn_Click(object sender, EventArgs e) {
      if (features != null && features.All(item => item != null)) {
        DecisionNode node = tree.Predict(features);
        resultLabel.Text = PredictionToString(node);      
      }
    }

    private static string PredictionToString(DecisionNode node) {
      Dictionary<string, int> predictions = node.predictions;
      double total = predictions.Aggregate(0.0, (acc, x) => acc + x.Value);
      string str = "Predicción en base al árbol de decisión:\n";
      int index = 1;
      foreach (KeyValuePair<string, int> elem in predictions) {
        int percent = (int)Math.Round(elem.Value / total * 100, 0);
        string key = elem.Key.FirstCharToUpper();
        if (predictions.Count == 1) {
          str += $"{key} (Nivel de certeza: {percent}%)\n";
        } else {
          str += $"Respuesta {index}: {key} (Nivel de certeza: {percent}%)\n";
        }
        ++index;
      }
      return str;
    }

    private void CreateFieldsFromDataset() {
      // Prevent running if we don't have a tree to analyze
      if (tree == null)
        return;

      FlowLayoutPanel panel = fieldsPanel;
      Dataset dataset = tree.Dataset;
      features = new Row(Enumerable.Repeat<Feature>(null, tree.Dataset.MaxFeatureCount).ToList());

      // Suspend the layout to prevent re-renders
      panel.SuspendLayout();
      // Clear the panel before removing any previous text box
      panel.Controls.Clear();

      // Initialize the List in which we'll save every control to add
      List<Control> controls = new List<Control>();

      int totalFeatures = dataset.MaxFeatureCount;
      // Create a field for each feature
      for (int i = 0; i < totalFeatures; ++i) {
        int staticIndex = i;

        // Create the Label for this field
        Label label = new Label();
        label.Text = dataset.Headers[i].FirstCharToUpper();
        label.Margin = new Padding(7, 7, 3, 0);
        label.AutoSize = true;
        controls.Add(label);

        // We need different Control types for categorical and numeric features
        if (dataset.IsNumeric(i)) {
          // Create a NumericUpDown for numeric features
          NumericUpDown numericUpDown = new NumericUpDown();
          numericUpDown.Minimum = decimal.MinValue;
          numericUpDown.Maximum = decimal.MaxValue;
          numericUpDown.DecimalPlaces = 2;
          numericUpDown.TabStop = true;
          numericUpDown.TabIndex = 0;
          numericUpDown.Margin = new Padding(10, 3, 3, 3);
          // Initialize this feature in 0
          features[i] = new Feature(0);
          // Set the Event Handler
          numericUpDown.ValueChanged += new EventHandler((object sender, EventArgs e) => {
            NumericUpDown control = sender as NumericUpDown;
            if (features != null)
              features[staticIndex] = new Feature(control.Value);
            predictionBtn.Enabled = IsValidPredictionRow(features);
          });
          panel.SetFlowBreak(numericUpDown, true);
          controls.Add(numericUpDown);
        } else {
          // Create the ComboBox for categoric features
          ComboBox comboBox = new ComboBox();
          comboBox.AutoCompleteMode = AutoCompleteMode.Append;
          comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
          comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
          comboBox.FormattingEnabled = true;
          comboBox.TabStop = true;
          comboBox.TabIndex = 0;
          comboBox.Margin = new Padding(10, 3, 3, 3);
          // Set the Event Handler
          comboBox.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => {
            ComboBox control = sender as ComboBox;
            if (features != null && control.SelectedItem != null)
              features[staticIndex] = new Feature(control.SelectedItem.ToString());
            predictionBtn.Enabled = IsValidPredictionRow(features);
          });
          // Get all the unique values for this ComboBox
          HashSet<Feature> uniqueFeatures = dataset.GetUniqueValues(i);
          string[] values = uniqueFeatures.Select(item => item.ToString()).ToArray();
          comboBox.Items.AddRange(values);
          panel.SetFlowBreak(comboBox, true);
          controls.Add(comboBox);        
        }
      }

      // Assign the Enabled property for the Button with the current Row
      predictionBtn.Enabled = IsValidPredictionRow(features);

      // Display every new control in the UI
      panel.Controls.AddRange(controls.ToArray());

      // Re-render panels
      panel.ResumeLayout(false);
      panel.PerformLayout();
    }

    private static bool IsValidPredictionRow(Row row) =>
      row != null && row.All(item => item != null);
  }
}
