namespace Raunstrup.Forms
{
    partial class SkillSelectForm
    {
        /// <summary>
        /// Required designer variable. Commit this please
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Materiale", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Arbejdstime", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Transport", System.Windows.Forms.HorizontalAlignment.Left);
            this._deleteSkillButton = new System.Windows.Forms.Button();
            this._editSkillButton = new System.Windows.Forms.Button();
            this._createNewSkillButton = new System.Windows.Forms.Button();
            this._skillsListView = new System.Windows.Forms.ListView();
            this.Skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _deleteSkillButton
            // 
            this._deleteSkillButton.Location = new System.Drawing.Point(174, 201);
            this._deleteSkillButton.Name = "_deleteSkillButton";
            this._deleteSkillButton.Size = new System.Drawing.Size(75, 23);
            this._deleteSkillButton.TabIndex = 7;
            this._deleteSkillButton.Text = "Slet";
            this._deleteSkillButton.UseVisualStyleBackColor = true;
            this._deleteSkillButton.Click += new System.EventHandler(this._deleteSkillButton_Click);
            // 
            // _editSkillButton
            // 
            this._editSkillButton.Location = new System.Drawing.Point(93, 201);
            this._editSkillButton.Name = "_editSkillButton";
            this._editSkillButton.Size = new System.Drawing.Size(75, 23);
            this._editSkillButton.TabIndex = 6;
            this._editSkillButton.Text = "Rediger";
            this._editSkillButton.UseVisualStyleBackColor = true;
            this._editSkillButton.Click += new System.EventHandler(this._editSkillButton_Click);
            // 
            // _createNewSkillButton
            // 
            this._createNewSkillButton.Location = new System.Drawing.Point(12, 201);
            this._createNewSkillButton.Name = "_createNewSkillButton";
            this._createNewSkillButton.Size = new System.Drawing.Size(75, 23);
            this._createNewSkillButton.TabIndex = 5;
            this._createNewSkillButton.Text = "Opret ny";
            this._createNewSkillButton.UseVisualStyleBackColor = true;
            this._createNewSkillButton.Click += new System.EventHandler(this._createNewSkillButton_Click);
            // 
            // _skillsListView
            // 
            this._skillsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Skill});
            this._skillsListView.FullRowSelect = true;
            listViewGroup1.Header = "Materiale";
            listViewGroup1.Name = "MaterialGroup";
            listViewGroup2.Header = "Arbejdstime";
            listViewGroup2.Name = "WorkHour";
            listViewGroup3.Header = "Transport";
            listViewGroup3.Name = "Transport";
            this._skillsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this._skillsListView.Location = new System.Drawing.Point(12, 12);
            this._skillsListView.Name = "_skillsListView";
            this._skillsListView.Size = new System.Drawing.Size(237, 183);
            this._skillsListView.TabIndex = 4;
            this._skillsListView.UseCompatibleStateImageBehavior = false;
            this._skillsListView.View = System.Windows.Forms.View.Details;
            // 
            // Skill
            // 
            this.Skill.Text = "Speciale";
            this.Skill.Width = 150;
            // 
            // SkillSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 231);
            this.Controls.Add(this._deleteSkillButton);
            this.Controls.Add(this._editSkillButton);
            this.Controls.Add(this._createNewSkillButton);
            this.Controls.Add(this._skillsListView);
            this.Name = "SkillSelectForm";
            this.Text = "SkillSelectForm";
            this.Load += new System.EventHandler(this.SkillSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _deleteSkillButton;
        private System.Windows.Forms.Button _editSkillButton;
        private System.Windows.Forms.Button _createNewSkillButton;
        private System.Windows.Forms.ListView _skillsListView;
        private System.Windows.Forms.ColumnHeader Skill;
    }
}