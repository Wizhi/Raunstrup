namespace Raunstrup.Forms
{
    partial class CustomerSelectForm
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
            this._customerListView = new System.Windows.Forms.ListView();
            this._createNewCustomerButton = new System.Windows.Forms.Button();
            this._editCustomerButton = new System.Windows.Forms.Button();
            this._deleteCustomerButton = new System.Windows.Forms.Button();
            this.CustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PostalCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _customerListView
            // 
            this._customerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CustomerID,
            this.CustomerName,
            this.PostalCode});
            this._customerListView.FullRowSelect = true;
            this._customerListView.Location = new System.Drawing.Point(13, 13);
            this._customerListView.Name = "_customerListView";
            this._customerListView.Size = new System.Drawing.Size(238, 219);
            this._customerListView.TabIndex = 0;
            this._customerListView.UseCompatibleStateImageBehavior = false;
            this._customerListView.View = System.Windows.Forms.View.Details;
            // 
            // _createNewCustomerButton
            // 
            this._createNewCustomerButton.Location = new System.Drawing.Point(13, 239);
            this._createNewCustomerButton.Name = "_createNewCustomerButton";
            this._createNewCustomerButton.Size = new System.Drawing.Size(75, 23);
            this._createNewCustomerButton.TabIndex = 1;
            this._createNewCustomerButton.Text = "Opret ny";
            this._createNewCustomerButton.UseVisualStyleBackColor = true;
            this._createNewCustomerButton.Click += new System.EventHandler(this._createNewCustomerButton_Click);
            // 
            // _editCustomerButton
            // 
            this._editCustomerButton.Location = new System.Drawing.Point(95, 239);
            this._editCustomerButton.Name = "_editCustomerButton";
            this._editCustomerButton.Size = new System.Drawing.Size(75, 23);
            this._editCustomerButton.TabIndex = 2;
            this._editCustomerButton.Text = "Rediger";
            this._editCustomerButton.UseVisualStyleBackColor = true;
            this._editCustomerButton.Click += new System.EventHandler(this._editCustomerButton_Click);
            // 
            // _deleteCustomerButton
            // 
            this._deleteCustomerButton.Location = new System.Drawing.Point(177, 239);
            this._deleteCustomerButton.Name = "_deleteCustomerButton";
            this._deleteCustomerButton.Size = new System.Drawing.Size(75, 23);
            this._deleteCustomerButton.TabIndex = 3;
            this._deleteCustomerButton.Text = "Slet";
            this._deleteCustomerButton.UseVisualStyleBackColor = true;
            this._deleteCustomerButton.Click += new System.EventHandler(this._deleteCustomerButton_Click);
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "Kundenr";
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Kunde";
            this.CustomerName.Width = 100;
            // 
            // PostalCode
            // 
            this.PostalCode.Text = "Postnr";
            // 
            // CustomerSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 270);
            this.Controls.Add(this._deleteCustomerButton);
            this.Controls.Add(this._editCustomerButton);
            this.Controls.Add(this._createNewCustomerButton);
            this.Controls.Add(this._customerListView);
            this.Name = "CustomerSelectForm";
            this.Text = "CustomerSelectForm";
            this.Load += new System.EventHandler(this.CustomerSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _customerListView;
        private System.Windows.Forms.Button _createNewCustomerButton;
        private System.Windows.Forms.Button _editCustomerButton;
        private System.Windows.Forms.Button _deleteCustomerButton;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader PostalCode;
    }
}