namespace CSPrescriptionInterfaceProgramBate001.Views
{
    partial class DrugSearchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.drugsInfoListView = new System.Windows.Forms.ListView();
            this.drugNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drugIDColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.drugNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.drugsInfoListView);
            this.panel1.Location = new System.Drawing.Point(276, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 451);
            this.panel1.TabIndex = 0;
            // 
            // drugsInfoListView
            // 
            this.drugsInfoListView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drugsInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.drugNameColumnHeader,
            this.drugIDColumnHeader,
            this.priceColumnHeader,
            this.CreationColumnHeader});
            this.drugsInfoListView.Location = new System.Drawing.Point(3, 3);
            this.drugsInfoListView.Name = "drugsInfoListView";
            this.drugsInfoListView.Size = new System.Drawing.Size(595, 445);
            this.drugsInfoListView.TabIndex = 0;
            this.drugsInfoListView.UseCompatibleStateImageBehavior = false;
            this.drugsInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // drugNameColumnHeader
            // 
            this.drugNameColumnHeader.Text = "DrugName";
            this.drugNameColumnHeader.Width = 138;
            // 
            // drugIDColumnHeader
            // 
            this.drugIDColumnHeader.Text = "DrugID";
            this.drugIDColumnHeader.Width = 137;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price";
            this.priceColumnHeader.Width = 90;
            // 
            // CreationColumnHeader
            // 
            this.CreationColumnHeader.Text = "CreationDate";
            this.CreationColumnHeader.Width = 101;
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(94, 3);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(137, 21);
            this.drugNameTextBox.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancelButton.Location = new System.Drawing.Point(787, 29);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectButton.Location = new System.Drawing.Point(706, 29);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "선택";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // drugNameLabel
            // 
            this.drugNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drugNameLabel.AutoSize = true;
            this.drugNameLabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drugNameLabel.Location = new System.Drawing.Point(7, 5);
            this.drugNameLabel.Name = "drugNameLabel";
            this.drugNameLabel.Size = new System.Drawing.Size(77, 16);
            this.drugNameLabel.TabIndex = 4;
            this.drugNameLabel.Text = "약품 명칭";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.99187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.00813F));
            this.tableLayoutPanel1.Controls.Add(this.drugNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.drugNameTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 26);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchButton.Location = new System.Drawing.Point(174, 253);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "검색";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.selectButton);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Location = new System.Drawing.Point(0, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 64);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.searchButton);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 304);
            this.panel3.TabIndex = 8;
            // 
            // DrugSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 522);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DrugSearchForm";
            this.Text = "DrugSearchForm";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView drugsInfoListView;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label drugNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader drugNameColumnHeader;
        private System.Windows.Forms.ColumnHeader drugIDColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ColumnHeader CreationColumnHeader;
    }
}