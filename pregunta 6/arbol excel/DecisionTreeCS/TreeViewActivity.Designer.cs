﻿
namespace DecisionTreeCS {
  partial class TreeViewActivity {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewActivity));
      this.treeView = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // treeView
      // 
      this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.Location = new System.Drawing.Point(0, 0);
      this.treeView.Name = "treeView";
      this.treeView.Size = new System.Drawing.Size(384, 261);
      this.treeView.TabIndex = 0;
      // 
      // TreeViewActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(384, 261);
      this.Controls.Add(this.treeView);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(400, 300);
      this.Name = "TreeViewActivity";
      this.Text = "Representación del árbol de decision generado";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView;
  }
}