
namespace DecisionTreeCS {
  partial class MainActivity {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainActivity));
      this.fileSelectBtn = new System.Windows.Forms.Button();
      this.csvFileLoader = new System.Windows.Forms.OpenFileDialog();
      this.fileNameLabel = new System.Windows.Forms.Label();
      this.useHeaderCheckbox = new System.Windows.Forms.CheckBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.startTrainingBtn = new System.Windows.Forms.Button();
      this.showTreeBtn = new System.Windows.Forms.Button();
      this.predictionsBtn = new System.Windows.Forms.Button();
      this.fieldsPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // fileSelectBtn
      // 
      this.fileSelectBtn.Location = new System.Drawing.Point(8, 8);
      this.fileSelectBtn.Name = "fileSelectBtn";
      this.fileSelectBtn.Size = new System.Drawing.Size(119, 23);
      this.fileSelectBtn.TabIndex = 0;
      this.fileSelectBtn.Text = "Seleccionar dataset";
      this.fileSelectBtn.UseVisualStyleBackColor = true;
      this.fileSelectBtn.Click += new System.EventHandler(this.fileSelectBtn_Click);
      // 
      // csvFileLoader
      // 
      this.csvFileLoader.Filter = "Archivo CSV|*.csv";
      this.csvFileLoader.ReadOnlyChecked = true;
      // 
      // fileNameLabel
      // 
      this.fileNameLabel.AutoSize = true;
      this.fileNameLabel.Location = new System.Drawing.Point(204, 41);
      this.fileNameLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
      this.fileNameLabel.Name = "fileNameLabel";
      this.fileNameLabel.Size = new System.Drawing.Size(75, 13);
      this.fileNameLabel.TabIndex = 1;
      this.fileNameLabel.Text = "Seleccionado:";
      // 
      // useHeaderCheckbox
      // 
      this.useHeaderCheckbox.AutoSize = true;
      this.useHeaderCheckbox.Enabled = false;
      this.useHeaderCheckbox.Location = new System.Drawing.Point(9, 40);
      this.useHeaderCheckbox.Margin = new System.Windows.Forms.Padding(4, 6, 3, 3);
      this.useHeaderCheckbox.Name = "useHeaderCheckbox";
      this.useHeaderCheckbox.Size = new System.Drawing.Size(189, 17);
      this.useHeaderCheckbox.TabIndex = 2;
      this.useHeaderCheckbox.Text = "Usar primera línea como cabecera";
      this.useHeaderCheckbox.UseVisualStyleBackColor = true;
      this.useHeaderCheckbox.CheckedChanged += new System.EventHandler(this.useHeaderCheckbox_CheckedChanged);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.fieldsPanel, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 361);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.fileSelectBtn);
      this.flowLayoutPanel1.Controls.Add(this.startTrainingBtn);
      this.flowLayoutPanel1.Controls.Add(this.showTreeBtn);
      this.flowLayoutPanel1.Controls.Add(this.predictionsBtn);
      this.flowLayoutPanel1.Controls.Add(this.useHeaderCheckbox);
      this.flowLayoutPanel1.Controls.Add(this.fileNameLabel);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
      this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 65);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // startTrainingBtn
      // 
      this.startTrainingBtn.Enabled = false;
      this.startTrainingBtn.Location = new System.Drawing.Point(133, 8);
      this.startTrainingBtn.Name = "startTrainingBtn";
      this.startTrainingBtn.Size = new System.Drawing.Size(119, 23);
      this.startTrainingBtn.TabIndex = 3;
      this.startTrainingBtn.Text = "Iniciar entrenamiento";
      this.startTrainingBtn.UseVisualStyleBackColor = true;
      this.startTrainingBtn.Click += new System.EventHandler(this.startTrainingBtn_Click);
      // 
      // showTreeBtn
      // 
      this.showTreeBtn.Enabled = false;
      this.showTreeBtn.Location = new System.Drawing.Point(258, 8);
      this.showTreeBtn.Name = "showTreeBtn";
      this.showTreeBtn.Size = new System.Drawing.Size(119, 23);
      this.showTreeBtn.TabIndex = 4;
      this.showTreeBtn.Text = "Ver árbol de decision";
      this.showTreeBtn.UseVisualStyleBackColor = true;
      this.showTreeBtn.Click += new System.EventHandler(this.showTreeBtn_Click);
      // 
      // predictionsBtn
      // 
      this.predictionsBtn.Enabled = false;
      this.flowLayoutPanel1.SetFlowBreak(this.predictionsBtn, true);
      this.predictionsBtn.Location = new System.Drawing.Point(383, 8);
      this.predictionsBtn.Name = "predictionsBtn";
      this.predictionsBtn.Size = new System.Drawing.Size(120, 23);
      this.predictionsBtn.TabIndex = 5;
      this.predictionsBtn.Text = "Generar predicciones";
      this.predictionsBtn.UseVisualStyleBackColor = true;
      this.predictionsBtn.Click += new System.EventHandler(this.predictionsBtn_Click);
      // 
      // fieldsPanel
      // 
      this.fieldsPanel.AutoScroll = true;
      this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fieldsPanel.Location = new System.Drawing.Point(3, 74);
      this.fieldsPanel.Name = "fieldsPanel";
      this.fieldsPanel.Padding = new System.Windows.Forms.Padding(5);
      this.fieldsPanel.Size = new System.Drawing.Size(578, 284);
      this.fieldsPanel.TabIndex = 1;
      // 
      // MainActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(584, 361);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(600, 400);
      this.Name = "MainActivity";
      this.Text = "Árbol de Decisión";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button fileSelectBtn;
    private System.Windows.Forms.OpenFileDialog csvFileLoader;
    private System.Windows.Forms.Label fileNameLabel;
    private System.Windows.Forms.CheckBox useHeaderCheckbox;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button startTrainingBtn;
    private System.Windows.Forms.FlowLayoutPanel fieldsPanel;
    private System.Windows.Forms.Button showTreeBtn;
    private System.Windows.Forms.Button predictionsBtn;
  }
}