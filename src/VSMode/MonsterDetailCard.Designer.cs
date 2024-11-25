using System.ComponentModel;

namespace MonsterDuel
{
    partial class MonsterDetailCard
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
            this.lbMonsterName = new System.Windows.Forms.Label();
            this.lbAttributes = new System.Windows.Forms.Label();
            this.lbSkills = new System.Windows.Forms.Label();
            this.lbAttributeList = new System.Windows.Forms.Label();
            this.lbSkillList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMonsterName
            // 
            this.lbMonsterName.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonsterName.ForeColor = System.Drawing.Color.White;
            this.lbMonsterName.Location = new System.Drawing.Point(0, 0);
            this.lbMonsterName.Margin = new System.Windows.Forms.Padding(0);
            this.lbMonsterName.Name = "lbMonsterName";
            this.lbMonsterName.Size = new System.Drawing.Size(1280, 103);
            this.lbMonsterName.TabIndex = 0;
            this.lbMonsterName.Text = "Monster Name";
            this.lbMonsterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMonsterName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // lbAttributes
            // 
            this.lbAttributes.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttributes.ForeColor = System.Drawing.Color.White;
            this.lbAttributes.Location = new System.Drawing.Point(0, 103);
            this.lbAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.lbAttributes.Name = "lbAttributes";
            this.lbAttributes.Size = new System.Drawing.Size(640, 65);
            this.lbAttributes.TabIndex = 1;
            this.lbAttributes.Text = "Attributes";
            this.lbAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAttributes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // lbSkills
            // 
            this.lbSkills.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSkills.ForeColor = System.Drawing.Color.White;
            this.lbSkills.Location = new System.Drawing.Point(640, 103);
            this.lbSkills.Margin = new System.Windows.Forms.Padding(0);
            this.lbSkills.Name = "lbSkills";
            this.lbSkills.Size = new System.Drawing.Size(640, 65);
            this.lbSkills.TabIndex = 2;
            this.lbSkills.Text = "Skills";
            this.lbSkills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSkills.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // lbAttributeList
            // 
            this.lbAttributeList.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAttributeList.ForeColor = System.Drawing.Color.White;
            this.lbAttributeList.Location = new System.Drawing.Point(0, 168);
            this.lbAttributeList.Margin = new System.Windows.Forms.Padding(0);
            this.lbAttributeList.Name = "lbAttributeList";
            this.lbAttributeList.Size = new System.Drawing.Size(640, 452);
            this.lbAttributeList.TabIndex = 3;
            this.lbAttributeList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbAttributeList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // lbSkillList
            // 
            this.lbSkillList.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSkillList.ForeColor = System.Drawing.Color.White;
            this.lbSkillList.Location = new System.Drawing.Point(640, 168);
            this.lbSkillList.Margin = new System.Windows.Forms.Padding(0);
            this.lbSkillList.Name = "lbSkillList";
            this.lbSkillList.Size = new System.Drawing.Size(640, 452);
            this.lbSkillList.TabIndex = 4;
            this.lbSkillList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbSkillList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // MonsterDetailCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lbSkillList);
            this.Controls.Add(this.lbAttributeList);
            this.Controls.Add(this.lbSkills);
            this.Controls.Add(this.lbAttributes);
            this.Controls.Add(this.lbMonsterName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MonsterDetailCard";
            this.Size = new System.Drawing.Size(1280, 620);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbAttributes;
        private System.Windows.Forms.Label lbAttributeList;

        private System.Windows.Forms.Label lbSkills;

        private System.Windows.Forms.Label lbSkillList;

        private System.Windows.Forms.Label lbMonsterName;

        #endregion
    }
}