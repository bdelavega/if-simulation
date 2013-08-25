namespace simulator
{
    partial class Form1
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
            this.numDaysOfHourlies = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numBackupsPerHour = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDaysOfHourlies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackupsPerHour)).BeginInit();
            this.SuspendLayout();
            // 
            // numDaysOfHourlies
            // 
            this.numDaysOfHourlies.Location = new System.Drawing.Point(120, 14);
            this.numDaysOfHourlies.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numDaysOfHourlies.Name = "numDaysOfHourlies";
            this.numDaysOfHourlies.Size = new System.Drawing.Size(41, 20);
            this.numDaysOfHourlies.TabIndex = 0;
            this.numDaysOfHourlies.Tag = "";
            this.numDaysOfHourlies.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(694, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Simulate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Days of Hourlies:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(799, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(192, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Backups / Hour:";
            // 
            // numBackupsPerHour
            // 
            this.numBackupsPerHour.Location = new System.Drawing.Point(281, 16);
            this.numBackupsPerHour.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBackupsPerHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBackupsPerHour.Name = "numBackupsPerHour";
            this.numBackupsPerHour.Size = new System.Drawing.Size(41, 20);
            this.numBackupsPerHour.TabIndex = 4;
            this.numBackupsPerHour.Tag = "";
            this.numBackupsPerHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numBackupsPerHour);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numDaysOfHourlies);
            this.Name = "Form1";
            this.Text = "Incremental Forever Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDaysOfHourlies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackupsPerHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numDaysOfHourlies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBackupsPerHour;
    }
}

