using System.ComponentModel;

namespace MonsterDuel;

partial class PlayerImageCard
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
        this.pbPlayerImage = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).BeginInit();
        this.SuspendLayout();
        // 
        // pbPlayerImage
        // 
        this.pbPlayerImage.Location = new System.Drawing.Point(10, 10);
        this.pbPlayerImage.Margin = new System.Windows.Forms.Padding(0);
        this.pbPlayerImage.Name = "pbPlayerImage";
        this.pbPlayerImage.Size = new System.Drawing.Size(265, 550);
        this.pbPlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pbPlayerImage.TabIndex = 0;
        this.pbPlayerImage.TabStop = false;
        this.pbPlayerImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerImageCard_MouseDown);
        this.pbPlayerImage.MouseEnter += new System.EventHandler(this.PlayerImageCard_MouseEnter);
        this.pbPlayerImage.MouseLeave += new System.EventHandler(this.PlayerImageCard_MouseLeave);
        // 
        // PlayerImageCard
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.pbPlayerImage);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "PlayerImageCard";
        this.Size = new System.Drawing.Size(285, 570);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerImageCard_MouseDown);
        this.MouseEnter += new System.EventHandler(this.PlayerImageCard_MouseEnter);
        this.MouseLeave += new System.EventHandler(this.PlayerImageCard_MouseLeave);
        ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pbPlayerImage;

    #endregion
}