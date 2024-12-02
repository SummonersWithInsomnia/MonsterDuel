namespace MonsterDuel.src.VSMode.MonsterDetailCard
{
    partial class SkillBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSkillType = new System.Windows.Forms.Label();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.lblSkillLimit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.Controls.Add(this.lblSkillType);
            this.panel1.Location = new System.Drawing.Point(319, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 46);
            this.panel1.TabIndex = 0;
            // 
            // lblSkillType
            // 
            this.lblSkillType.AutoSize = true;
            this.lblSkillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillType.Location = new System.Drawing.Point(22, 15);
            this.lblSkillType.Name = "lblSkillType";
            this.lblSkillType.Size = new System.Drawing.Size(43, 16);
            this.lblSkillType.TabIndex = 4;
            this.lblSkillType.Text = "Type";
            // 
            // lblSkillName
            // 
            this.lblSkillName.AutoSize = true;
            this.lblSkillName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillName.Location = new System.Drawing.Point(35, 16);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(82, 16);
            this.lblSkillName.TabIndex = 2;
            this.lblSkillName.Text = "Skill Name";
            // 
            // lblSkillLimit
            // 
            this.lblSkillLimit.AutoSize = true;
            this.lblSkillLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblSkillLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillLimit.Location = new System.Drawing.Point(63, 16);
            this.lblSkillLimit.Name = "lblSkillLimit";
            this.lblSkillLimit.Size = new System.Drawing.Size(39, 16);
            this.lblSkillLimit.TabIndex = 3;
            this.lblSkillLimit.Text = "Limit";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.lblSkillLimit);
            this.panel2.Location = new System.Drawing.Point(158, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 46);
            this.panel2.TabIndex = 1;
            // 
            // SkillBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.lblSkillName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SkillBar";
            this.Size = new System.Drawing.Size(482, 46);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSkillType;
        private System.Windows.Forms.Label lblSkillName;
        private System.Windows.Forms.Label lblSkillLimit;
        private System.Windows.Forms.Panel panel2;
    }
}
