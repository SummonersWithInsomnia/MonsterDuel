namespace MonsterDuel.src.VSMode.MonsterDetailCard
{
    partial class StatBar
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
            this.lblAttributeType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatValue = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAttributeType
            // 
            this.lblAttributeType.AutoSize = true;
            this.lblAttributeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributeType.Location = new System.Drawing.Point(70, 10);
            this.lblAttributeType.Name = "lblAttributeType";
            this.lblAttributeType.Size = new System.Drawing.Size(137, 22);
            this.lblAttributeType.TabIndex = 0;
            this.lblAttributeType.Text = "Attribute Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.lblStatValue);
            this.panel1.Location = new System.Drawing.Point(296, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 46);
            this.panel1.TabIndex = 1;
            // 
            // lblStatValue
            // 
            this.lblStatValue.AutoSize = true;
            this.lblStatValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatValue.Location = new System.Drawing.Point(44, 10);
            this.lblStatValue.Name = "lblStatValue";
            this.lblStatValue.Size = new System.Drawing.Size(103, 22);
            this.lblStatValue.TabIndex = 0;
            this.lblStatValue.Text = "Stat Value";
            // 
            // StatBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.Controls.Add(this.lblAttributeType);
            this.Controls.Add(this.panel1);
            this.Name = "StatBar";
            this.Size = new System.Drawing.Size(482, 46);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAttributeType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatValue;
    }
}
