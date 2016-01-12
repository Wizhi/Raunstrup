namespace Raunstrup.Forms
{
    partial class ProjectComparisonForm
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
            this.ComparisonListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComparisonListBox
            // 
            this.ComparisonListBox.FormattingEnabled = true;
            this.ComparisonListBox.Location = new System.Drawing.Point(12, 30);
            this.ComparisonListBox.Name = "ComparisonListBox";
            this.ComparisonListBox.Size = new System.Drawing.Size(391, 199);
            this.ComparisonListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Individuelt forbrug for projekt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SamletForbrug:";
            // 
            // ProjectProgressBar
            // 
            this.ProjectProgressBar.Location = new System.Drawing.Point(12, 248);
            this.ProjectProgressBar.Name = "ProjectProgressBar";
            this.ProjectProgressBar.Size = new System.Drawing.Size(391, 23);
            this.ProjectProgressBar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "103%";
            // 
            // ProjectComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 288);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProjectProgressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComparisonListBox);
            this.Name = "ProjectComparisonForm";
            this.Text = "Projekt sammenligning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ComparisonListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar ProjectProgressBar;
        private System.Windows.Forms.Label label3;
    }
}