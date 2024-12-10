using System.ComponentModel;

namespace MonsterDuel;

partial class MonsterMiniCardWithStatusBar
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
        this.lbStatus = new System.Windows.Forms.Label();
        this.hpBar = new MonsterDuel.HPBar();
        this.SuspendLayout();
        // 
        // lbName
        // 
        this.lbName.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbName.ForeColor = System.Drawing.Color.White;
        this.lbName.Location = new System.Drawing.Point(0, 0);
        this.lbName.Margin = new System.Windows.Forms.Padding(0);
        this.lbName.Name = "lbName";
        this.lbName.Size = new System.Drawing.Size(300, 60);
        this.lbName.TabIndex = 0;
        this.lbName.Text = "Monster Name";
        this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterMiniCardWithStatusBar_MouseClick);
        this.lbName.MouseEnter += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseEnter);
        this.lbName.MouseLeave += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseLeave);
        // 
        // lbHPValue
        // 
        this.lbHPValue.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbHPValue.ForeColor = System.Drawing.Color.White;
        this.lbHPValue.Location = new System.Drawing.Point(300, 60);
        this.lbHPValue.Margin = new System.Windows.Forms.Padding(0);
        this.lbHPValue.Name = "lbHPValue";
        this.lbHPValue.Size = new System.Drawing.Size(300, 60);
        this.lbHPValue.TabIndex = 3;
        this.lbHPValue.Text = "1000 / 1000";
        this.lbHPValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbHPValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterMiniCardWithStatusBar_MouseClick);
        this.lbHPValue.MouseEnter += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseEnter);
        this.lbHPValue.MouseLeave += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseLeave);
        // 
        // lbStatus
        // 
        this.lbStatus.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbStatus.ForeColor = System.Drawing.Color.White;
        this.lbStatus.Location = new System.Drawing.Point(300, 0);
        this.lbStatus.Margin = new System.Windows.Forms.Padding(0);
        this.lbStatus.Name = "lbStatus";
        this.lbStatus.Size = new System.Drawing.Size(300, 60);
        this.lbStatus.TabIndex = 1;
        this.lbStatus.Text = "Status";
        this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterMiniCardWithStatusBar_MouseClick);
        this.lbStatus.MouseEnter += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseEnter);
        this.lbStatus.MouseLeave += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseLeave);
        // 
        // hpBar
        // 
        this.hpBar.BarColor = System.Drawing.Color.LawnGreen;
        this.hpBar.Location = new System.Drawing.Point(10, 70);
        this.hpBar.Margin = new System.Windows.Forms.Padding(0);
        this.hpBar.Name = "hpBar";
        this.hpBar.Size = new System.Drawing.Size(280, 40);
        this.hpBar.TabIndex = 2;
        this.hpBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterMiniCardWithStatusBar_MouseClick);
        this.hpBar.MouseEnter += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseEnter);
        this.hpBar.MouseLeave += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseLeave);
        // 
        // MonsterMiniCardWithStatusBar
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.hpBar);
        this.Controls.Add(this.lbStatus);
        this.Controls.Add(this.lbHPValue);
        this.Controls.Add(this.lbName);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "MonsterMiniCardWithStatusBar";
        this.Size = new System.Drawing.Size(600, 120);
        this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MonsterMiniCardWithStatusBar_MouseClick);
        this.MouseEnter += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseEnter);
        this.MouseLeave += new System.EventHandler(this.MonsterMiniCardWithStatusBar_MouseLeave);
        this.ResumeLayout(false);
    }

    private MonsterDuel.HPBar hpBar;

    private System.Windows.Forms.Label lbStatus;

    private System.Windows.Forms.Label lbName;

    private System.Windows.Forms.Label lbHPValue;

    #endregion
}