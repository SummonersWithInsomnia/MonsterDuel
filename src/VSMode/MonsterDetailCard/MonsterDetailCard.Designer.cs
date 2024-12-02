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
            this.lblAttributes = new System.Windows.Forms.Label();
            this.arrowRight = new System.Windows.Forms.PictureBox();
            this.arrowLeft = new System.Windows.Forms.PictureBox();
            this.skillsMonsterPhoto = new System.Windows.Forms.PictureBox();
            this.statBarSPD = new MonsterDuel.src.VSMode.MonsterDetailCard.StatBar();
            this.statBarDEF = new MonsterDuel.src.VSMode.MonsterDetailCard.StatBar();
            this.statBarATK = new MonsterDuel.src.VSMode.MonsterDetailCard.StatBar();
            this.statBarHP = new MonsterDuel.src.VSMode.MonsterDetailCard.StatBar();
            this.statBarELE = new MonsterDuel.src.VSMode.MonsterDetailCard.StatBar();
            this.skillBar1 = new MonsterDuel.src.VSMode.MonsterDetailCard.SkillBar();
            this.skillBar2 = new MonsterDuel.src.VSMode.MonsterDetailCard.SkillBar();
            this.skillBar3 = new MonsterDuel.src.VSMode.MonsterDetailCard.SkillBar();
            this.skillBar4 = new MonsterDuel.src.VSMode.MonsterDetailCard.SkillBar();
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsMonsterPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMonsterName
            // 
            this.lbMonsterName.BackColor = System.Drawing.Color.Goldenrod;
            this.lbMonsterName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMonsterName.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonsterName.ForeColor = System.Drawing.Color.Black;
            this.lbMonsterName.Location = new System.Drawing.Point(688, 42);
            this.lbMonsterName.Margin = new System.Windows.Forms.Padding(0);
            this.lbMonsterName.Name = "lbMonsterName";
            this.lbMonsterName.Size = new System.Drawing.Size(526, 66);
            this.lbMonsterName.TabIndex = 0;
            this.lbMonsterName.Text = "Monster Name";
            this.lbMonsterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMonsterName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // lblAttributes
            // 
            this.lblAttributes.BackColor = System.Drawing.Color.Goldenrod;
            this.lblAttributes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAttributes.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributes.ForeColor = System.Drawing.Color.Black;
            this.lblAttributes.Location = new System.Drawing.Point(112, 42);
            this.lblAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(371, 66);
            this.lblAttributes.TabIndex = 1;
            this.lblAttributes.Text = "Attributes";
            this.lblAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttributes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            // 
            // arrowRight
            // 
            this.arrowRight.BackColor = System.Drawing.Color.Transparent;
            this.arrowRight.Image = global::MonsterDuel.Properties.Resources.rightArrow;
            this.arrowRight.Location = new System.Drawing.Point(496, 47);
            this.arrowRight.Name = "arrowRight";
            this.arrowRight.Size = new System.Drawing.Size(55, 55);
            this.arrowRight.TabIndex = 5;
            this.arrowRight.TabStop = false;
            this.arrowRight.Click += new System.EventHandler(this.arrowRight_Click);
            // 
            // arrowLeft
            // 
            this.arrowLeft.BackColor = System.Drawing.Color.Transparent;
            this.arrowLeft.Image = global::MonsterDuel.Properties.Resources.leftArrow;
            this.arrowLeft.Location = new System.Drawing.Point(44, 47);
            this.arrowLeft.Name = "arrowLeft";
            this.arrowLeft.Size = new System.Drawing.Size(55, 55);
            this.arrowLeft.TabIndex = 6;
            this.arrowLeft.TabStop = false;
            this.arrowLeft.Click += new System.EventHandler(this.arrowLeft_Click);
            // 
            // skillsMonsterPhoto
            // 
            this.skillsMonsterPhoto.BackColor = System.Drawing.Color.Transparent;
            this.skillsMonsterPhoto.Location = new System.Drawing.Point(810, 137);
            this.skillsMonsterPhoto.Name = "skillsMonsterPhoto";
            this.skillsMonsterPhoto.Size = new System.Drawing.Size(301, 412);
            this.skillsMonsterPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skillsMonsterPhoto.TabIndex = 12;
            this.skillsMonsterPhoto.TabStop = false;
            // 
            // statBarSPD
            // 
            this.statBarSPD.BackColor = System.Drawing.Color.LemonChiffon;
            this.statBarSPD.Location = new System.Drawing.Point(59, 414);
            this.statBarSPD.Name = "statBarSPD";
            this.statBarSPD.Size = new System.Drawing.Size(482, 46);
            this.statBarSPD.TabIndex = 11;
            // 
            // statBarDEF
            // 
            this.statBarDEF.BackColor = System.Drawing.Color.LemonChiffon;
            this.statBarDEF.Location = new System.Drawing.Point(59, 347);
            this.statBarDEF.Name = "statBarDEF";
            this.statBarDEF.Size = new System.Drawing.Size(482, 46);
            this.statBarDEF.TabIndex = 10;
            // 
            // statBarATK
            // 
            this.statBarATK.BackColor = System.Drawing.Color.LemonChiffon;
            this.statBarATK.Location = new System.Drawing.Point(59, 276);
            this.statBarATK.Name = "statBarATK";
            this.statBarATK.Size = new System.Drawing.Size(482, 46);
            this.statBarATK.TabIndex = 9;
            // 
            // statBarHP
            // 
            this.statBarHP.BackColor = System.Drawing.Color.LemonChiffon;
            this.statBarHP.Location = new System.Drawing.Point(59, 207);
            this.statBarHP.Name = "statBarHP";
            this.statBarHP.Size = new System.Drawing.Size(482, 46);
            this.statBarHP.TabIndex = 8;
            // 
            // statBarELE
            // 
            this.statBarELE.BackColor = System.Drawing.Color.LemonChiffon;
            this.statBarELE.Location = new System.Drawing.Point(59, 137);
            this.statBarELE.Name = "statBarELE";
            this.statBarELE.Size = new System.Drawing.Size(482, 46);
            this.statBarELE.TabIndex = 7;
            // 
            // skillBar1
            // 
            this.skillBar1.BackColor = System.Drawing.Color.Thistle;
            this.skillBar1.Location = new System.Drawing.Point(59, 137);
            this.skillBar1.Name = "skillBar1";
            this.skillBar1.Size = new System.Drawing.Size(482, 46);
            this.skillBar1.TabIndex = 13;
            // 
            // skillBar2
            // 
            this.skillBar2.BackColor = System.Drawing.Color.Thistle;
            this.skillBar2.Location = new System.Drawing.Point(59, 207);
            this.skillBar2.Name = "skillBar2";
            this.skillBar2.Size = new System.Drawing.Size(482, 46);
            this.skillBar2.TabIndex = 14;
            // 
            // skillBar3
            // 
            this.skillBar3.BackColor = System.Drawing.Color.Thistle;
            this.skillBar3.Location = new System.Drawing.Point(59, 276);
            this.skillBar3.Name = "skillBar3";
            this.skillBar3.Size = new System.Drawing.Size(482, 46);
            this.skillBar3.TabIndex = 15;
            // 
            // skillBar4
            // 
            this.skillBar4.BackColor = System.Drawing.Color.Thistle;
            this.skillBar4.Location = new System.Drawing.Point(59, 347);
            this.skillBar4.Name = "skillBar4";
            this.skillBar4.Size = new System.Drawing.Size(482, 46);
            this.skillBar4.TabIndex = 16;
            // 
            // MonsterDetailCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MonsterDuel.Properties.Resources.Skill_Background;
            this.Controls.Add(this.skillBar4);
            this.Controls.Add(this.skillBar3);
            this.Controls.Add(this.skillBar2);
            this.Controls.Add(this.skillBar1);
            this.Controls.Add(this.skillsMonsterPhoto);
            this.Controls.Add(this.statBarSPD);
            this.Controls.Add(this.statBarDEF);
            this.Controls.Add(this.statBarATK);
            this.Controls.Add(this.statBarHP);
            this.Controls.Add(this.statBarELE);
            this.Controls.Add(this.arrowLeft);
            this.Controls.Add(this.arrowRight);
            this.Controls.Add(this.lblAttributes);
            this.Controls.Add(this.lbMonsterName);
            this.Location = new System.Drawing.Point(0, 50);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MonsterDetailCard";
            this.Size = new System.Drawing.Size(1280, 620);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MonsterDetailCard_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsMonsterPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblAttributes;

        private System.Windows.Forms.Label lbMonsterName;

        #endregion

        private System.Windows.Forms.PictureBox arrowRight;
        private System.Windows.Forms.PictureBox arrowLeft;
        private src.VSMode.MonsterDetailCard.StatBar statBarELE;
        private src.VSMode.MonsterDetailCard.StatBar statBarHP;
        private src.VSMode.MonsterDetailCard.StatBar statBarATK;
        private src.VSMode.MonsterDetailCard.StatBar statBarDEF;
        private src.VSMode.MonsterDetailCard.StatBar statBarSPD;
        private System.Windows.Forms.PictureBox skillsMonsterPhoto;
        private src.VSMode.MonsterDetailCard.SkillBar skillBar1;
        private src.VSMode.MonsterDetailCard.SkillBar skillBar2;
        private src.VSMode.MonsterDetailCard.SkillBar skillBar3;
        private src.VSMode.MonsterDetailCard.SkillBar skillBar4;
    }
}