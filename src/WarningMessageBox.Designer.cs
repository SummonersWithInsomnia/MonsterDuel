using System.ComponentModel;

namespace MonsterDuel
{
    partial class WarningMessageBox
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
            this.pbWarningBarTop = new System.Windows.Forms.PictureBox();
            this.pbWarningBarBottom = new System.Windows.Forms.PictureBox();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbYes = new System.Windows.Forms.Label();
            this.lbNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningBarTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningBarBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWarningBarTop
            // 
            this.pbWarningBarTop.Location = new System.Drawing.Point(0, 0);
            this.pbWarningBarTop.Margin = new System.Windows.Forms.Padding(0);
            this.pbWarningBarTop.Name = "pbWarningBarTop";
            this.pbWarningBarTop.Size = new System.Drawing.Size(1280, 40);
            this.pbWarningBarTop.TabIndex = 0;
            this.pbWarningBarTop.TabStop = false;
            // 
            // pbWarningBarBottom
            // 
            this.pbWarningBarBottom.Location = new System.Drawing.Point(0, 580);
            this.pbWarningBarBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pbWarningBarBottom.Name = "pbWarningBarBottom";
            this.pbWarningBarBottom.Size = new System.Drawing.Size(1280, 40);
            this.pbWarningBarBottom.TabIndex = 1;
            this.pbWarningBarBottom.TabStop = false;
            // 
            // lbHeader
            // 
            this.lbHeader.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.White;
            this.lbHeader.Location = new System.Drawing.Point(0, 80);
            this.lbHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(1280, 76);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "Header";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(0, 181);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(1280, 229);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "Message";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbYes
            // 
            this.lbYes.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYes.ForeColor = System.Drawing.Color.White;
            this.lbYes.Location = new System.Drawing.Point(0, 468);
            this.lbYes.Margin = new System.Windows.Forms.Padding(0);
            this.lbYes.Name = "lbYes";
            this.lbYes.Size = new System.Drawing.Size(640, 81);
            this.lbYes.TabIndex = 4;
            this.lbYes.Text = "Yes";
            this.lbYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbYes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbYes_MouseClick);
            // 
            // lbNo
            // 
            this.lbNo.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNo.ForeColor = System.Drawing.Color.White;
            this.lbNo.Location = new System.Drawing.Point(640, 468);
            this.lbNo.Margin = new System.Windows.Forms.Padding(0);
            this.lbNo.Name = "lbNo";
            this.lbNo.Size = new System.Drawing.Size(640, 81);
            this.lbNo.TabIndex = 5;
            this.lbNo.Text = "No";
            this.lbNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbNo_MouseClick);
            // 
            // WarningMessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lbNo);
            this.Controls.Add(this.lbYes);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.pbWarningBarBottom);
            this.Controls.Add(this.pbWarningBarTop);
            this.Location = new System.Drawing.Point(0, 50);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WarningMessageBox";
            this.Size = new System.Drawing.Size(1280, 620);
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningBarTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarningBarBottom)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbNo;

        private System.Windows.Forms.Label lbYes;

        private System.Windows.Forms.Label lbMessage;

        private System.Windows.Forms.Label lbHeader;

        private System.Windows.Forms.PictureBox pbWarningBarTop;
        private System.Windows.Forms.PictureBox pbWarningBarBottom;

        #endregion
    }
}