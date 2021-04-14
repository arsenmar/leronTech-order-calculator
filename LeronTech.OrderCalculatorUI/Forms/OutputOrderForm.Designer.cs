namespace LeronTech.OrderCalculatorUI.Forms
{
    partial class OutputOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.PathC = new System.Windows.Forms.TextBox();
            this.ChooseDirectoryButton = new System.Windows.Forms.Button();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Путь выгузки:";
            // 
            // PathC
            // 
            this.PathC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.PathC.Location = new System.Drawing.Point(15, 30);
            this.PathC.Name = "PathC";
            this.PathC.Size = new System.Drawing.Size(217, 22);
            this.PathC.TabIndex = 5;
            // 
            // ChooseDirectoryButton
            // 
            this.ChooseDirectoryButton.Location = new System.Drawing.Point(238, 30);
            this.ChooseDirectoryButton.Name = "ChooseDirectoryButton";
            this.ChooseDirectoryButton.Size = new System.Drawing.Size(79, 22);
            this.ChooseDirectoryButton.TabIndex = 3;
            this.ChooseDirectoryButton.Text = "Обзор";
            this.ChooseDirectoryButton.UseVisualStyleBackColor = true;
            this.ChooseDirectoryButton.Click += new System.EventHandler(this.ChooseDirectoryButton_Click);
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Location = new System.Drawing.Point(106, 92);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(130, 32);
            this.CreateReportButton.TabIndex = 4;
            this.CreateReportButton.Text = "Выгрузить";
            this.CreateReportButton.UseVisualStyleBackColor = true;
            this.CreateReportButton.Click += new System.EventHandler(this.CreateReportButton_Click);
            // 
            // OutputOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 136);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathC);
            this.Controls.Add(this.ChooseDirectoryButton);
            this.Controls.Add(this.CreateReportButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 175);
            this.MinimumSize = new System.Drawing.Size(360, 175);
            this.Name = "OutputOrderForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выгрузить отчет";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathC;
        private System.Windows.Forms.Button ChooseDirectoryButton;
        private System.Windows.Forms.Button CreateReportButton;
    }
}