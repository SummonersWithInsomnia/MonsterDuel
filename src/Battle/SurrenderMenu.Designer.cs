using System.ComponentModel;

namespace MonsterDuel;

partial class SurrenderMenu
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
        this.lbTitle = new System.Windows.Forms.Label();
        this.lbYes = new System.Windows.Forms.Label();
        this.lbNo = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lbTitle
        // 
        this.lbTitle.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbTitle.ForeColor = System.Drawing.Color.White;
        this.lbTitle.Location = new System.Drawing.Point(0, 0);
        this.lbTitle.Margin = new System.Windows.Forms.Padding(0);
        this.lbTitle.Name = "lbTitle";
        this.lbTitle.Size = new System.Drawing.Size(600, 100);
        this.lbTitle.TabIndex = 0;
        this.lbTitle.Text = "Surrender?";
        this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbYes
        // 
        this.lbYes.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbYes.ForeColor = System.Drawing.Color.White;
        this.lbYes.Location = new System.Drawing.Point(0, 100);
        this.lbYes.Margin = new System.Windows.Forms.Padding(0);
        this.lbYes.Name = "lbYes";
        this.lbYes.Size = new System.Drawing.Size(300, 100);
        this.lbYes.TabIndex = 1;
        this.lbYes.Text = "Yes";
        this.lbYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbNo
        // 
        this.lbNo.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbNo.ForeColor = System.Drawing.Color.White;
        this.lbNo.Location = new System.Drawing.Point(300, 100);
        this.lbNo.Margin = new System.Windows.Forms.Padding(0);
        this.lbNo.Name = "lbNo";
        this.lbNo.Size = new System.Drawing.Size(300, 100);
        this.lbNo.TabIndex = 2;
        this.lbNo.Text = "No";
        this.lbNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SurrenderMenu
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbNo);
        this.Controls.Add(this.lbYes);
        this.Controls.Add(this.lbTitle);
        this.Location = new System.Drawing.Point(680, 520);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "SurrenderMenu";
        this.Size = new System.Drawing.Size(600, 200);
        this.VisibleChanged += new System.EventHandler(this.SurrenderMenu_VisibleChanged);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbNo;

    private System.Windows.Forms.Label lbTitle;

    private System.Windows.Forms.Label lbYes;

    #endregion
}