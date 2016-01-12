namespace Raunstrup.Forms
{
    partial class CustomerCRUDForm
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
            this._customerNameTextBox = new System.Windows.Forms.TextBox();
            this._streetNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._cityTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._streetNumberTextBox = new System.Windows.Forms.TextBox();
            this._saveCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kunde: ";
            // 
            // _customerNameTextBox
            // 
            this._customerNameTextBox.Location = new System.Drawing.Point(70, 10);
            this._customerNameTextBox.Name = "_customerNameTextBox";
            this._customerNameTextBox.Size = new System.Drawing.Size(130, 20);
            this._customerNameTextBox.TabIndex = 1;
            // 
            // _streetNameTextBox
            // 
            this._streetNameTextBox.Location = new System.Drawing.Point(70, 36);
            this._streetNameTextBox.Name = "_streetNameTextBox";
            this._streetNameTextBox.Size = new System.Drawing.Size(106, 20);
            this._streetNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adresse: ";
            // 
            // _postalCodeTextBox
            // 
            this._postalCodeTextBox.Location = new System.Drawing.Point(70, 62);
            this._postalCodeTextBox.Name = "_postalCodeTextBox";
            this._postalCodeTextBox.Size = new System.Drawing.Size(130, 20);
            this._postalCodeTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Postnr.: ";
            // 
            // _cityTextBox
            // 
            this._cityTextBox.Location = new System.Drawing.Point(70, 88);
            this._cityTextBox.Name = "_cityTextBox";
            this._cityTextBox.Size = new System.Drawing.Size(130, 20);
            this._cityTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "By: ";
            // 
            // _streetNumberTextBox
            // 
            this._streetNumberTextBox.Location = new System.Drawing.Point(180, 36);
            this._streetNumberTextBox.Name = "_streetNumberTextBox";
            this._streetNumberTextBox.Size = new System.Drawing.Size(20, 20);
            this._streetNumberTextBox.TabIndex = 8;
            // 
            // _saveCustomerButton
            // 
            this._saveCustomerButton.Location = new System.Drawing.Point(125, 114);
            this._saveCustomerButton.Name = "_saveCustomerButton";
            this._saveCustomerButton.Size = new System.Drawing.Size(75, 23);
            this._saveCustomerButton.TabIndex = 9;
            this._saveCustomerButton.Text = "Gem kunde";
            this._saveCustomerButton.UseVisualStyleBackColor = true;
            this._saveCustomerButton.Click += new System.EventHandler(this._saveCustomerButton_Click);
            // 
            // CustomerCRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 142);
            this.Controls.Add(this._saveCustomerButton);
            this.Controls.Add(this._streetNumberTextBox);
            this.Controls.Add(this._cityTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._postalCodeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._streetNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._customerNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CustomerCRUDForm";
            this.Text = "Kunde";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _customerNameTextBox;
        private System.Windows.Forms.TextBox _streetNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _postalCodeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _cityTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _streetNumberTextBox;
        private System.Windows.Forms.Button _saveCustomerButton;
    }
}