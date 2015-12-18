namespace Raunstrup.Forms
{
    partial class EmployeeCRUDForm
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
            this._employeeNameLabel = new System.Windows.Forms.Label();
            this._employeeComboBox = new System.Windows.Forms.ComboBox();
            this._employeeNameTextBox = new System.Windows.Forms.TextBox();
            this._skillOLV = new BrightIdeasSoftware.ObjectListView();
            this.Skill = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._addEmployeeToSkillLVButton = new System.Windows.Forms.Button();
            this._removeFromEmployeeSkillLV = new System.Windows.Forms.Button();
            this._customerLabel = new System.Windows.Forms.Label();
            this._saveEmployeeButton = new System.Windows.Forms.Button();
            this._employeeSkillsLV = new System.Windows.Forms.ListView();
            this.EmployeeSkills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._filterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._createNewEmployeeRadioButton = new System.Windows.Forms.RadioButton();
            this._editEmployeeRadioButton = new System.Windows.Forms.RadioButton();
            this._deleteEmployeeButton = new System.Windows.Forms.Button();
            this._editSkillButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._skillOLV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _employeeNameLabel
            // 
            this._employeeNameLabel.AutoSize = true;
            this._employeeNameLabel.Location = new System.Drawing.Point(14, 104);
            this._employeeNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._employeeNameLabel.Name = "_employeeNameLabel";
            this._employeeNameLabel.Size = new System.Drawing.Size(49, 17);
            this._employeeNameLabel.TabIndex = 0;
            this._employeeNameLabel.Text = "Navn: ";
            // 
            // _employeeComboBox
            // 
            this._employeeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._employeeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._employeeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._employeeComboBox.FormattingEnabled = true;
            this._employeeComboBox.Location = new System.Drawing.Point(75, 33);
            this._employeeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._employeeComboBox.Name = "_employeeComboBox";
            this._employeeComboBox.Size = new System.Drawing.Size(177, 24);
            this._employeeComboBox.TabIndex = 1;
            this._employeeComboBox.SelectedIndexChanged += new System.EventHandler(this._employeeComboBox_SelectedIndexChanged);
            // 
            // _employeeNameTextBox
            // 
            this._employeeNameTextBox.Location = new System.Drawing.Point(75, 101);
            this._employeeNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._employeeNameTextBox.Name = "_employeeNameTextBox";
            this._employeeNameTextBox.Size = new System.Drawing.Size(177, 22);
            this._employeeNameTextBox.TabIndex = 2;
            // 
            // _skillOLV
            // 
            this._skillOLV.AllColumns.Add(this.Skill);
            this._skillOLV.CellEditUseWholeCell = false;
            this._skillOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Skill});
            this._skillOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._skillOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._skillOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._skillOLV.Location = new System.Drawing.Point(586, 32);
            this._skillOLV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._skillOLV.Name = "_skillOLV";
            this._skillOLV.Size = new System.Drawing.Size(233, 158);
            this._skillOLV.TabIndex = 12;
            this._skillOLV.UseCompatibleStateImageBehavior = false;
            this._skillOLV.View = System.Windows.Forms.View.Details;
            // 
            // Skill
            // 
            this.Skill.AspectName = "Name";
            this.Skill.Groupable = false;
            this.Skill.Text = "Alle specialer";
            this.Skill.Width = 150;
            // 
            // _addEmployeeToSkillLVButton
            // 
            this._addEmployeeToSkillLVButton.Location = new System.Drawing.Point(492, 66);
            this._addEmployeeToSkillLVButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._addEmployeeToSkillLVButton.Name = "_addEmployeeToSkillLVButton";
            this._addEmployeeToSkillLVButton.Size = new System.Drawing.Size(85, 28);
            this._addEmployeeToSkillLVButton.TabIndex = 13;
            this._addEmployeeToSkillLVButton.Text = "<-- Tilføj";
            this._addEmployeeToSkillLVButton.UseVisualStyleBackColor = true;
            this._addEmployeeToSkillLVButton.Click += new System.EventHandler(this._addEmployeeSkillLV_Click);
            // 
            // _removeFromEmployeeSkillLV
            // 
            this._removeFromEmployeeSkillLV.Location = new System.Drawing.Point(492, 102);
            this._removeFromEmployeeSkillLV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._removeFromEmployeeSkillLV.Name = "_removeFromEmployeeSkillLV";
            this._removeFromEmployeeSkillLV.Size = new System.Drawing.Size(85, 28);
            this._removeFromEmployeeSkillLV.TabIndex = 14;
            this._removeFromEmployeeSkillLV.Text = "Fjern";
            this._removeFromEmployeeSkillLV.UseVisualStyleBackColor = true;
            this._removeFromEmployeeSkillLV.Click += new System.EventHandler(this._removeFromEmployeeSkillLV_Click);
            // 
            // _customerLabel
            // 
            this._customerLabel.AutoSize = true;
            this._customerLabel.Location = new System.Drawing.Point(14, 35);
            this._customerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(52, 17);
            this._customerLabel.TabIndex = 15;
            this._customerLabel.Text = "Ansat: ";
            // 
            // _saveEmployeeButton
            // 
            this._saveEmployeeButton.Location = new System.Drawing.Point(59, 193);
            this._saveEmployeeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._saveEmployeeButton.Name = "_saveEmployeeButton";
            this._saveEmployeeButton.Size = new System.Drawing.Size(93, 28);
            this._saveEmployeeButton.TabIndex = 16;
            this._saveEmployeeButton.Text = "Gem ansat";
            this._saveEmployeeButton.UseVisualStyleBackColor = true;
            this._saveEmployeeButton.Click += new System.EventHandler(this._saveEmployeeButton_Click);
            // 
            // _employeeSkillsLV
            // 
            this._employeeSkillsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EmployeeSkills});
            this._employeeSkillsLV.FullRowSelect = true;
            this._employeeSkillsLV.Location = new System.Drawing.Point(262, 32);
            this._employeeSkillsLV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._employeeSkillsLV.MultiSelect = false;
            this._employeeSkillsLV.Name = "_employeeSkillsLV";
            this._employeeSkillsLV.Size = new System.Drawing.Size(221, 189);
            this._employeeSkillsLV.TabIndex = 20;
            this._employeeSkillsLV.UseCompatibleStateImageBehavior = false;
            this._employeeSkillsLV.View = System.Windows.Forms.View.Details;
            // 
            // EmployeeSkills
            // 
            this.EmployeeSkills.Tag = "";
            this.EmployeeSkills.Text = "Speciale";
            this.EmployeeSkills.Width = 80;
            // 
            // _filterTextBox
            // 
            this._filterTextBox.Location = new System.Drawing.Point(642, 198);
            this._filterTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(177, 22);
            this._filterTextBox.TabIndex = 29;
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Søg: ";
            // 
            // _createNewEmployeeRadioButton
            // 
            this._createNewEmployeeRadioButton.AutoSize = true;
            this._createNewEmployeeRadioButton.Location = new System.Drawing.Point(18, 66);
            this._createNewEmployeeRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._createNewEmployeeRadioButton.Name = "_createNewEmployeeRadioButton";
            this._createNewEmployeeRadioButton.Size = new System.Drawing.Size(84, 21);
            this._createNewEmployeeRadioButton.TabIndex = 30;
            this._createNewEmployeeRadioButton.TabStop = true;
            this._createNewEmployeeRadioButton.Text = "Opret ny";
            this._createNewEmployeeRadioButton.UseVisualStyleBackColor = true;
            this._createNewEmployeeRadioButton.CheckedChanged += new System.EventHandler(this._createNewEmployeeRadioButton_CheckedChanged);
            // 
            // _editEmployeeRadioButton
            // 
            this._editEmployeeRadioButton.AutoSize = true;
            this._editEmployeeRadioButton.Location = new System.Drawing.Point(146, 66);
            this._editEmployeeRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._editEmployeeRadioButton.Name = "_editEmployeeRadioButton";
            this._editEmployeeRadioButton.Size = new System.Drawing.Size(79, 21);
            this._editEmployeeRadioButton.TabIndex = 31;
            this._editEmployeeRadioButton.TabStop = true;
            this._editEmployeeRadioButton.Text = "Rediger";
            this._editEmployeeRadioButton.UseVisualStyleBackColor = true;
            this._editEmployeeRadioButton.CheckedChanged += new System.EventHandler(this._editEmployeeRadioButton_CheckedChanged);
            // 
            // _deleteEmployeeButton
            // 
            this._deleteEmployeeButton.Location = new System.Drawing.Point(160, 193);
            this._deleteEmployeeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._deleteEmployeeButton.Name = "_deleteEmployeeButton";
            this._deleteEmployeeButton.Size = new System.Drawing.Size(93, 28);
            this._deleteEmployeeButton.TabIndex = 32;
            this._deleteEmployeeButton.Text = "Slet";
            this._deleteEmployeeButton.UseVisualStyleBackColor = true;
            this._deleteEmployeeButton.Click += new System.EventHandler(this._deleteEmployeeButton_Click);
            // 
            // _editSkillButton
            // 
            this._editSkillButton.Location = new System.Drawing.Point(492, 138);
            this._editSkillButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._editSkillButton.Name = "_editSkillButton";
            this._editSkillButton.Size = new System.Drawing.Size(85, 28);
            this._editSkillButton.TabIndex = 33;
            this._editSkillButton.Text = "Rediger";
            this._editSkillButton.UseVisualStyleBackColor = true;
            this._editSkillButton.Click += new System.EventHandler(this._editSkillButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 28);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this._helpToolStripMenuItem.Text = "Hjælp";
            this._helpToolStripMenuItem.Click += new System.EventHandler(this._helpToolStripMenuItem_Click);
            // 
            // EmployeeCRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 236);
            this.Controls.Add(this._editSkillButton);
            this.Controls.Add(this._deleteEmployeeButton);
            this.Controls.Add(this._editEmployeeRadioButton);
            this.Controls.Add(this._createNewEmployeeRadioButton);
            this.Controls.Add(this._filterTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._employeeSkillsLV);
            this.Controls.Add(this._saveEmployeeButton);
            this.Controls.Add(this._customerLabel);
            this.Controls.Add(this._removeFromEmployeeSkillLV);
            this.Controls.Add(this._addEmployeeToSkillLVButton);
            this.Controls.Add(this._skillOLV);
            this.Controls.Add(this._employeeNameTextBox);
            this.Controls.Add(this._employeeComboBox);
            this.Controls.Add(this._employeeNameLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EmployeeCRUDForm";
            this.Text = "EmployeeCRUDForm";
            this.Load += new System.EventHandler(this.EmployeeCRUDForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._skillOLV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _employeeNameLabel;
        private System.Windows.Forms.ComboBox _employeeComboBox;
        private System.Windows.Forms.TextBox _employeeNameTextBox;
        private BrightIdeasSoftware.ObjectListView _skillOLV;
        private System.Windows.Forms.Button _addEmployeeToSkillLVButton;
        private System.Windows.Forms.Button _removeFromEmployeeSkillLV;
        private System.Windows.Forms.Label _customerLabel;
        private BrightIdeasSoftware.OLVColumn Skill;
        private System.Windows.Forms.Button _saveEmployeeButton;
        private System.Windows.Forms.ListView _employeeSkillsLV;
        private System.Windows.Forms.ColumnHeader EmployeeSkills;
        private System.Windows.Forms.TextBox _filterTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton _createNewEmployeeRadioButton;
        private System.Windows.Forms.RadioButton _editEmployeeRadioButton;
        private System.Windows.Forms.Button _deleteEmployeeButton;
        private System.Windows.Forms.Button _editSkillButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
    }
}