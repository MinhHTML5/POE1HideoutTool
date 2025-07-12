namespace POE1Tools
{
    partial class Main
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
            lblTitle = new System.Windows.Forms.Label();
            grpFeatures = new System.Windows.Forms.GroupBox();
            optScourChance = new System.Windows.Forms.RadioButton();
            optDivCard = new System.Windows.Forms.RadioButton();
            grpDivCard = new System.Windows.Forms.GroupBox();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            txtDivCard = new System.Windows.Forms.TextBox();
            grpScourChance = new System.Windows.Forms.GroupBox();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox6 = new System.Windows.Forms.TextBox();
            textBox7 = new System.Windows.Forms.TextBox();
            trkRate = new System.Windows.Forms.TrackBar();
            lblUpdateRate = new System.Windows.Forms.Label();
            grpFeatures.SuspendLayout();
            grpDivCard.SuspendLayout();
            grpScourChance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkRate).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(15, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(380, 37);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "POE1 Hideout Warrior Toolbox";
            // 
            // grpFeatures
            // 
            grpFeatures.Controls.Add(optScourChance);
            grpFeatures.Controls.Add(optDivCard);
            grpFeatures.Location = new System.Drawing.Point(15, 75);
            grpFeatures.Name = "grpFeatures";
            grpFeatures.Size = new System.Drawing.Size(200, 224);
            grpFeatures.TabIndex = 3;
            grpFeatures.TabStop = false;
            grpFeatures.Text = "Features list";
            // 
            // optScourChance
            // 
            optScourChance.AutoSize = true;
            optScourChance.Location = new System.Drawing.Point(6, 47);
            optScourChance.Name = "optScourChance";
            optScourChance.Size = new System.Drawing.Size(147, 19);
            optScourChance.TabIndex = 1;
            optScourChance.TabStop = true;
            optScourChance.Text = "Auto scour chance belt";
            optScourChance.UseVisualStyleBackColor = true;
            optScourChance.CheckedChanged += optScourChance_CheckedChanged;
            // 
            // optDivCard
            // 
            optDivCard.AutoSize = true;
            optDivCard.Location = new System.Drawing.Point(6, 22);
            optDivCard.Name = "optDivCard";
            optDivCard.Size = new System.Drawing.Size(131, 19);
            optDivCard.TabIndex = 0;
            optDivCard.TabStop = true;
            optDivCard.Text = "Auto trade div cards";
            optDivCard.UseVisualStyleBackColor = true;
            optDivCard.CheckedChanged += optDivCard_CheckedChanged;
            // 
            // grpDivCard
            // 
            grpDivCard.Controls.Add(textBox3);
            grpDivCard.Controls.Add(textBox2);
            grpDivCard.Controls.Add(textBox1);
            grpDivCard.Controls.Add(txtDivCard);
            grpDivCard.Location = new System.Drawing.Point(240, 75);
            grpDivCard.Name = "grpDivCard";
            grpDivCard.Size = new System.Drawing.Size(318, 354);
            grpDivCard.TabIndex = 4;
            grpDivCard.TabStop = false;
            grpDivCard.Text = "Auto trade div card";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(6, 155);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(306, 30);
            textBox3.TabIndex = 8;
            textBox3.Text = "Press control + down arrow to stop if needed.";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(6, 119);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(306, 30);
            textBox2.TabIndex = 7;
            textBox2.Text = "Press control + up arrow to start.";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(6, 83);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(306, 30);
            textBox1.TabIndex = 6;
            textBox1.Text = "After that, talk with Lily, open trade div card window.";
            // 
            // txtDivCard
            // 
            txtDivCard.Location = new System.Drawing.Point(6, 22);
            txtDivCard.Multiline = true;
            txtDivCard.Name = "txtDivCard";
            txtDivCard.ReadOnly = true;
            txtDivCard.Size = new System.Drawing.Size(306, 55);
            txtDivCard.TabIndex = 5;
            txtDivCard.Text = "Load your inventory full of div cards that only exchange to a 1 slot items (currencies or maps mostly) and nothing else.";
            // 
            // grpScourChance
            // 
            grpScourChance.Controls.Add(textBox4);
            grpScourChance.Controls.Add(textBox5);
            grpScourChance.Controls.Add(textBox6);
            grpScourChance.Controls.Add(textBox7);
            grpScourChance.Location = new System.Drawing.Point(240, 75);
            grpScourChance.Name = "grpScourChance";
            grpScourChance.Size = new System.Drawing.Size(318, 354);
            grpScourChance.TabIndex = 9;
            grpScourChance.TabStop = false;
            grpScourChance.Text = "Auto scour chance";
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(6, 155);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new System.Drawing.Size(306, 30);
            textBox4.TabIndex = 8;
            textBox4.Text = "Press control + down arrow to stop if needed.";
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(6, 119);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new System.Drawing.Size(306, 30);
            textBox5.TabIndex = 7;
            textBox5.Text = "Press control + up arrow to start.";
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(6, 72);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new System.Drawing.Size(306, 41);
            textBox6.TabIndex = 6;
            textBox6.Text = "After that, open crafting bench, select scour chance option. (type \"reroll\" on the search bar)";
            // 
            // textBox7
            // 
            textBox7.Location = new System.Drawing.Point(6, 22);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new System.Drawing.Size(306, 44);
            textBox7.TabIndex = 5;
            textBox7.Text = "Load your inventory full of heavy belt or leather belt and nothing else.";
            // 
            // trkRate
            // 
            trkRate.LargeChange = 1;
            trkRate.Location = new System.Drawing.Point(21, 378);
            trkRate.Minimum = 1;
            trkRate.Name = "trkRate";
            trkRate.Size = new System.Drawing.Size(194, 45);
            trkRate.TabIndex = 5;
            trkRate.Value = 3;
            trkRate.Scroll += trkRate_Scroll;
            // 
            // lblUpdateRate
            // 
            lblUpdateRate.AutoSize = true;
            lblUpdateRate.Location = new System.Drawing.Point(21, 360);
            lblUpdateRate.Name = "lblUpdateRate";
            lblUpdateRate.Size = new System.Drawing.Size(121, 15);
            lblUpdateRate.TabIndex = 6;
            lblUpdateRate.Text = "Command rate: 75ms";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(570, 441);
            Controls.Add(grpScourChance);
            Controls.Add(lblUpdateRate);
            Controls.Add(trkRate);
            Controls.Add(grpDivCard);
            Controls.Add(grpFeatures);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            Text = "POE1 Toolbox";
            Load += Main_Load;
            grpFeatures.ResumeLayout(false);
            grpFeatures.PerformLayout();
            grpDivCard.ResumeLayout(false);
            grpDivCard.PerformLayout();
            grpScourChance.ResumeLayout(false);
            grpScourChance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFeatures;
        private System.Windows.Forms.RadioButton optDivCard;
        private System.Windows.Forms.GroupBox grpDivCard;
        private System.Windows.Forms.TextBox txtDivCard;
        private System.Windows.Forms.TrackBar trkRate;
        private System.Windows.Forms.Label lblUpdateRate;
        private System.Windows.Forms.RadioButton optScourChance;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grpScourChance;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
    }
}