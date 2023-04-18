
namespace DecisionTreeCS {
  partial class PredictionActivity {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredictionActivity));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.fieldsPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.predictionBtn = new System.Windows.Forms.Button();
      this.resultLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.fieldsPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Controls.Add(this.fieldsPanel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.predictionBtn, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.resultLabel, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 361);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // fieldsPanel
      // 
      this.fieldsPanel.AutoSize = true;
      this.fieldsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.fieldsPanel.Controls.Add(this.label1);
      this.fieldsPanel.Controls.Add(this.comboBox1);
      this.fieldsPanel.Controls.Add(this.label2);
      this.fieldsPanel.Controls.Add(this.numericUpDown1);
      this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fieldsPanel.Location = new System.Drawing.Point(3, 3);
      this.fieldsPanel.Name = "fieldsPanel";
      this.fieldsPanel.Size = new System.Drawing.Size(478, 53);
      this.fieldsPanel.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 7);
      this.label1.Margin = new System.Windows.Forms.Padding(7, 7, 3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Categórico";
      // 
      // comboBox1
      // 
      this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
      this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.fieldsPanel.SetFlowBreak(this.comboBox1, true);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(78, 3);
      this.comboBox1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 34);
      this.label2.Margin = new System.Windows.Forms.Padding(7, 7, 3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Numérico";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.DecimalPlaces = 2;
      this.numericUpDown1.Location = new System.Drawing.Point(72, 30);
      this.numericUpDown1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
      this.numericUpDown1.TabIndex = 3;
      // 
      // predictionBtn
      // 
      this.predictionBtn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.predictionBtn.Enabled = false;
      this.predictionBtn.Location = new System.Drawing.Point(10, 62);
      this.predictionBtn.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
      this.predictionBtn.Name = "predictionBtn";
      this.predictionBtn.Size = new System.Drawing.Size(464, 23);
      this.predictionBtn.TabIndex = 1;
      this.predictionBtn.Text = "Generar predicción";
      this.predictionBtn.UseVisualStyleBackColor = true;
      this.predictionBtn.Click += new System.EventHandler(this.predictionBtn_Click);
      // 
      // resultLabel
      // 
      this.resultLabel.AutoSize = true;
      this.resultLabel.Location = new System.Drawing.Point(10, 95);
      this.resultLabel.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
      this.resultLabel.Name = "resultLabel";
      this.resultLabel.Size = new System.Drawing.Size(195, 13);
      this.resultLabel.TabIndex = 5;
      this.resultLabel.Text = "Predicción en base al árbol de decisión:";
      // 
      // PredictionActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 361);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(400, 400);
      this.Name = "PredictionActivity";
      this.Text = "Generación de predicciones";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.fieldsPanel.ResumeLayout(false);
      this.fieldsPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel fieldsPanel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Button predictionBtn;
    private System.Windows.Forms.Label resultLabel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
  }
}