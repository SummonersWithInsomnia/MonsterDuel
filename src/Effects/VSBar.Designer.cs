using System.ComponentModel;

namespace MonsterDuel;

partial class VSBar
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
        this.lbLeftPlayerName = new System.Windows.Forms.Label();
        this.lbRightPlayerName = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lbLeftPlayerName
        // 
        this.lbLeftPlayerName.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbLeftPlayerName.ForeColor = System.Drawing.Color.White;
        this.lbLeftPlayerName.Location = new System.Drawing.Point(0, 260);
        this.lbLeftPlayerName.Margin = new System.Windows.Forms.Padding(0);
        this.lbLeftPlayerName.Name = "lbLeftPlayerName";
        this.lbLeftPlayerName.Size = new System.Drawing.Size(620, 40);
        this.lbLeftPlayerName.TabIndex = 0;
        this.lbLeftPlayerName.Text = "Left Player Name";
        this.lbLeftPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbRightPlayerName
        // 
        this.lbRightPlayerName.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbRightPlayerName.ForeColor = System.Drawing.Color.White;
        this.lbRightPlayerName.Location = new System.Drawing.Point(660, 260);
        this.lbRightPlayerName.Margin = new System.Windows.Forms.Padding(0);
        this.lbRightPlayerName.Name = "lbRightPlayerName";
        this.lbRightPlayerName.Size = new System.Drawing.Size(620, 40);
        this.lbRightPlayerName.TabIndex = 1;
        this.lbRightPlayerName.Text = "Right Player Name";
        this.lbRightPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // VSBar
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbRightPlayerName);
        this.Controls.Add(this.lbLeftPlayerName);
        this.Location = new System.Drawing.Point(0, 210);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "VSBar";
        this.Size = new System.Drawing.Size(1280, 300);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbRightPlayerName;

    private System.Windows.Forms.Label lbLeftPlayerName;

    #endregion
}