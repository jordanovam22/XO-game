
namespace XO_Game
{
    partial class ChooseGameType
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn1Vs1 = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1Vs1
            // 
            this.btn1Vs1.BackColor = System.Drawing.Color.Firebrick;
            this.btn1Vs1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1Vs1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn1Vs1.Location = new System.Drawing.Point(49, 24);
            this.btn1Vs1.Name = "btn1Vs1";
            this.btn1Vs1.Size = new System.Drawing.Size(140, 49);
            this.btn1Vs1.TabIndex = 0;
            this.btn1Vs1.Text = "1 vs 1";
            this.btn1Vs1.UseVisualStyleBackColor = false;
            this.btn1Vs1.Click += new System.EventHandler(this.btn1Vs1_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.Location = new System.Drawing.Point(49, 79);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(140, 49);
            this.btnEasy.TabIndex = 1;
            this.btnEasy.Text = "1 vs Computer (easy)";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHard.Location = new System.Drawing.Point(49, 137);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(140, 49);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "1 vs Computer (hard)";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // ChooseGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(243, 206);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btn1Vs1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseGameType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseGameType";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1Vs1;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnHard;
    }
}