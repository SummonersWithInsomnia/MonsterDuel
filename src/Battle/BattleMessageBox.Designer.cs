using System.ComponentModel;

namespace MonsterDuel;

partial class BattleMessageBox
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.lbText = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lbText
        // 
        this.lbText.BackColor = System.Drawing.Color.Transparent;
        this.lbText.Font = new System.Drawing.Font("Courier New", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbText.ForeColor = System.Drawing.Color.Black;
        this.lbText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lbText.Location = new System.Drawing.Point(30, 30);
        this.lbText.Margin = new System.Windows.Forms.Padding(0);
        this.lbText.Name = "lbText";
        this.lbText.Size = new System.Drawing.Size(1220, 140);
        this.lbText.TabIndex = 1;
        this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lbText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Next);
        // 
        // BattleMessageBox
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbText);
        this.DoubleBuffered = true;
        this.Location = new System.Drawing.Point(0, 520);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "BattleMessageBox";
        this.Size = new System.Drawing.Size(1280, 200);
        this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Next);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbText;
    
    #endregion
}