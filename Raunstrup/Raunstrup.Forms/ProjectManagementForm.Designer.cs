namespace Raunstrup.Forms
{
    partial class ProjectManagementForm
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
            this._employeeRemoveButton = new System.Windows.Forms.Button();
            this._employeeAddButton = new System.Windows.Forms.Button();
            this._employeesOLV = new BrightIdeasSoftware.ObjectListView();
            this.EmployeeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.EmployeeSkills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._availableEmployeesOLV = new BrightIdeasSoftware.ObjectListView();
            this.AvailableEmployeeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AvailableEmployeeSkills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._filterTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._employeesGroupBox = new System.Windows.Forms.GroupBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forbrugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._employeesOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._availableEmployeesOLV)).BeginInit();
            this._employeesGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _employeeRemoveButton
            // 
            this._employeeRemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._employeeRemoveButton.Enabled = false;
            this._employeeRemoveButton.Location = new System.Drawing.Point(201, 120);
            this._employeeRemoveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._employeeRemoveButton.Name = "_employeeRemoveButton";
            this._employeeRemoveButton.Size = new System.Drawing.Size(50, 22);
            this._employeeRemoveButton.TabIndex = 2;
            this._employeeRemoveButton.Text = "Fjern ->";
            this._employeeRemoveButton.UseVisualStyleBackColor = true;
            this._employeeRemoveButton.Click += new System.EventHandler(this._employeeRemoveButton_Click);
            // 
            // _employeeAddButton
            // 
            this._employeeAddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._employeeAddButton.Enabled = false;
            this._employeeAddButton.Location = new System.Drawing.Point(201, 93);
            this._employeeAddButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._employeeAddButton.Name = "_employeeAddButton";
            this._employeeAddButton.Size = new System.Drawing.Size(50, 22);
            this._employeeAddButton.TabIndex = 1;
            this._employeeAddButton.Text = "<- Tilføj";
            this._employeeAddButton.UseVisualStyleBackColor = true;
            this._employeeAddButton.Click += new System.EventHandler(this._employeeAddButton_Click);
            // 
            // _employeesOLV
            // 
            this._employeesOLV.AllColumns.Add(this.EmployeeName);
            this._employeesOLV.AllColumns.Add(this.EmployeeSkills);
            this._employeesOLV.CellEditUseWholeCell = false;
            this._employeesOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EmployeeName,
            this.EmployeeSkills});
            this._employeesOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._employeesOLV.FullRowSelect = true;
            this._employeesOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._employeesOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._employeesOLV.Location = new System.Drawing.Point(4, 31);
            this._employeesOLV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._employeesOLV.Name = "_employeesOLV";
            this._employeesOLV.Size = new System.Drawing.Size(193, 255);
            this._employeesOLV.TabIndex = 3;
            this._employeesOLV.UseCompatibleStateImageBehavior = false;
            this._employeesOLV.UseFiltering = true;
            this._employeesOLV.View = System.Windows.Forms.View.Details;
            this._employeesOLV.SelectionChanged += new System.EventHandler(this._employeesOLV_SelectionChanged);
            // 
            // EmployeeName
            // 
            this.EmployeeName.AspectName = "Name";
            this.EmployeeName.Groupable = false;
            this.EmployeeName.IsEditable = false;
            this.EmployeeName.Text = "Navn";
            // 
            // EmployeeSkills
            // 
            this.EmployeeSkills.AspectName = "Skills";
            this.EmployeeSkills.FillsFreeSpace = true;
            this.EmployeeSkills.Groupable = false;
            this.EmployeeSkills.Text = "Færdigheder";
            // 
            // _availableEmployeesOLV
            // 
            this._availableEmployeesOLV.AllColumns.Add(this.AvailableEmployeeName);
            this._availableEmployeesOLV.AllColumns.Add(this.AvailableEmployeeSkills);
            this._availableEmployeesOLV.CellEditUseWholeCell = false;
            this._availableEmployeesOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AvailableEmployeeName,
            this.AvailableEmployeeSkills});
            this._availableEmployeesOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._availableEmployeesOLV.FullRowSelect = true;
            this._availableEmployeesOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._availableEmployeesOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._availableEmployeesOLV.Location = new System.Drawing.Point(256, 31);
            this._availableEmployeesOLV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._availableEmployeesOLV.Name = "_availableEmployeesOLV";
            this._availableEmployeesOLV.Size = new System.Drawing.Size(194, 255);
            this._availableEmployeesOLV.TabIndex = 4;
            this._availableEmployeesOLV.UseCompatibleStateImageBehavior = false;
            this._availableEmployeesOLV.UseFiltering = true;
            this._availableEmployeesOLV.View = System.Windows.Forms.View.Details;
            this._availableEmployeesOLV.SelectionChanged += new System.EventHandler(this._availableEmployeesOLV_SelectionChanged);
            // 
            // AvailableEmployeeName
            // 
            this.AvailableEmployeeName.AspectName = "Name";
            this.AvailableEmployeeName.Groupable = false;
            this.AvailableEmployeeName.IsEditable = false;
            this.AvailableEmployeeName.Text = "Navn";
            // 
            // AvailableEmployeeSkills
            // 
            this.AvailableEmployeeSkills.AspectName = "Skills";
            this.AvailableEmployeeSkills.FillsFreeSpace = true;
            this.AvailableEmployeeSkills.Groupable = false;
            this.AvailableEmployeeSkills.Text = "Færdigheder";
            // 
            // _filterTextBox
            // 
            this._filterTextBox.Location = new System.Drawing.Point(40, 290);
            this._filterTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(158, 20);
            this._filterTextBox.TabIndex = 6;
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "På projektet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ledige";
            // 
            // _employeesGroupBox
            // 
            this._employeesGroupBox.Controls.Add(this._cancelButton);
            this._employeesGroupBox.Controls.Add(this._saveButton);
            this._employeesGroupBox.Controls.Add(this.label4);
            this._employeesGroupBox.Controls.Add(this.label3);
            this._employeesGroupBox.Controls.Add(this.label2);
            this._employeesGroupBox.Controls.Add(this._filterTextBox);
            this._employeesGroupBox.Controls.Add(this._availableEmployeesOLV);
            this._employeesGroupBox.Controls.Add(this._employeesOLV);
            this._employeesGroupBox.Controls.Add(this._employeeAddButton);
            this._employeesGroupBox.Controls.Add(this._employeeRemoveButton);
            this._employeesGroupBox.Location = new System.Drawing.Point(9, 25);
            this._employeesGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._employeesGroupBox.Name = "_employeesGroupBox";
            this._employeesGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._employeesGroupBox.Size = new System.Drawing.Size(454, 318);
            this._employeesGroupBox.TabIndex = 4;
            this._employeesGroupBox.TabStop = false;
            this._employeesGroupBox.Text = "Ansatte";
            // 
            // _cancelButton
            // 
            this._cancelButton.AutoSize = true;
            this._cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._cancelButton.Location = new System.Drawing.Point(356, 290);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(55, 23);
            this._cancelButton.TabIndex = 12;
            this._cancelButton.Text = "Annuller";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.AutoSize = true;
            this._saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._saveButton.Location = new System.Drawing.Point(413, 290);
            this._saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(39, 23);
            this._saveButton.TabIndex = 11;
            this._saveButton.Text = "Gem";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statistikToolStripMenuItem,
            this._helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forbrugToolStripMenuItem});
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.statistikToolStripMenuItem.Text = "Statistik";
            // 
            // forbrugToolStripMenuItem
            // 
            this.forbrugToolStripMenuItem.Name = "forbrugToolStripMenuItem";
            this.forbrugToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.forbrugToolStripMenuItem.Text = "Forbrug";
            this.forbrugToolStripMenuItem.Click += new System.EventHandler(this.forbrugToolStripMenuItem_Click);
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this._helpToolStripMenuItem.Text = "Hælp";
            this._helpToolStripMenuItem.Click += new System.EventHandler(this._helpToolStripMenuItem_Click);
            // 
            // ProjectManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 352);
            this.Controls.Add(this._employeesGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProjectManagementForm";
            this.Text = "Projektstyrelse";
            this.Load += new System.EventHandler(this.ProjectManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._employeesOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._availableEmployeesOLV)).EndInit();
            this._employeesGroupBox.ResumeLayout(false);
            this._employeesGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _employeeRemoveButton;
        private System.Windows.Forms.Button _employeeAddButton;
        private BrightIdeasSoftware.ObjectListView _employeesOLV;
        private BrightIdeasSoftware.OLVColumn EmployeeName;
        private BrightIdeasSoftware.ObjectListView _availableEmployeesOLV;
        private BrightIdeasSoftware.OLVColumn AvailableEmployeeName;
        private System.Windows.Forms.TextBox _filterTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox _employeesGroupBox;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forbrugToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn EmployeeSkills;
        private BrightIdeasSoftware.OLVColumn AvailableEmployeeSkills;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
    }
}