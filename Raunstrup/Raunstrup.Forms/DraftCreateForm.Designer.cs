namespace Raunstrup.Forms
{
    partial class DraftCreateForm
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
            this._draftTitleLabel = new System.Windows.Forms.Label();
            this._customerComboBox = new System.Windows.Forms.ComboBox();
            this._draftTitleTextBox = new System.Windows.Forms.TextBox();
            this._draftOrderLineOLV = new BrightIdeasSoftware.ObjectListView();
            this._draftDescriptionTextBox = new System.Windows.Forms.TextBox();
            this._draftDescriptionLabel = new System.Windows.Forms.Label();
            this._startDateLabel = new System.Windows.Forms.Label();
            this._startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._endDateLabel = new System.Windows.Forms.Label();
            this._discountInPercentLabel = new System.Windows.Forms.Label();
            this._productOLV = new BrightIdeasSoftware.ObjectListView();
            this.ProductName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProductPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._addToDraftOrderLineOLV = new System.Windows.Forms.Button();
            this._removeFromDraftOrderLineOLV = new System.Windows.Forms.Button();
            this._customerLabel = new System.Windows.Forms.Label();
            this._saveDraftButton = new System.Windows.Forms.Button();
            this._discountInPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._draftOrderLineOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._productOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._discountInPercentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _draftTitleLabel
            // 
            this._draftTitleLabel.AutoSize = true;
            this._draftTitleLabel.Location = new System.Drawing.Point(11, 42);
            this._draftTitleLabel.Name = "_draftTitleLabel";
            this._draftTitleLabel.Size = new System.Drawing.Size(66, 13);
            this._draftTitleLabel.TabIndex = 0;
            this._draftTitleLabel.Text = "Tilbuds titel: ";
            // 
            // _customerComboBox
            // 
            this._customerComboBox.FormattingEnabled = true;
            this._customerComboBox.Location = new System.Drawing.Point(83, 12);
            this._customerComboBox.Name = "_customerComboBox";
            this._customerComboBox.Size = new System.Drawing.Size(134, 21);
            this._customerComboBox.TabIndex = 1;
            // 
            // _draftTitleTextBox
            // 
            this._draftTitleTextBox.Location = new System.Drawing.Point(83, 39);
            this._draftTitleTextBox.Name = "_draftTitleTextBox";
            this._draftTitleTextBox.Size = new System.Drawing.Size(134, 20);
            this._draftTitleTextBox.TabIndex = 2;
            // 
            // _draftOrderLineOLV
            // 
            this._draftOrderLineOLV.CellEditUseWholeCell = false;
            this._draftOrderLineOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._draftOrderLineOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._draftOrderLineOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._draftOrderLineOLV.Location = new System.Drawing.Point(232, 12);
            this._draftOrderLineOLV.Name = "_draftOrderLineOLV";
            this._draftOrderLineOLV.Size = new System.Drawing.Size(256, 180);
            this._draftOrderLineOLV.TabIndex = 3;
            this._draftOrderLineOLV.UseCompatibleStateImageBehavior = false;
            this._draftOrderLineOLV.View = System.Windows.Forms.View.Details;
            // 
            // _draftDescriptionTextBox
            // 
            this._draftDescriptionTextBox.Location = new System.Drawing.Point(83, 65);
            this._draftDescriptionTextBox.Multiline = true;
            this._draftDescriptionTextBox.Name = "_draftDescriptionTextBox";
            this._draftDescriptionTextBox.Size = new System.Drawing.Size(134, 20);
            this._draftDescriptionTextBox.TabIndex = 5;
            // 
            // _draftDescriptionLabel
            // 
            this._draftDescriptionLabel.AutoSize = true;
            this._draftDescriptionLabel.Location = new System.Drawing.Point(11, 68);
            this._draftDescriptionLabel.Name = "_draftDescriptionLabel";
            this._draftDescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this._draftDescriptionLabel.TabIndex = 4;
            this._draftDescriptionLabel.Text = "Beskrivelse: ";
            // 
            // _startDateLabel
            // 
            this._startDateLabel.AutoSize = true;
            this._startDateLabel.Location = new System.Drawing.Point(11, 94);
            this._startDateLabel.Name = "_startDateLabel";
            this._startDateLabel.Size = new System.Drawing.Size(59, 13);
            this._startDateLabel.TabIndex = 6;
            this._startDateLabel.Text = "Start dato: ";
            // 
            // _startDateDateTimePicker
            // 
            this._startDateDateTimePicker.Location = new System.Drawing.Point(83, 91);
            this._startDateDateTimePicker.Name = "_startDateDateTimePicker";
            this._startDateDateTimePicker.Size = new System.Drawing.Size(134, 20);
            this._startDateDateTimePicker.TabIndex = 7;
            // 
            // _endDateDateTimePicker
            // 
            this._endDateDateTimePicker.Location = new System.Drawing.Point(83, 117);
            this._endDateDateTimePicker.Name = "_endDateDateTimePicker";
            this._endDateDateTimePicker.Size = new System.Drawing.Size(134, 20);
            this._endDateDateTimePicker.TabIndex = 9;
            // 
            // _endDateLabel
            // 
            this._endDateLabel.AutoSize = true;
            this._endDateLabel.Location = new System.Drawing.Point(11, 120);
            this._endDateLabel.Name = "_endDateLabel";
            this._endDateLabel.Size = new System.Drawing.Size(55, 13);
            this._endDateLabel.TabIndex = 8;
            this._endDateLabel.Text = "Slut dato: ";
            // 
            // _discountInPercentLabel
            // 
            this._discountInPercentLabel.AutoSize = true;
            this._discountInPercentLabel.Location = new System.Drawing.Point(11, 146);
            this._discountInPercentLabel.Name = "_discountInPercentLabel";
            this._discountInPercentLabel.Size = new System.Drawing.Size(50, 13);
            this._discountInPercentLabel.TabIndex = 10;
            this._discountInPercentLabel.Text = "Rabat % ";
            // 
            // _productOLV
            // 
            this._productOLV.AllColumns.Add(this.ProductName);
            this._productOLV.AllColumns.Add(this.ProductPrice);
            this._productOLV.CellEditUseWholeCell = false;
            this._productOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductName,
            this.ProductPrice});
            this._productOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this._productOLV.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this._productOLV.HighlightForegroundColor = System.Drawing.Color.Empty;
            this._productOLV.Location = new System.Drawing.Point(565, 12);
            this._productOLV.Name = "_productOLV";
            this._productOLV.Size = new System.Drawing.Size(256, 180);
            this._productOLV.TabIndex = 12;
            this._productOLV.UseCompatibleStateImageBehavior = false;
            this._productOLV.View = System.Windows.Forms.View.Details;
            // 
            // ProductName
            // 
            this.ProductName.AspectName = "Name";
            this.ProductName.Groupable = false;
            this.ProductName.Text = "Vare";
            this.ProductName.Width = 176;
            // 
            // ProductPrice
            // 
            this.ProductPrice.AspectName = "SalesPrice";
            this.ProductPrice.AspectToStringFormat = "{0:c}";
            this.ProductPrice.Groupable = false;
            this.ProductPrice.Text = "Pris";
            this.ProductPrice.Width = 80;
            // 
            // _addToDraftOrderLineOLV
            // 
            this._addToDraftOrderLineOLV.Location = new System.Drawing.Point(494, 71);
            this._addToDraftOrderLineOLV.Name = "_addToDraftOrderLineOLV";
            this._addToDraftOrderLineOLV.Size = new System.Drawing.Size(64, 23);
            this._addToDraftOrderLineOLV.TabIndex = 13;
            this._addToDraftOrderLineOLV.Text = "<-- Tilføj";
            this._addToDraftOrderLineOLV.UseVisualStyleBackColor = true;
            // 
            // _removeFromDraftOrderLineOLV
            // 
            this._removeFromDraftOrderLineOLV.Location = new System.Drawing.Point(494, 100);
            this._removeFromDraftOrderLineOLV.Name = "_removeFromDraftOrderLineOLV";
            this._removeFromDraftOrderLineOLV.Size = new System.Drawing.Size(64, 23);
            this._removeFromDraftOrderLineOLV.TabIndex = 14;
            this._removeFromDraftOrderLineOLV.Text = "Fjern";
            this._removeFromDraftOrderLineOLV.UseVisualStyleBackColor = true;
            // 
            // _customerLabel
            // 
            this._customerLabel.AutoSize = true;
            this._customerLabel.Location = new System.Drawing.Point(11, 15);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(44, 13);
            this._customerLabel.TabIndex = 15;
            this._customerLabel.Text = "Kunde: ";
            // 
            // _saveDraftButton
            // 
            this._saveDraftButton.Location = new System.Drawing.Point(153, 169);
            this._saveDraftButton.Name = "_saveDraftButton";
            this._saveDraftButton.Size = new System.Drawing.Size(64, 23);
            this._saveDraftButton.TabIndex = 16;
            this._saveDraftButton.Text = "Opret";
            this._saveDraftButton.UseVisualStyleBackColor = true;
            this._saveDraftButton.Click += new System.EventHandler(this._saveDraftButton_Click);
            // 
            // _discountInPercentNumericUpDown
            // 
            this._discountInPercentNumericUpDown.Location = new System.Drawing.Point(83, 143);
            this._discountInPercentNumericUpDown.Name = "_discountInPercentNumericUpDown";
            this._discountInPercentNumericUpDown.Size = new System.Drawing.Size(134, 20);
            this._discountInPercentNumericUpDown.TabIndex = 17;
            this._discountInPercentNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DraftCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 203);
            this.Controls.Add(this._discountInPercentNumericUpDown);
            this.Controls.Add(this._saveDraftButton);
            this.Controls.Add(this._customerLabel);
            this.Controls.Add(this._removeFromDraftOrderLineOLV);
            this.Controls.Add(this._addToDraftOrderLineOLV);
            this.Controls.Add(this._productOLV);
            this.Controls.Add(this._discountInPercentLabel);
            this.Controls.Add(this._endDateDateTimePicker);
            this.Controls.Add(this._endDateLabel);
            this.Controls.Add(this._startDateDateTimePicker);
            this.Controls.Add(this._startDateLabel);
            this.Controls.Add(this._draftDescriptionTextBox);
            this.Controls.Add(this._draftDescriptionLabel);
            this.Controls.Add(this._draftOrderLineOLV);
            this.Controls.Add(this._draftTitleTextBox);
            this.Controls.Add(this._customerComboBox);
            this.Controls.Add(this._draftTitleLabel);
            this.Name = "DraftCreateForm";
            this.Text = "DraftCreateForm";
            this.Load += new System.EventHandler(this.DraftCreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._draftOrderLineOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._productOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._discountInPercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _draftTitleLabel;
        private System.Windows.Forms.ComboBox _customerComboBox;
        private System.Windows.Forms.TextBox _draftTitleTextBox;
        private BrightIdeasSoftware.ObjectListView _draftOrderLineOLV;
        private System.Windows.Forms.TextBox _draftDescriptionTextBox;
        private System.Windows.Forms.Label _draftDescriptionLabel;
        private System.Windows.Forms.Label _startDateLabel;
        private System.Windows.Forms.DateTimePicker _startDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker _endDateDateTimePicker;
        private System.Windows.Forms.Label _endDateLabel;
        private System.Windows.Forms.Label _discountInPercentLabel;
        private BrightIdeasSoftware.ObjectListView _productOLV;
        private System.Windows.Forms.Button _addToDraftOrderLineOLV;
        private System.Windows.Forms.Button _removeFromDraftOrderLineOLV;
        private System.Windows.Forms.Label _customerLabel;
        private BrightIdeasSoftware.OLVColumn ProductName;
        private BrightIdeasSoftware.OLVColumn ProductPrice;
        private System.Windows.Forms.Button _saveDraftButton;
        private System.Windows.Forms.NumericUpDown _discountInPercentNumericUpDown;
    }
}