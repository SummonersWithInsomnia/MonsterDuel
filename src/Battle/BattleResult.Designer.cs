using System.ComponentModel;

namespace MonsterDuel;

partial class BattleResult
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
        this.lbTitle = new System.Windows.Forms.Label();
        this.lbResult = new System.Windows.Forms.Label();
        this.lbBackToGameTitle = new System.Windows.Forms.Label();
        this.lbRetry = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // lbTitle
        // 
        this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbTitle.ForeColor = System.Drawing.Color.White;
        this.lbTitle.Location = new System.Drawing.Point(0, 30);
        this.lbTitle.Margin = new System.Windows.Forms.Padding(0);
        this.lbTitle.Name = "lbTitle";
        this.lbTitle.Size = new System.Drawing.Size(1280, 80);
        this.lbTitle.TabIndex = 0;
        this.lbTitle.Text = "- BATTLE RESULT -";
        this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbResult
        // 
        this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 64.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbResult.ForeColor = System.Drawing.Color.White;
        this.lbResult.Location = new System.Drawing.Point(0, 130);
        this.lbResult.Margin = new System.Windows.Forms.Padding(0);
        this.lbResult.Name = "lbResult";
        this.lbResult.Size = new System.Drawing.Size(1280, 160);
        this.lbResult.TabIndex = 1;
        this.lbResult.Text = "RESULT";
        this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lbBackToGameTitle
        // 
        this.lbBackToGameTitle.Font = new System.Drawing.Font("Courier New", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbBackToGameTitle.ForeColor = System.Drawing.Color.White;
        this.lbBackToGameTitle.Location = new System.Drawing.Point(0, 520);
        this.lbBackToGameTitle.Margin = new System.Windows.Forms.Padding(0);
        this.lbBackToGameTitle.Name = "lbBackToGameTitle";
        this.lbBackToGameTitle.Size = new System.Drawing.Size(1280, 80);
        this.lbBackToGameTitle.TabIndex = 3;
        this.lbBackToGameTitle.Text = "Back to Title";
        this.lbBackToGameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbBackToGameTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbBackToGameTitle_MouseClick);
        // 
        // lbRetry
        // 
        this.lbRetry.Font = new System.Drawing.Font("Courier New", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbRetry.ForeColor = System.Drawing.Color.White;
        this.lbRetry.Location = new System.Drawing.Point(0, 420);
        this.lbRetry.Margin = new System.Windows.Forms.Padding(0);
        this.lbRetry.Name = "lbRetry";
        this.lbRetry.Size = new System.Drawing.Size(1280, 80);
        this.lbRetry.TabIndex = 2;
        this.lbRetry.Text = "Retry";
        this.lbRetry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lbRetry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbRetry_MouseClick);
        // 
        // BattleResult
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(this.lbRetry);
        this.Controls.Add(this.lbBackToGameTitle);
        this.Controls.Add(this.lbResult);
        this.Controls.Add(this.lbTitle);
        this.Margin = new System.Windows.Forms.Padding(0);
        this.Name = "BattleResult";
        this.Size = new System.Drawing.Size(1280, 720);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbRetry;

    private System.Windows.Forms.Label lbBackToGameTitle;

    private System.Windows.Forms.Label lbResult;

    private System.Windows.Forms.Label lbTitle;

    #endregion
}