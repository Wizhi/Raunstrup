namespace Raunstrup.Forms.CRUD
{
    partial class CustomerCreateForm
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
            this._nameLabel = new System.Windows.Forms.Label();
            this._streetLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._streetNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cityTextBox = new System.Windows.Forms.TextBox();
            this._cityLabel = new System.Windows.Forms.Label();
            this._streetNumberTextBox = new System.Windows.Forms.TextBox();
            this._postCodeComboBox = new System.Windows.Forms.ComboBox();
            this._postalCodeTextBox = new System.Windows.Forms.Label();
            this._saveButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(16, 22);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(33, 13);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Navn";
            // 
            // _streetLabel
            // 
            this._streetLabel.AutoSize = true;
            this._streetLabel.Location = new System.Drawing.Point(16, 100);
            this._streetLabel.Name = "_streetLabel";
            this._streetLabel.Size = new System.Drawing.Size(33, 13);
            this._streetLabel.TabIndex = 1;
            this._streetLabel.Text = "Gade";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(55, 19);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(154, 20);
            this._nameTextBox.TabIndex = 2;
            // 
            // _streetNameTextBox
            // 
            this._streetNameTextBox.Location = new System.Drawing.Point(55, 97);
            this._streetNameTextBox.Name = "_streetNameTextBox";
            this._streetNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._streetNameTextBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cancelButton);
            this.groupBox1.Controls.Add(this._saveButton);
            this.groupBox1.Controls.Add(this._postalCodeTextBox);
            this.groupBox1.Controls.Add(this._postCodeComboBox);
            this.groupBox1.Controls.Add(this._streetNumberTextBox);
            this.groupBox1.Controls.Add(this._cityTextBox);
            this.groupBox1.Controls.Add(this._cityLabel);
            this.groupBox1.Controls.Add(this._nameTextBox);
            this.groupBox1.Controls.Add(this._streetNameTextBox);
            this.groupBox1.Controls.Add(this._nameLabel);
            this.groupBox1.Controls.Add(this._streetLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kunde information";
            // 
            // _cityTextBox
            // 
            this._cityTextBox.Location = new System.Drawing.Point(55, 45);
            this._cityTextBox.Name = "_cityTextBox";
            this._cityTextBox.Size = new System.Drawing.Size(154, 20);
            this._cityTextBox.TabIndex = 5;
            // 
            // _cityLabel
            // 
            this._cityLabel.AutoSize = true;
            this._cityLabel.Location = new System.Drawing.Point(30, 48);
            this._cityLabel.Name = "_cityLabel";
            this._cityLabel.Size = new System.Drawing.Size(19, 13);
            this._cityLabel.TabIndex = 4;
            this._cityLabel.Text = "By";
            // 
            // _streetNumberTextBox
            // 
            this._streetNumberTextBox.Location = new System.Drawing.Point(161, 97);
            this._streetNumberTextBox.Name = "_streetNumberTextBox";
            this._streetNumberTextBox.Size = new System.Drawing.Size(48, 20);
            this._streetNumberTextBox.TabIndex = 6;
            // 
            // _postCodeComboBox
            // 
            this._postCodeComboBox.FormattingEnabled = true;
            this._postCodeComboBox.Location = new System.Drawing.Point(55, 71);
            this._postCodeComboBox.Name = "_postCodeComboBox";
            this._postCodeComboBox.Size = new System.Drawing.Size(154, 21);
            this._postCodeComboBox.TabIndex = 7;
            // 
            // _postalCodeTextBox
            // 
            this._postalCodeTextBox.AutoSize = true;
            this._postalCodeTextBox.Location = new System.Drawing.Point(6, 74);
            this._postalCodeTextBox.Name = "_postalCodeTextBox";
            this._postalCodeTextBox.Size = new System.Drawing.Size(43, 13);
            this._postalCodeTextBox.TabIndex = 8;
            this._postalCodeTextBox.Text = "Post nr.";
            // 
            // _saveButton
            // 
            this._saveButton.AutoSize = true;
            this._saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._saveButton.Location = new System.Drawing.Point(166, 123);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(43, 23);
            this._saveButton.TabIndex = 9;
            this._saveButton.Text = "Opret";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.AutoSize = true;
            this._cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._cancelButton.Location = new System.Drawing.Point(105, 123);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(55, 23);
            this._cancelButton.TabIndex = 10;
            this._cancelButton.Text = "Annuller";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // CustomerCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 180);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(262, 218);
            this.MinimumSize = new System.Drawing.Size(262, 218);
            this.Name = "CustomerCreateForm";
            this.Text = "Opret kunde";
            this.Load += new System.EventHandler(this.CustomerCreateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _streetLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.TextBox _streetNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _cityTextBox;
        private System.Windows.Forms.Label _cityLabel;
        private System.Windows.Forms.TextBox _streetNumberTextBox;
        private System.Windows.Forms.Label _postalCodeTextBox;
        private System.Windows.Forms.ComboBox _postCodeComboBox;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _saveButton;
    }
}