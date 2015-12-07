﻿namespace Raunstrup.Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this._employeeComboBox = new System.Windows.Forms.ComboBox();
            this._draftProductsLV = new System.Windows.Forms.ListView();
            this.Varer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._editOrderLineButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._productOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._discountInPercentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._quantityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _draftTitleLabel
            // 
            this._draftTitleLabel.AutoSize = true;
            this._draftTitleLabel.Location = new System.Drawing.Point(11, 71);
            this._draftTitleLabel.Name = "_draftTitleLabel";
            this._draftTitleLabel.Size = new System.Drawing.Size(66, 13);
            this._draftTitleLabel.TabIndex = 0;
            this._draftTitleLabel.Text = "Tilbuds titel: ";
            // 
            // _customerComboBox
            // 
            this._customerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._customerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._customerComboBox.FormattingEnabled = true;
            this._customerComboBox.Location = new System.Drawing.Point(110, 12);
            this._customerComboBox.Name = "_customerComboBox";
            this._customerComboBox.Size = new System.Drawing.Size(134, 21);
            this._customerComboBox.TabIndex = 1;
            this._customerComboBox.SelectedIndexChanged += new System.EventHandler(this._customerComboBox_SelectedIndexChanged);
            // 
            // _draftTitleTextBox
            // 
            this._draftTitleTextBox.Location = new System.Drawing.Point(110, 68);
            this._draftTitleTextBox.Name = "_draftTitleTextBox";
            this._draftTitleTextBox.Size = new System.Drawing.Size(134, 20);
            this._draftTitleTextBox.TabIndex = 2;
            // 
            // _draftDescriptionTextBox
            // 
            this._draftDescriptionTextBox.Location = new System.Drawing.Point(110, 94);
            this._draftDescriptionTextBox.Multiline = true;
            this._draftDescriptionTextBox.Name = "_draftDescriptionTextBox";
            this._draftDescriptionTextBox.Size = new System.Drawing.Size(134, 20);
            this._draftDescriptionTextBox.TabIndex = 5;
            // 
            // _draftDescriptionLabel
            // 
            this._draftDescriptionLabel.AutoSize = true;
            this._draftDescriptionLabel.Location = new System.Drawing.Point(11, 97);
            this._draftDescriptionLabel.Name = "_draftDescriptionLabel";
            this._draftDescriptionLabel.Size = new System.Drawing.Size(67, 13);
            this._draftDescriptionLabel.TabIndex = 4;
            this._draftDescriptionLabel.Text = "Beskrivelse: ";
            // 
            // _startDateLabel
            // 
            this._startDateLabel.AutoSize = true;
            this._startDateLabel.Location = new System.Drawing.Point(11, 123);
            this._startDateLabel.Name = "_startDateLabel";
            this._startDateLabel.Size = new System.Drawing.Size(59, 13);
            this._startDateLabel.TabIndex = 6;
            this._startDateLabel.Text = "Start dato: ";
            // 
            // _startDateDateTimePicker
            // 
            this._startDateDateTimePicker.Location = new System.Drawing.Point(110, 120);
            this._startDateDateTimePicker.Name = "_startDateDateTimePicker";
            this._startDateDateTimePicker.Size = new System.Drawing.Size(134, 20);
            this._startDateDateTimePicker.TabIndex = 7;
            this._startDateDateTimePicker.ValueChanged += new System.EventHandler(this._startDateDateTimePicker_ValueChanged);
            // 
            // _endDateDateTimePicker
            // 
            this._endDateDateTimePicker.Location = new System.Drawing.Point(110, 146);
            this._endDateDateTimePicker.Name = "_endDateDateTimePicker";
            this._endDateDateTimePicker.Size = new System.Drawing.Size(134, 20);
            this._endDateDateTimePicker.TabIndex = 9;
            this._endDateDateTimePicker.ValueChanged += new System.EventHandler(this._endDateDateTimePicker_ValueChanged);
            // 
            // _endDateLabel
            // 
            this._endDateLabel.AutoSize = true;
            this._endDateLabel.Location = new System.Drawing.Point(11, 149);
            this._endDateLabel.Name = "_endDateLabel";
            this._endDateLabel.Size = new System.Drawing.Size(55, 13);
            this._endDateLabel.TabIndex = 8;
            this._endDateLabel.Text = "Slut dato: ";
            // 
            // _discountInPercentLabel
            // 
            this._discountInPercentLabel.AutoSize = true;
            this._discountInPercentLabel.Location = new System.Drawing.Point(11, 175);
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
            this._productOLV.Location = new System.Drawing.Point(591, 12);
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
            this.ProductName.Width = 174;
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
            this._addToDraftOrderLineOLV.Location = new System.Drawing.Point(521, 71);
            this._addToDraftOrderLineOLV.Name = "_addToDraftOrderLineOLV";
            this._addToDraftOrderLineOLV.Size = new System.Drawing.Size(64, 23);
            this._addToDraftOrderLineOLV.TabIndex = 13;
            this._addToDraftOrderLineOLV.Text = "<-- Tilføj";
            this._addToDraftOrderLineOLV.UseVisualStyleBackColor = true;
            this._addToDraftOrderLineOLV.Click += new System.EventHandler(this._addToDraftOrderLineOLV_Click);
            // 
            // _removeFromDraftOrderLineOLV
            // 
            this._removeFromDraftOrderLineOLV.Location = new System.Drawing.Point(521, 100);
            this._removeFromDraftOrderLineOLV.Name = "_removeFromDraftOrderLineOLV";
            this._removeFromDraftOrderLineOLV.Size = new System.Drawing.Size(64, 23);
            this._removeFromDraftOrderLineOLV.TabIndex = 14;
            this._removeFromDraftOrderLineOLV.Text = "Fjern";
            this._removeFromDraftOrderLineOLV.UseVisualStyleBackColor = true;
            this._removeFromDraftOrderLineOLV.Click += new System.EventHandler(this._removeFromDraftOrderLineOLV_Click);
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
            this._saveDraftButton.Location = new System.Drawing.Point(180, 198);
            this._saveDraftButton.Name = "_saveDraftButton";
            this._saveDraftButton.Size = new System.Drawing.Size(64, 23);
            this._saveDraftButton.TabIndex = 16;
            this._saveDraftButton.Text = "Gem ordre";
            this._saveDraftButton.UseVisualStyleBackColor = true;
            this._saveDraftButton.Click += new System.EventHandler(this._saveDraftButton_Click);
            // 
            // _discountInPercentNumericUpDown
            // 
            this._discountInPercentNumericUpDown.DecimalPlaces = 2;
            this._discountInPercentNumericUpDown.Location = new System.Drawing.Point(110, 172);
            this._discountInPercentNumericUpDown.Name = "_discountInPercentNumericUpDown";
            this._discountInPercentNumericUpDown.Size = new System.Drawing.Size(134, 20);
            this._discountInPercentNumericUpDown.TabIndex = 17;
            this._discountInPercentNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ansvarshavende: ";
            // 
            // _employeeComboBox
            // 
            this._employeeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._employeeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._employeeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._employeeComboBox.FormattingEnabled = true;
            this._employeeComboBox.Location = new System.Drawing.Point(110, 39);
            this._employeeComboBox.Name = "_employeeComboBox";
            this._employeeComboBox.Size = new System.Drawing.Size(134, 21);
            this._employeeComboBox.TabIndex = 18;
            // 
            // _draftProductsLV
            // 
            this._draftProductsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Varer,
            this.UnitPrice,
            this.Quantity,
            this.TotalPrice});
            this._draftProductsLV.FullRowSelect = true;
            this._draftProductsLV.Location = new System.Drawing.Point(250, 12);
            this._draftProductsLV.MultiSelect = false;
            this._draftProductsLV.Name = "_draftProductsLV";
            this._draftProductsLV.Size = new System.Drawing.Size(265, 180);
            this._draftProductsLV.TabIndex = 20;
            this._draftProductsLV.UseCompatibleStateImageBehavior = false;
            this._draftProductsLV.View = System.Windows.Forms.View.Details;
            this._draftProductsLV.MouseClick += new System.Windows.Forms.MouseEventHandler(this._draftProductsLV_MouseClick);
            // 
            // Varer
            // 
            this.Varer.Tag = "";
            this.Varer.Text = "Vare";
            this.Varer.Width = 80;
            // 
            // UnitPrice
            // 
            this.UnitPrice.Text = "Stk. pris";
            // 
            // Quantity
            // 
            this.Quantity.Text = "Antal";
            this.Quantity.Width = 41;
            // 
            // TotalPrice
            // 
            this.TotalPrice.Text = "Samlet pris";
            this.TotalPrice.Width = 71;
            // 
            // _priceNumericUpDown
            // 
            this._priceNumericUpDown.DecimalPlaces = 2;
            this._priceNumericUpDown.Location = new System.Drawing.Point(283, 200);
            this._priceNumericUpDown.Name = "_priceNumericUpDown";
            this._priceNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this._priceNumericUpDown.TabIndex = 23;
            this._priceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._priceNumericUpDown.ThousandsSeparator = true;
            // 
            // _quantityNumericUpDown
            // 
            this._quantityNumericUpDown.Location = new System.Drawing.Point(390, 200);
            this._quantityNumericUpDown.Name = "_quantityNumericUpDown";
            this._quantityNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this._quantityNumericUpDown.TabIndex = 24;
            this._quantityNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _editOrderLineButton
            // 
            this._editOrderLineButton.Location = new System.Drawing.Point(463, 198);
            this._editOrderLineButton.Name = "_editOrderLineButton";
            this._editOrderLineButton.Size = new System.Drawing.Size(52, 23);
            this._editOrderLineButton.TabIndex = 25;
            this._editOrderLineButton.Text = "Gem";
            this._editOrderLineButton.UseVisualStyleBackColor = true;
            this._editOrderLineButton.Click += new System.EventHandler(this._editOrderLineButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Pris:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Antal:";
            // 
            // DraftCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 229);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._editOrderLineButton);
            this.Controls.Add(this._draftProductsLV);
            this.Controls.Add(this._quantityNumericUpDown);
            this.Controls.Add(this._priceNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._employeeComboBox);
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
            this.Controls.Add(this._draftTitleTextBox);
            this.Controls.Add(this._customerComboBox);
            this.Controls.Add(this._draftTitleLabel);
            this.Name = "DraftCreateForm";
            this.Text = "DraftCreateForm";
            this.Load += new System.EventHandler(this.DraftCreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._productOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._discountInPercentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._quantityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _draftTitleLabel;
        private System.Windows.Forms.ComboBox _customerComboBox;
        private System.Windows.Forms.TextBox _draftTitleTextBox;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _employeeComboBox;
        private System.Windows.Forms.ListView _draftProductsLV;
        private System.Windows.Forms.ColumnHeader UnitPrice;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader TotalPrice;
        private System.Windows.Forms.ColumnHeader Varer;
        private System.Windows.Forms.NumericUpDown _priceNumericUpDown;
        private System.Windows.Forms.NumericUpDown _quantityNumericUpDown;
        private System.Windows.Forms.Button _editOrderLineButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}