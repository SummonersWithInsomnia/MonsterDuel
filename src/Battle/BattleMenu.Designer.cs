using System.ComponentModel;

namespace MonsterDuel;

partial class BattleMenu
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
        this.pnMainMenu = new System.Windows.Forms.Panel();
        this.lbSurrender = new System.Windows.Forms.Label();
        this.lbSwitch = new System.Windows.Forms.Label();
        this.lbCommand = new System.Windows.Forms.Label();
        this.pnSkills = new System.Windows.Forms.Panel();
        this.lbSkill_4 = new System.Windows.Forms.Label();
        this.lbSkill_3 = new System.Windows.Forms.Label();
        this.lbSkill_2 = new System.Windows.Forms.Label();
        this.lbSkill_1 = new System.Windows.Forms.Label();
        this.pnMainMenu.SuspendLayout();
        this.pnSkills.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnMainMenu
        // 
        this.pnMainMenu.Controls.Add(this.lbSurrender);
        this.pnMainMenu.Controls.Add(this.lbSwitch);
        this.pnMainMenu.Controls.Add(this.lbCommand);
        this.pnMainMenu.Location = new System.Drawing.Point(0, 0);
        this.pnMainMenu.Margin = new System.Windows.Forms.Padding(0);
        this.pnMainMenu.Name = "pnMainMenu";
        this.pnMainMenu.Size = new System.Drawing.Size(600, 200);
        this.pnMainMenu.TabIndex = 0;
        // 
        // lbSurrender
        // 
        this.lbSurrender.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSurrender.ForeColor = System.Drawing.Color.White;
        this.lbSurrender.Location = new System.Drawing.Point(300, 100);
        this.lbSurrender.Margin = new System.Windows.Forms.Padding(0);
        this.lbSurrender.Name = "lbSurrender";
        this.lbSurrender.Size = new System.Drawing.Size(300, 100);
        this.lbSurrender.TabIndex = 2;
        this.lbSurrender.Text = "Surrender";
        this.lbSurrender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSurrender.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSurrender_MouseClick);
        // 
        // lbSwitch
        // 
        this.lbSwitch.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSwitch.ForeColor = System.Drawing.Color.White;
        this.lbSwitch.Location = new System.Drawing.Point(0, 100);
        this.lbSwitch.Margin = new System.Windows.Forms.Padding(0);
        this.lbSwitch.Name = "lbSwitch";
        this.lbSwitch.Size = new System.Drawing.Size(300, 100);
        this.lbSwitch.TabIndex = 1;
        this.lbSwitch.Text = "Switch";
        this.lbSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSwitch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSwitch_MouseClick);
        // 
        // lbCommand
        // 
        this.lbCommand.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbCommand.ForeColor = System.Drawing.Color.White;
        this.lbCommand.Location = new System.Drawing.Point(0, 0);
        this.lbCommand.Margin = new System.Windows.Forms.Padding(0);
        this.lbCommand.Name = "lbCommand";
        this.lbCommand.Size = new System.Drawing.Size(300, 100);
        this.lbCommand.TabIndex = 0;
        this.lbCommand.Text = "Command";
        this.lbCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbCommand_MouseClick);
        // 
        // pnSkills
        // 
        this.pnSkills.Controls.Add(this.lbSkill_4);
        this.pnSkills.Controls.Add(this.lbSkill_3);
        this.pnSkills.Controls.Add(this.lbSkill_2);
        this.pnSkills.Controls.Add(this.lbSkill_1);
        this.pnSkills.Location = new System.Drawing.Point(0, 0);
        this.pnSkills.Margin = new System.Windows.Forms.Padding(0);
        this.pnSkills.Name = "pnSkills";
        this.pnSkills.Size = new System.Drawing.Size(600, 200);
        this.pnSkills.TabIndex = 1;
        this.pnSkills.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnSkills_MouseClick);
        // 
        // lbSkill_4
        // 
        this.lbSkill_4.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSkill_4.ForeColor = System.Drawing.Color.White;
        this.lbSkill_4.Location = new System.Drawing.Point(300, 100);
        this.lbSkill_4.Margin = new System.Windows.Forms.Padding(0);
        this.lbSkill_4.Name = "lbSkill_4";
        this.lbSkill_4.Size = new System.Drawing.Size(300, 100);
        this.lbSkill_4.TabIndex = 3;
        this.lbSkill_4.Text = "Skill 4";
        this.lbSkill_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSkill_4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSkill_MouseClick);
        // 
        // lbSkill_3
        // 
        this.lbSkill_3.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSkill_3.ForeColor = System.Drawing.Color.White;
        this.lbSkill_3.Location = new System.Drawing.Point(0, 100);
        this.lbSkill_3.Margin = new System.Windows.Forms.Padding(0);
        this.lbSkill_3.Name = "lbSkill_3";
        this.lbSkill_3.Size = new System.Drawing.Size(300, 100);
        this.lbSkill_3.TabIndex = 2;
        this.lbSkill_3.Text = "Skill 3";
        this.lbSkill_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSkill_3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSkill_MouseClick);
        // 
        // lbSkill_2
        // 
        this.lbSkill_2.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSkill_2.ForeColor = System.Drawing.Color.White;
        this.lbSkill_2.Location = new System.Drawing.Point(300, 0);
        this.lbSkill_2.Margin = new System.Windows.Forms.Padding(0);
        this.lbSkill_2.Name = "lbSkill_2";
        this.lbSkill_2.Size = new System.Drawing.Size(300, 100);
        this.lbSkill_2.TabIndex = 1;
        this.lbSkill_2.Text = "Skill 2";
        this.lbSkill_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSkill_2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSkill_MouseClick);
        // 
        // lbSkill_1
        // 
        this.lbSkill_1.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbSkill_1.ForeColor = System.Drawing.Color.White;
        this.lbSkill_1.Location = new System.Drawing.Point(0, 0);
        this.lbSkill_1.Margin = new System.Windows.Forms.Padding(0);
        this.lbSkill_1.Name = "lbSkill_1";
        this.lbSkill_1.Size = new System.Drawing.Size(300, 100);
        this.lbSkill_1.TabIndex = 0;
        this.lbSkill_1.Text = "Skill 1";
        this.lbSkill_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbSkill_1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSkill_MouseClick);
        // 
        // BattleMenu
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.pnSkills);
        this.Controls.Add(this.pnMainMenu);
        this.Location = new System.Drawing.Point(680, 520);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "BattleMenu";
        this.Size = new System.Drawing.Size(600, 200);
        this.VisibleChanged += new System.EventHandler(this.BattleMenu_VisibleChanged);
        this.pnMainMenu.ResumeLayout(false);
        this.pnSkills.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbSkill_1;
    private System.Windows.Forms.Label lbSkill_2;
    private System.Windows.Forms.Label lbSkill_3;

    private System.Windows.Forms.Label lbSkill_4;

    private System.Windows.Forms.Panel pnSkills;

    private System.Windows.Forms.Label lbSwitch;
    private System.Windows.Forms.Label lbSurrender;

    private System.Windows.Forms.Panel pnMainMenu;
    private System.Windows.Forms.Label lbCommand;

    #endregion
}