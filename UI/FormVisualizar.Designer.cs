namespace GeraScript
{
  partial class FormVisualizar
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnSair = new System.Windows.Forms.Button();
      this.fontDialog1 = new System.Windows.Forms.FontDialog();
      this.txtVisualizaScript = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnSair
      // 
      this.btnSair.Location = new System.Drawing.Point(713, 418);
      this.btnSair.Name = "btnSair";
      this.btnSair.Size = new System.Drawing.Size(75, 23);
      this.btnSair.TabIndex = 1;
      this.btnSair.Text = "Sair";
      this.btnSair.UseVisualStyleBackColor = true;
      this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
      // 
      // txtVisualizaScript
      // 
      this.txtVisualizaScript.Location = new System.Drawing.Point(13, 13);
      this.txtVisualizaScript.Multiline = true;
      this.txtVisualizaScript.Name = "txtVisualizaScript";
      this.txtVisualizaScript.ReadOnly = true;
      this.txtVisualizaScript.Size = new System.Drawing.Size(775, 390);
      this.txtVisualizaScript.TabIndex = 2;
      this.txtVisualizaScript.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // FormVisualizar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.txtVisualizaScript);
      this.Controls.Add(this.btnSair);
      this.Name = "FormVisualizar";
      this.Text = "FormVisualizar";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button btnSair;
    private System.Windows.Forms.FontDialog fontDialog1;
    private System.Windows.Forms.TextBox txtVisualizaScript;
  }
}