namespace Raunstrup.Forms
{
    partial class MainForm
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
            this._projectOLV = new BrightIdeasSoftware.ObjectListView();
            this.ProjectTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProjectDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProjectCustomer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.katalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kundekatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansatteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansatteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.indlæsRapportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._draftOLV = new BrightIdeasSoftware.ObjectListView();
            this.DraftTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DraftDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DraftCustomer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._openDraftButton = new System.Windows.Forms.Button();
            this._createDraftButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._projectOLV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._draftOLV)).BeginInit();
            this.SuspendLayout();
            // 
            // _projectOLV
            // 
            this._projectOLV.AllColumns.Add(this.ProjectTitle);
            this._projectOLV.AllColumns.Add(this.ProjectDate);
            this._projectOLV.AllColumns.Add(this.ProjectCustomer);
            this._projectOLV.CellEditUseWholeCell = false;
            this._projectOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProjectTitle,
            this.ProjectDate,
            this.ProjectCustomer});
            this._projectOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._projectOLV.FullRowSelect = true;
            this._projectOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._projectOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._projectOLV.Location = new System.Drawing.Point(12, 44);
            this._projectOLV.MultiSelect = false;
            this._projectOLV.Name = "_projectOLV";
            this._projectOLV.Size = new System.Drawing.Size(260, 222);
            this._projectOLV.TabIndex = 0;
            this._projectOLV.UseCompatibleStateImageBehavior = false;
            this._projectOLV.View = System.Windows.Forms.View.Details;
            this._projectOLV.SelectedIndexChanged += new System.EventHandler(this._projectOLV_SelectedIndexChanged);
            // 
            // ProjectTitle
            // 
            this.ProjectTitle.AspectName = "Draft.Title";
            this.ProjectTitle.Groupable = false;
            this.ProjectTitle.Text = "Titel";
            // 
            // ProjectDate
            // 
            this.ProjectDate.AspectName = "OrderDate";
            this.ProjectDate.AspectToStringFormat = "{0:d}";
            this.ProjectDate.Groupable = false;
            this.ProjectDate.Text = "Ordredato";
            this.ProjectDate.Width = 90;
            // 
            // ProjectCustomer
            // 
            this.ProjectCustomer.AspectName = "Draft.Customer.Name";
            this.ProjectCustomer.Groupable = false;
            this.ProjectCustomer.Text = "Kunde";
            this.ProjectCustomer.Width = 100;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.katalogToolStripMenuItem,
            this.statistikToolStripMenuItem,
            this.indlæsRapportToolStripMenuItem,
            this._helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(550, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // katalogToolStripMenuItem
            // 
            this.katalogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kundekatalogToolStripMenuItem,
            this.ansatteToolStripMenuItem,
            this.varerToolStripMenuItem});
            this.katalogToolStripMenuItem.Name = "katalogToolStripMenuItem";
            this.katalogToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.katalogToolStripMenuItem.Text = "Kataloger";
            // 
            // kundekatalogToolStripMenuItem
            // 
            this.kundekatalogToolStripMenuItem.Name = "kundekatalogToolStripMenuItem";
            this.kundekatalogToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.kundekatalogToolStripMenuItem.Text = "Kunder";
            this.kundekatalogToolStripMenuItem.Click += new System.EventHandler(this.kundekatalogToolStripMenuItem_Click);
            // 
            // ansatteToolStripMenuItem
            // 
            this.ansatteToolStripMenuItem.Name = "ansatteToolStripMenuItem";
            this.ansatteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.ansatteToolStripMenuItem.Text = "Ansatte";
            this.ansatteToolStripMenuItem.Click += new System.EventHandler(this.ansatteToolStripMenuItem_Click);
            // 
            // varerToolStripMenuItem
            // 
            this.varerToolStripMenuItem.Name = "varerToolStripMenuItem";
            this.varerToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.varerToolStripMenuItem.Text = "Varer";
            this.varerToolStripMenuItem.Click += new System.EventHandler(this.varerToolStripMenuItem_Click);
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansatteToolStripMenuItem1});
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.statistikToolStripMenuItem.Text = "Statistik";
            // 
            // ansatteToolStripMenuItem1
            // 
            this.ansatteToolStripMenuItem1.Name = "ansatteToolStripMenuItem1";
            this.ansatteToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.ansatteToolStripMenuItem1.Text = "Ansatte";
            this.ansatteToolStripMenuItem1.Click += new System.EventHandler(this.ansatteToolStripMenuItem1_Click);
            // 
            // indlæsRapportToolStripMenuItem
            // 
            this.indlæsRapportToolStripMenuItem.Name = "indlæsRapportToolStripMenuItem";
            this.indlæsRapportToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.indlæsRapportToolStripMenuItem.Text = "Indlæs rapport";
            this.indlæsRapportToolStripMenuItem.Click += new System.EventHandler(this.indlæsRapportToolStripMenuItem_Click);
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this._helpToolStripMenuItem.Text = "Hjælp";
            this._helpToolStripMenuItem.Click += new System.EventHandler(this._helpToolStripMenuItem_Click);
            // 
            // _draftOLV
            // 
            this._draftOLV.AllColumns.Add(this.DraftTitle);
            this._draftOLV.AllColumns.Add(this.DraftDate);
            this._draftOLV.AllColumns.Add(this.DraftCustomer);
            this._draftOLV.CellEditUseWholeCell = false;
            this._draftOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DraftTitle,
            this.DraftDate,
            this.DraftCustomer});
            this._draftOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._draftOLV.FullRowSelect = true;
            this._draftOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._draftOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._draftOLV.Location = new System.Drawing.Point(278, 44);
            this._draftOLV.MultiSelect = false;
            this._draftOLV.Name = "_draftOLV";
            this._draftOLV.Size = new System.Drawing.Size(260, 222);
            this._draftOLV.TabIndex = 2;
            this._draftOLV.UseCompatibleStateImageBehavior = false;
            this._draftOLV.View = System.Windows.Forms.View.Details;
            this._draftOLV.SelectedIndexChanged += new System.EventHandler(this._draftOLV_SelectedIndexChanged);
            // 
            // DraftTitle
            // 
            this.DraftTitle.AspectName = "Title";
            this.DraftTitle.Groupable = false;
            this.DraftTitle.Text = "Titel";
            // 
            // DraftDate
            // 
            this.DraftDate.AspectName = "CreationDate";
            this.DraftDate.AspectToStringFormat = "{0:d}";
            this.DraftDate.Groupable = false;
            this.DraftDate.Text = "Oprettelsesdato";
            this.DraftDate.Width = 90;
            // 
            // DraftCustomer
            // 
            this.DraftCustomer.AspectName = "Customer.Name";
            this.DraftCustomer.Groupable = false;
            this.DraftCustomer.Text = "Kunde";
            this.DraftCustomer.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projekter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kladder";
            // 
            // _openDraftButton
            // 
            this._openDraftButton.Location = new System.Drawing.Point(463, 272);
            this._openDraftButton.Name = "_openDraftButton";
            this._openDraftButton.Size = new System.Drawing.Size(75, 23);
            this._openDraftButton.TabIndex = 5;
            this._openDraftButton.Text = "Åben";
            this._openDraftButton.UseVisualStyleBackColor = true;
            this._openDraftButton.Click += new System.EventHandler(this._openDraftButton_Click);
            // 
            // _createDraftButton
            // 
            this._createDraftButton.Location = new System.Drawing.Point(382, 272);
            this._createDraftButton.Name = "_createDraftButton";
            this._createDraftButton.Size = new System.Drawing.Size(75, 23);
            this._createDraftButton.TabIndex = 7;
            this._createDraftButton.Text = "Opret";
            this._createDraftButton.UseVisualStyleBackColor = true;
            this._createDraftButton.Click += new System.EventHandler(this._createDraftButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 303);
            this.Controls.Add(this._createDraftButton);
            this.Controls.Add(this._openDraftButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._draftOLV);
            this.Controls.Add(this._projectOLV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Raunstrup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._projectOLV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._draftOLV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView _projectOLV;
        private BrightIdeasSoftware.OLVColumn ProjectTitle;
        private BrightIdeasSoftware.OLVColumn ProjectDate;
        private BrightIdeasSoftware.OLVColumn ProjectCustomer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem katalogToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView _draftOLV;
        private BrightIdeasSoftware.OLVColumn DraftTitle;
        private BrightIdeasSoftware.OLVColumn DraftDate;
        private BrightIdeasSoftware.OLVColumn DraftCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _openDraftButton;
        private System.Windows.Forms.Button _createDraftButton;
        private System.Windows.Forms.ToolStripMenuItem kundekatalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansatteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansatteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem varerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indlæsRapportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
    }
}