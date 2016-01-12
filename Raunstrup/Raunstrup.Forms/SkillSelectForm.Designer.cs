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
            this._deleteSkillButton = new System.Windows.Forms.Button();
            this._editSkillButton = new System.Windows.Forms.Button();
            this._createNewSkillButton = new System.Windows.Forms.Button();
            this._skillsListView = new System.Windows.Forms.ListView();
            this.Skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _deleteSkillButton
            // 
            this._deleteSkillButton.Location = new System.Drawing.Point(172, 211);
            this._deleteSkillButton.Name = "_deleteSkillButton";
            this._deleteSkillButton.Size = new System.Drawing.Size(75, 23);
            this._deleteSkillButton.TabIndex = 7;
            this._deleteSkillButton.Text = "Slet";
            this._deleteSkillButton.UseVisualStyleBackColor = true;
            this._deleteSkillButton.Click += new System.EventHandler(this._deleteSkillButton_Click);
            // 
            // _editSkillButton
            // 
            this._editSkillButton.Location = new System.Drawing.Point(91, 211);
            this._editSkillButton.Name = "_editSkillButton";
            this._editSkillButton.Size = new System.Drawing.Size(75, 23);
            this._editSkillButton.TabIndex = 6;
            this._editSkillButton.Text = "Rediger";
            this._editSkillButton.UseVisualStyleBackColor = true;
            this._editSkillButton.Click += new System.EventHandler(this._editSkillButton_Click);
            // 
            // _createNewSkillButton
            // 
            this._createNewSkillButton.Location = new System.Drawing.Point(10, 211);
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
            this._skillsListView.Location = new System.Drawing.Point(10, 23);
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(256, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this._helpToolStripMenuItem.Text = "Hjælp";
            this._helpToolStripMenuItem.Click += new System.EventHandler(this._helpToolStripMenuItem_Click);
            // 
            // SkillSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 245);
            this.Controls.Add(this._deleteSkillButton);
            this.Controls.Add(this._editSkillButton);
            this.Controls.Add(this._createNewSkillButton);
            this.Controls.Add(this._skillsListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SkillSelectForm";
            this.Text = "Specialer";
            this.Load += new System.EventHandler(this.SkillSelectForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _deleteSkillButton;
        private System.Windows.Forms.Button _editSkillButton;
        private System.Windows.Forms.Button _createNewSkillButton;
        private System.Windows.Forms.ListView _skillsListView;
        private System.Windows.Forms.ColumnHeader Skill;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
    }
}