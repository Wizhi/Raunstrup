namespace Raunstrup.Forms
{
    partial class ProductSelectForm
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
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Materiale", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Arbejdstime", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Transport", System.Windows.Forms.HorizontalAlignment.Left);
            this._productListView = new System.Windows.Forms.ListView();
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SalesPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._createNewProductButton = new System.Windows.Forms.Button();
            this._editProductButton = new System.Windows.Forms.Button();
            this._deleteProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _productListView
            // 
            this._productListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductName,
            this.SalesPrice});
            this._productListView.FullRowSelect = true;
            listViewGroup7.Header = "Materiale";
            listViewGroup7.Name = "MaterialGroup";
            listViewGroup8.Header = "Arbejdstime";
            listViewGroup8.Name = "WorkHour";
            listViewGroup9.Header = "Transport";
            listViewGroup9.Name = "Transport";
            this._productListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this._productListView.Location = new System.Drawing.Point(12, 12);
            this._productListView.Name = "_productListView";
            this._productListView.Size = new System.Drawing.Size(237, 243);
            this._productListView.TabIndex = 0;
            this._productListView.UseCompatibleStateImageBehavior = false;
            this._productListView.View = System.Windows.Forms.View.Details;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Vare";
            this.ProductName.Width = 100;
            // 
            // SalesPrice
            // 
            this.SalesPrice.Text = "Pris";
            // 
            // _createNewProductButton
            // 
            this._createNewProductButton.Location = new System.Drawing.Point(12, 261);
            this._createNewProductButton.Name = "_createNewProductButton";
            this._createNewProductButton.Size = new System.Drawing.Size(75, 23);
            this._createNewProductButton.TabIndex = 1;
            this._createNewProductButton.Text = "Opret ny";
            this._createNewProductButton.UseVisualStyleBackColor = true;
            this._createNewProductButton.Click += new System.EventHandler(this._createNewProductButton_Click);
            // 
            // _editProductButton
            // 
            this._editProductButton.Location = new System.Drawing.Point(93, 261);
            this._editProductButton.Name = "_editProductButton";
            this._editProductButton.Size = new System.Drawing.Size(75, 23);
            this._editProductButton.TabIndex = 2;
            this._editProductButton.Text = "Rediger";
            this._editProductButton.UseVisualStyleBackColor = true;
            this._editProductButton.Click += new System.EventHandler(this._editProductButton_Click);
            // 
            // _deleteProductButton
            // 
            this._deleteProductButton.Location = new System.Drawing.Point(174, 261);
            this._deleteProductButton.Name = "_deleteProductButton";
            this._deleteProductButton.Size = new System.Drawing.Size(75, 23);
            this._deleteProductButton.TabIndex = 3;
            this._deleteProductButton.Text = "Slet";
            this._deleteProductButton.UseVisualStyleBackColor = true;
            this._deleteProductButton.Click += new System.EventHandler(this._deleteProductButton_Click);
            // 
            // ProductSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 293);
            this.Controls.Add(this._deleteProductButton);
            this.Controls.Add(this._editProductButton);
            this.Controls.Add(this._createNewProductButton);
            this.Controls.Add(this._productListView);
            this.Name = "ProductSelectForm";
            this.Text = "ProductSelectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _productListView;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader SalesPrice;
        private System.Windows.Forms.Button _createNewProductButton;
        private System.Windows.Forms.Button _editProductButton;
        private System.Windows.Forms.Button _deleteProductButton;
    }
}