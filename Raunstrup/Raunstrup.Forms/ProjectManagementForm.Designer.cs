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
            this._availableEmployeesOLV = new BrightIdeasSoftware.ObjectListView();
            this.AvailableEmployeeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.EmployeeSkills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AvailableEmployeeSkills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this._employeeRemoveButton.Location = new System.Drawing.Point(268, 148);
            this._employeeRemoveButton.Name = "_employeeRemoveButton";
            this._employeeRemoveButton.Size = new System.Drawing.Size(67, 27);
            this._employeeRemoveButton.TabIndex = 2;
            this._employeeRemoveButton.Text = "Fjern ->";
            this._employeeRemoveButton.UseVisualStyleBackColor = true;
            this._employeeRemoveButton.Click += new System.EventHandler(this._employeeRemoveButton_Click);
            // 
            // _employeeAddButton
            // 
            this._employeeAddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._employeeAddButton.Enabled = false;
            this._employeeAddButton.Location = new System.Drawing.Point(268, 115);
            this._employeeAddButton.Name = "_employeeAddButton";
            this._employeeAddButton.Size = new System.Drawing.Size(67, 27);
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
            this._employeesOLV.Location = new System.Drawing.Point(6, 38);
            this._employeesOLV.Name = "_employeesOLV";
            this._employeesOLV.Size = new System.Drawing.Size(256, 313);
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
            this._availableEmployeesOLV.Location = new System.Drawing.Point(341, 38);
            this._availableEmployeesOLV.Name = "_availableEmployeesOLV";
            this._availableEmployeesOLV.Size = new System.Drawing.Size(258, 313);
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
            // _filterTextBox
            // 
            this._filterTextBox.Location = new System.Drawing.Point(53, 357);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(209, 22);
            this._filterTextBox.TabIndex = 6;
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "På projektet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
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
            this._employeesGroupBox.Location = new System.Drawing.Point(12, 31);
            this._employeesGroupBox.Name = "_employeesGroupBox";
            this._employeesGroupBox.Size = new System.Drawing.Size(605, 391);
            this._employeesGroupBox.TabIndex = 4;
            this._employeesGroupBox.TabStop = false;
            this._employeesGroupBox.Text = "Ansatte";
            // 
            // _cancelButton
            // 
            this._cancelButton.AutoSize = true;
            this._cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._cancelButton.Location = new System.Drawing.Point(475, 357);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(70, 27);
            this._cancelButton.TabIndex = 12;
            this._cancelButton.Text = "Annuller";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.AutoSize = true;
            this._saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._saveButton.Location = new System.Drawing.Point(551, 357);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(48, 27);
            this._saveButton.TabIndex = 11;
            this._saveButton.Text = "Gem";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statistikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(630, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forbrugToolStripMenuItem});
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.statistikToolStripMenuItem.Text = "Statistik";
            // 
            // forbrugToolStripMenuItem
            // 
            this.forbrugToolStripMenuItem.Name = "forbrugToolStripMenuItem";
            this.forbrugToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.forbrugToolStripMenuItem.Text = "Forbrug";
            this.forbrugToolStripMenuItem.Click += new System.EventHandler(this.forbrugToolStripMenuItem_Click);
            // 
            // EmployeeSkills
            // 
            this.EmployeeSkills.AspectName = "Skills";
            this.EmployeeSkills.FillsFreeSpace = true;
            this.EmployeeSkills.Groupable = false;
            this.EmployeeSkills.Text = "Færdigheder";
            // 
            // AvailableEmployeeSkills
            // 
            this.AvailableEmployeeSkills.AspectName = "Skills";
            this.AvailableEmployeeSkills.FillsFreeSpace = true;
            this.AvailableEmployeeSkills.Groupable = false;
            this.AvailableEmployeeSkills.Text = "Færdigheder";
            // 
            // ProjectManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 433);
            this.Controls.Add(this._employeesGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProjectManagementForm";
            this.Text = "ProjectManagementForm";
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
    }
}