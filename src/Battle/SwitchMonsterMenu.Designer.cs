using System.ComponentModel;

namespace MonsterDuel;

partial class SwitchMonsterMenu
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
        this.SuspendLayout();
        // 
        // SwitchMonsterMenu
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Location = new System.Drawing.Point(680, 360);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "SwitchMonsterMenu";
        this.Size = new System.Drawing.Size(600, 360);
        this.ResumeLayout(false);
        this.VisibleChanged += new System.EventHandler(this.SwitchMonsterMenu_VisibleChanged);
    }

    #endregion
}