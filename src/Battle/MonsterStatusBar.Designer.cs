using System.ComponentModel;

namespace MonsterDuel;

partial class MonsterStatusBar
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
        this.lbName = new System.Windows.Forms.Label();
        this.lbHPValue = new System.Windows.Forms.Label();
        this.lbLeft = new System.Windows.Forms.Label();
        this.lbRight = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lbName
        // 
        this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbName.ForeColor = System.Drawing.Color.White;
        this.lbName.Location = new System.Drawing.Point(0, 0);
        this.lbName.Margin = new System.Windows.Forms.Padding(0);
        this.lbName.Name = "lbName";
        this.lbName.Size = new System.Drawing.Size(250, 50);
        this.lbName.TabIndex = 0;
        this.lbName.Text = "Monster Name";
        this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbHPValue
        // 
        this.lbHPValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbHPValue.ForeColor = System.Drawing.Color.White;
        this.lbHPValue.Location = new System.Drawing.Point(250, 0);
        this.lbHPValue.Margin = new System.Windows.Forms.Padding(0);
        this.lbHPValue.Name = "lbHPValue";
        this.lbHPValue.Size = new System.Drawing.Size(250, 50);
        this.lbHPValue.TabIndex = 1;
        this.lbHPValue.Text = "1000 / 1000";
        this.lbHPValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbLeft
        // 
        this.lbLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbLeft.ForeColor = System.Drawing.Color.White;
        this.lbLeft.Location = new System.Drawing.Point(0, 50);
        this.lbLeft.Margin = new System.Windows.Forms.Padding(0);
        this.lbLeft.Name = "lbLeft";
        this.lbLeft.Size = new System.Drawing.Size(25, 50);
        this.lbLeft.TabIndex = 2;
        this.lbLeft.Text = "<";
        this.lbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbRight
        // 
        this.lbRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbRight.ForeColor = System.Drawing.Color.White;
        this.lbRight.Location = new System.Drawing.Point(475, 50);
        this.lbRight.Margin = new System.Windows.Forms.Padding(0);
        this.lbRight.Name = "lbRight";
        this.lbRight.Size = new System.Drawing.Size(25, 50);
        this.lbRight.TabIndex = 4;
        this.lbRight.Text = ">";
        this.lbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // MonsterStatusBar
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbRight);
        this.Controls.Add(this.lbLeft);
        this.Controls.Add(this.lbHPValue);
        this.Controls.Add(this.lbName);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "MonsterStatusBar";
        this.Size = new System.Drawing.Size(500, 100);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbLeft;

    private System.Windows.Forms.Label lbRight;

    private System.Windows.Forms.Label lbHPValue;

    private System.Windows.Forms.Label lbName;

    #endregion
}