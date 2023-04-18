using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace DecisionTreeCS {
  public partial class MainActivity : Form {
    DecisionTree tree;
    Dataset trainingData;
    string csvFilePath;
    PredictionActivity predictionActivity;

    public MainActivity() {
      InitializeComponent();
      tree = null;
      trainingData = null;
      csvFilePath = string.Empty;
    }

    private void fileSelectBtn_Click(object sender, EventArgs e) {
      if (csvFileLoader.ShowDialog() == DialogResult.OK) {
        // Force disable the CheckBox
        useHeaderCheckbox.Enabled = false;
        useHeaderCheckbox.Checked = false;

        // Force disable Buttons
        startTrainingBtn.Enabled = false;
        showTreeBtn.Enabled = false;
        predictionsBtn.Enabled = false;

        // Clear any previous training data
        tree = null;
        trainingData = new Dataset();

        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) {
          HasHeaderRecord = false
        };

        // Wrap all this code in a try-catch block to catch parsing errors
        try {
          // Read the contents of the file into a stream
          using (Stream fileStream = csvFileLoader.OpenFile())
          using (StreamReader reader = new StreamReader(fileStream))
          using (CsvReader csv = new CsvReader(reader, config)) {
            int maxFeatureCount = 0;
            // Read every line individually
            while (csv.Read()) {
              // Parse the current record
              var record = csv.GetRecord<dynamic>();
              Row featureRow = Row.ParseFromCsv(record);
              if (featureRow != null) {
                trainingData.Add(featureRow);
                if (featureRow.Count > maxFeatureCount)
                  maxFeatureCount = featureRow.Count;
              }
            }
            // Add default headers
            for (int i = 0; i < maxFeatureCount; ++i) {
              string header = $"Field{i + 1}";
              trainingData.Headers.Add(header);
            }
          }

          // Get the path of the specified file
          csvFilePath = csvFileLoader.SafeFileName;
          fileNameLabel.Text = $"Seleccionado: {csvFilePath}";

          // Display the fields in the UI
          CreateFieldsFromDataset(fieldsPanel, trainingData);

          // Reset the CheckBox state to enabled
          useHeaderCheckbox.Enabled = true;
          // Re-enable the training button
          startTrainingBtn.Enabled = true;
        } catch (Exception) {
          // This will catch any type of Exception (for now)
          // Clear any fields that were added
          fieldsPanel.Controls.Clear();
          // Clear any changes made to trainingData
          trainingData.Clear();
          // Inform the user parsing has failed
          string title = "¡Uh-oh!";
          string message =
            "Ha sucedido un problema al intentar leer el archivo CSV. Revisa que este tenga una sintaxis válida.";
          _ = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void startTrainingBtn_Click(object sender, EventArgs e) {
      // Disable the show tree button
      startTrainingBtn.Enabled = false;
      fileSelectBtn.Enabled = false;
      predictionsBtn.Enabled = false;
      showTreeBtn.Enabled = false;
      // Start training in a new tree
      tree = new DecisionTree();
      tree.Fit(trainingData);
      // Re-enable the show tree button
      showTreeBtn.Enabled = true;
      predictionsBtn.Enabled = true;
      fileSelectBtn.Enabled = true;
      startTrainingBtn.Enabled = true;
    }

    private void predictionsBtn_Click(object sender, EventArgs e) {
      // Disable buttons
      startTrainingBtn.Enabled = false;
      fileSelectBtn.Enabled = false;
      predictionsBtn.Enabled = false;

      // Create the form and show it
      predictionActivity = new PredictionActivity(tree, predictionActivity_Closing);
      predictionActivity.Show();
    }

    private void predictionActivity_Closing(object sender, FormClosingEventArgs e) {
      predictionActivity = null;
      // Re-enable buttons when the other form is closed
      startTrainingBtn.Enabled = true;
      fileSelectBtn.Enabled = true;
      predictionsBtn.Enabled = true;
      // Re-focus the main window for the user to see it
      _ = Focus();
    }

    private void showTreeBtn_Click(object sender, EventArgs e) {
      if (tree != null) {
        using (TreeViewActivity form = new TreeViewActivity(tree)) {
          _ = form.ShowDialog();
        }
      }
    }

    private void useHeaderCheckbox_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = sender as CheckBox;
      if (checkBox.Checked && trainingData != null) {
        // Convert the first row to a header
        if (trainingData.ConvertFirstRowToHeader()) {
          // Update the UI
          CreateFieldsFromDataset(fieldsPanel, trainingData);
          checkBox.Enabled = false;
        }
      }
    }

    private static void CreateFieldsFromDataset(FlowLayoutPanel panel, Dataset dataset) {
      // Prevent running if dataset is null
      if (dataset == null)
        return;

      // Suspend the layout to prevent re-renders
      panel.SuspendLayout();
      // Clear the panel before removing any previous text box
      panel.Controls.Clear();

      // Initialize the List in which we'll save every control to add
      List<Control> controls = new List<Control>();

      // Create every text box for each header
      for (int i = 0; i < dataset.Headers.Count; ++i) {
        // Save a copy of the current index and the label text
        int staticIndex = i;
        string header = dataset.Headers[i];
        // Create the TextBox and assign its value
        TextBox textBox = new TextBox();
        textBox.Text = header;
        textBox.MaxLength = 30;
        // Create the event handler
        textBox.TextChanged += new EventHandler((object sender, EventArgs e) => {
          TextBox senderTextBox = sender as TextBox;
          dataset.Headers[staticIndex] = senderTextBox.Text;
        });
        // Add it to the controls List
        controls.Add(textBox);
      }

      // Set the last item of the Controls to break the flow
      panel.SetFlowBreak(controls[controls.Count - 1], true);

      foreach (Row row in dataset) {
        // Initialize an empty List of Labels
        List<Label> labels = new List<Label>();
        // Iterate over each feature
        foreach (Feature feature in row) {
          // Create the Label and assign its value
          Label label = new Label();
          label.Text = feature.ToString();
          // Add to the local Label list
          labels.Add(label);
        }
        // Set the last item of the Controls to break the flow
        panel.SetFlowBreak(labels[labels.Count - 1], true);
        // Add every label in this iteration to the List
        controls.AddRange(labels);
      }

      // Display every new control in the UI
      panel.Controls.AddRange(controls.ToArray());

      // Re-render panels
      panel.ResumeLayout(false);
      panel.PerformLayout();
    }
  }
}
