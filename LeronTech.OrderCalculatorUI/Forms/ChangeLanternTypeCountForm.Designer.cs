namespace LeronTech.OrderCalculatorUI.Forms
{
    partial class ChangeLanternTypeCountForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.lblMaxLanternTypeCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLanternTypeCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(86, 111);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // lblMaxLanternTypeCount
            // 
            this.lblMaxLanternTypeCount.AutoSize = true;
            this.lblMaxLanternTypeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMaxLanternTypeCount.Location = new System.Drawing.Point(99, 84);
            this.lblMaxLanternTypeCount.Name = "lblMaxLanternTypeCount";
            this.lblMaxLanternTypeCount.Size = new System.Drawing.Size(47, 13);
            this.lblMaxLanternTypeCount.TabIndex = 6;
            this.lblMaxLanternTypeCount.Text = "Макс. X";
            this.lblMaxLanternTypeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Кол-во типов фонарей:";
            // 
            // txbLanternTypeCount
            // 
            this.txbLanternTypeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbLanternTypeCount.Location = new System.Drawing.Point(92, 51);
            this.txbLanternTypeCount.Name = "txbLanternTypeCount";
            this.txbLanternTypeCount.Size = new System.Drawing.Size(63, 30);
            this.txbLanternTypeCount.TabIndex = 4;
            this.txbLanternTypeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChangeLanternTypeCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 145);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.lblMaxLanternTypeCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbLanternTypeCount);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(265, 184);
            this.MinimumSize = new System.Drawing.Size(265, 184);
            this.Name = "ChangeLanternTypeCountForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Вкладки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label lblMaxLanternTypeCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLanternTypeCount;
    }
}