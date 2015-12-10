namespace Raunstrup.Forms
{
    partial class ProductCRUDForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._productNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._productPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._materialRadioButton = new System.Windows.Forms.RadioButton();
            this._workHourRadioButton = new System.Windows.Forms.RadioButton();
            this._transportRadioButton = new System.Windows.Forms.RadioButton();
            this._saveProductButton = new System.Windows.Forms.Button();
            this._costPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._costPriceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._productPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._costPriceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Navn: ";
            // 
            // _productNameTextBox
            // 
            this._productNameTextBox.Location = new System.Drawing.Point(83, 12);
            this._productNameTextBox.Name = "_productNameTextBox";
            this._productNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._productNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pris: ";
            // 
            // _productPriceNumericUpDown
            // 
            this._productPriceNumericUpDown.DecimalPlaces = 2;
            this._productPriceNumericUpDown.Location = new System.Drawing.Point(83, 37);
            this._productPriceNumericUpDown.Name = "_productPriceNumericUpDown";
            this._productPriceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this._productPriceNumericUpDown.TabIndex = 3;
            this._productPriceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _materialRadioButton
            // 
            this._materialRadioButton.AutoSize = true;
            this._materialRadioButton.Location = new System.Drawing.Point(16, 65);
            this._materialRadioButton.Name = "_materialRadioButton";
            this._materialRadioButton.Size = new System.Drawing.Size(68, 17);
            this._materialRadioButton.TabIndex = 4;
            this._materialRadioButton.TabStop = true;
            this._materialRadioButton.Text = "Materiale";
            this._materialRadioButton.UseVisualStyleBackColor = true;
            this._materialRadioButton.CheckedChanged += new System.EventHandler(this._materialRadioButton_CheckedChanged);
            // 
            // _workHourRadioButton
            // 
            this._workHourRadioButton.AutoSize = true;
            this._workHourRadioButton.Location = new System.Drawing.Point(16, 88);
            this._workHourRadioButton.Name = "_workHourRadioButton";
            this._workHourRadioButton.Size = new System.Drawing.Size(79, 17);
            this._workHourRadioButton.TabIndex = 5;
            this._workHourRadioButton.TabStop = true;
            this._workHourRadioButton.Text = "Arbejdstime";
            this._workHourRadioButton.UseVisualStyleBackColor = true;
            // 
            // _transportRadioButton
            // 
            this._transportRadioButton.AutoSize = true;
            this._transportRadioButton.Location = new System.Drawing.Point(16, 111);
            this._transportRadioButton.Name = "_transportRadioButton";
            this._transportRadioButton.Size = new System.Drawing.Size(70, 17);
            this._transportRadioButton.TabIndex = 6;
            this._transportRadioButton.TabStop = true;
            this._transportRadioButton.Text = "Transport";
            this._transportRadioButton.UseVisualStyleBackColor = true;
            // 
            // _saveProductButton
            // 
            this._saveProductButton.Location = new System.Drawing.Point(108, 136);
            this._saveProductButton.Name = "_saveProductButton";
            this._saveProductButton.Size = new System.Drawing.Size(75, 23);
            this._saveProductButton.TabIndex = 7;
            this._saveProductButton.Text = "Gem";
            this._saveProductButton.UseVisualStyleBackColor = true;
            this._saveProductButton.Click += new System.EventHandler(this._saveProductButton_Click);
            // 
            // _costPriceNumericUpDown
            // 
            this._costPriceNumericUpDown.DecimalPlaces = 2;
            this._costPriceNumericUpDown.Location = new System.Drawing.Point(83, 62);
            this._costPriceNumericUpDown.Name = "_costPriceNumericUpDown";
            this._costPriceNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this._costPriceNumericUpDown.TabIndex = 9;
            this._costPriceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _costPriceLabel
            // 
            this._costPriceLabel.AutoSize = true;
            this._costPriceLabel.Location = new System.Drawing.Point(13, 64);
            this._costPriceLabel.Name = "_costPriceLabel";
            this._costPriceLabel.Size = new System.Drawing.Size(67, 13);
            this._costPriceLabel.TabIndex = 8;
            this._costPriceLabel.Text = "Indkøbspris: ";
            // 
            // ProductCRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 166);
            this.Controls.Add(this._costPriceNumericUpDown);
            this.Controls.Add(this._costPriceLabel);
            this.Controls.Add(this._saveProductButton);
            this.Controls.Add(this._transportRadioButton);
            this.Controls.Add(this._workHourRadioButton);
            this.Controls.Add(this._materialRadioButton);
            this.Controls.Add(this._productPriceNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._productNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ProductCRUDForm";
            this.Text = "ProductEditForm";
            ((System.ComponentModel.ISupportInitialize)(this._productPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._costPriceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _productNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _productPriceNumericUpDown;
        private System.Windows.Forms.RadioButton _materialRadioButton;
        private System.Windows.Forms.RadioButton _workHourRadioButton;
        private System.Windows.Forms.RadioButton _transportRadioButton;
        private System.Windows.Forms.Button _saveProductButton;
        private System.Windows.Forms.NumericUpDown _costPriceNumericUpDown;
        private System.Windows.Forms.Label _costPriceLabel;
    }
}