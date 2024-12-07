using System.ComponentModel;

namespace MonsterDuel;

partial class PlayerWithShadow
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
        this.pbShadow = new System.Windows.Forms.PictureBox();
        this.pbPlayer = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pbShadow)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
        this.SuspendLayout();
        // 
        // pbShadow
        // 
        this.pbShadow.Location = new System.Drawing.Point(0, 1486);
        this.pbShadow.Margin = new System.Windows.Forms.Padding(0);
        this.pbShadow.Name = "pbShadow";
        this.pbShadow.Size = new System.Drawing.Size(1024, 100);
        this.pbShadow.TabIndex = 0;
        this.pbShadow.TabStop = false;
        // 
        // pbPlayer
        // 
        this.pbPlayer.Location = new System.Drawing.Point(0, 0);
        this.pbPlayer.Margin = new System.Windows.Forms.Padding(0);
        this.pbPlayer.Name = "pbPlayer";
        this.pbPlayer.Size = new System.Drawing.Size(1024, 1536);
        this.pbPlayer.TabIndex = 1;
        this.pbPlayer.TabStop = false;
        // 
        // PlayerWithShadow
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.pbPlayer);
        this.Controls.Add(this.pbShadow);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "PlayerWithShadow";
        this.Size = new System.Drawing.Size(1024, 1586);
        ((System.ComponentModel.ISupportInitialize)(this.pbShadow)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pbPlayer;

    private System.Windows.Forms.PictureBox pbShadow;

    #endregion
}