namespace Raunstrup.Forms
{
    partial class EmployeeStatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EmployeeBox = new System.Windows.Forms.ComboBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EmployeeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetButton = new System.Windows.Forms.Button();
            this.HoursWorkedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.InvoicedDegreeLabel = new System.Windows.Forms.Label();
            this.PercentDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HoursWorkedChart)).BeginInit();
            this.ChartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeBox
            // 
            this.EmployeeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmployeeBox.FormattingEnabled = true;
            this.EmployeeBox.Location = new System.Drawing.Point(24, 23);
            this.EmployeeBox.Name = "EmployeeBox";
            this.EmployeeBox.Size = new System.Drawing.Size(200, 21);
            this.EmployeeBox.TabIndex = 0;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(24, 63);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(24, 104);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDatePicker.TabIndex = 2;
            // 
            // EmployeeLabel
            // 
            this.EmployeeLabel.AutoSize = true;
            this.EmployeeLabel.Location = new System.Drawing.Point(21, 7);
            this.EmployeeLabel.Name = "EmployeeLabel";
            this.EmployeeLabel.Size = new System.Drawing.Size(34, 13);
            this.EmployeeLabel.TabIndex = 4;
            this.EmployeeLabel.Text = "Ansat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Dato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Slut Dato";
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(24, 140);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(200, 23);
            this.GetButton.TabIndex = 8;
            this.GetButton.Text = "Hent Statistik";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // HoursWorkedChart
            // 
            this.HoursWorkedChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.HoursWorkedChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.HoursWorkedChart.Legends.Add(legend1);
            this.HoursWorkedChart.Location = new System.Drawing.Point(3, 24);
            this.HoursWorkedChart.Name = "HoursWorkedChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "ArbejdsTimer";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.HoursWorkedChart.Series.Add(series1);
            this.HoursWorkedChart.Size = new System.Drawing.Size(687, 230);
            this.HoursWorkedChart.TabIndex = 9;
            this.HoursWorkedChart.Text = "chart1";
            // 
            // ChartPanel
            // 
            this.ChartPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChartPanel.Controls.Add(this.InvoicedDegreeLabel);
            this.ChartPanel.Controls.Add(this.PercentDescriptionLabel);
            this.ChartPanel.Controls.Add(this.HoursWorkedChart);
            this.ChartPanel.Location = new System.Drawing.Point(243, 23);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(721, 273);
            this.ChartPanel.TabIndex = 10;
            // 
            // InvoicedDegreeLabel
            // 
            this.InvoicedDegreeLabel.AutoSize = true;
            this.InvoicedDegreeLabel.Location = new System.Drawing.Point(94, 3);
            this.InvoicedDegreeLabel.Name = "InvoicedDegreeLabel";
            this.InvoicedDegreeLabel.Size = new System.Drawing.Size(21, 13);
            this.InvoicedDegreeLabel.TabIndex = 12;
            this.InvoicedDegreeLabel.Text = "0%";
            // 
            // PercentDescriptionLabel
            // 
            this.PercentDescriptionLabel.AutoSize = true;
            this.PercentDescriptionLabel.Location = new System.Drawing.Point(3, 3);
            this.PercentDescriptionLabel.Name = "PercentDescriptionLabel";
            this.PercentDescriptionLabel.Size = new System.Drawing.Size(94, 13);
            this.PercentDescriptionLabel.TabIndex = 11;
            this.PercentDescriptionLabel.Text = "Fakturerings Grad:";
            // 
            // EmployeeStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 298);
            this.Controls.Add(this.ChartPanel);
            this.Controls.Add(this.GetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeLabel);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.EmployeeBox);
            this.Name = "EmployeeStatisticsForm";
            this.Text = "EmployeeStatisticsForm";
            ((System.ComponentModel.ISupportInitialize)(this.HoursWorkedChart)).EndInit();
            this.ChartPanel.ResumeLayout(false);
            this.ChartPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EmployeeBox;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label EmployeeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart HoursWorkedChart;
        private System.Windows.Forms.Panel ChartPanel;
        private System.Windows.Forms.Label InvoicedDegreeLabel;
        private System.Windows.Forms.Label PercentDescriptionLabel;
    }
}