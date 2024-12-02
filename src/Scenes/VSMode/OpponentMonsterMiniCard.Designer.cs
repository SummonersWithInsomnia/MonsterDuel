using System.ComponentModel;

namespace MonsterDuel;

partial class OpponentMonsterMiniCard
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
        this.pbMonsterIcon = new System.Windows.Forms.PictureBox();
        this.lbMonsterName = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pbMonsterIcon)).BeginInit();
        this.SuspendLayout();
        // 
        // pbMonsterIcon
        // 
        this.pbMonsterIcon.Location = new System.Drawing.Point(10, 10);
        this.pbMonsterIcon.Margin = new System.Windows.Forms.Padding(0);
        this.pbMonsterIcon.Name = "pbMonsterIcon";
        this.pbMonsterIcon.Size = new System.Drawing.Size(60, 60);
        this.pbMonsterIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pbMonsterIcon.TabIndex = 0;
        this.pbMonsterIcon.TabStop = false;
        // 
        // lbMonsterName
        // 
        this.lbMonsterName.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbMonsterName.ForeColor = System.Drawing.Color.White;
        this.lbMonsterName.Location = new System.Drawing.Point(70, 10);
        this.lbMonsterName.Margin = new System.Windows.Forms.Padding(0);
        this.lbMonsterName.Name = "lbMonsterName";
        this.lbMonsterName.Size = new System.Drawing.Size(132, 60);
        this.lbMonsterName.TabIndex = 1;
        this.lbMonsterName.Text = "Monster Name";
        this.lbMonsterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // OpponentMonsterMiniCard
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbMonsterName);
        this.Controls.Add(this.pbMonsterIcon);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "OpponentMonsterMiniCard";
        this.Size = new System.Drawing.Size(212, 80);
        ((System.ComponentModel.ISupportInitialize)(this.pbMonsterIcon)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbMonsterName;

    private System.Windows.Forms.PictureBox pbMonsterIcon;

    #endregion
}