namespace CSProjectBate001.Views
{
    partial class PrescriptionInterfaceForm
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
            this.dateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.doctorNametableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.docNamelabel = new System.Windows.Forms.Label();
            this.doctorNameTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.doctorIDTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DoctorIDlabel = new System.Windows.Forms.Label();
            this.DoctorIDtextBox = new System.Windows.Forms.TextBox();
            this.depTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.depLabel = new System.Windows.Forms.Label();
            this.depTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.dateTableLayoutPanel.SuspendLayout();
            this.doctorNametableLayoutPanel.SuspendLayout();
            this.doctorIDTableLayoutPanel.SuspendLayout();
            this.depTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.depTableLayoutPanel);
            this.panel1.Controls.Add(this.doctorIDTableLayoutPanel);
            this.panel1.Controls.Add(this.dateTableLayoutPanel);
            this.panel1.Controls.Add(this.doctorNametableLayoutPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 183);
            this.panel1.TabIndex = 0;
            // 
            // dateTableLayoutPanel
            // 
            this.dateTableLayoutPanel.ColumnCount = 2;
            this.dateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754F));
            this.dateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245F));
            this.dateTableLayoutPanel.Controls.Add(this.dateLabel, 0, 0);
            this.dateTableLayoutPanel.Controls.Add(this.dateTextBox, 1, 0);
            this.dateTableLayoutPanel.Location = new System.Drawing.Point(320, 58);
            this.dateTableLayoutPanel.Name = "dateTableLayoutPanel";
            this.dateTableLayoutPanel.RowCount = 1;
            this.dateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dateTableLayoutPanel.Size = new System.Drawing.Size(285, 33);
            this.dateTableLayoutPanel.TabIndex = 2;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(23, 10);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 12);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTextBox.Enabled = false;
            this.dateTextBox.Location = new System.Drawing.Point(103, 6);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(154, 21);
            this.dateTextBox.TabIndex = 1;
            // 
            // doctorNametableLayoutPanel
            // 
            this.doctorNametableLayoutPanel.ColumnCount = 2;
            this.doctorNametableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754F));
            this.doctorNametableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245F));
            this.doctorNametableLayoutPanel.Controls.Add(this.docNamelabel, 0, 0);
            this.doctorNametableLayoutPanel.Controls.Add(this.doctorNameTextBox, 1, 0);
            this.doctorNametableLayoutPanel.Location = new System.Drawing.Point(12, 58);
            this.doctorNametableLayoutPanel.Name = "doctorNametableLayoutPanel";
            this.doctorNametableLayoutPanel.RowCount = 1;
            this.doctorNametableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorNametableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.doctorNametableLayoutPanel.Size = new System.Drawing.Size(285, 33);
            this.doctorNametableLayoutPanel.TabIndex = 1;
            // 
            // docNamelabel
            // 
            this.docNamelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.docNamelabel.AutoSize = true;
            this.docNamelabel.Location = new System.Drawing.Point(9, 10);
            this.docNamelabel.Name = "docNamelabel";
            this.docNamelabel.Size = new System.Drawing.Size(57, 12);
            this.docNamelabel.TabIndex = 0;
            this.docNamelabel.Text = "의사 이름";
            // 
            // doctorNameTextBox
            // 
            this.doctorNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.doctorNameTextBox.Enabled = false;
            this.doctorNameTextBox.Location = new System.Drawing.Point(103, 6);
            this.doctorNameTextBox.Name = "doctorNameTextBox";
            this.doctorNameTextBox.Size = new System.Drawing.Size(154, 21);
            this.doctorNameTextBox.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 52);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 819);
            this.panel2.TabIndex = 1;
            // 
            // doctorIDTableLayoutPanel
            // 
            this.doctorIDTableLayoutPanel.ColumnCount = 2;
            this.doctorIDTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754F));
            this.doctorIDTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245F));
            this.doctorIDTableLayoutPanel.Controls.Add(this.DoctorIDlabel, 0, 0);
            this.doctorIDTableLayoutPanel.Controls.Add(this.DoctorIDtextBox, 1, 0);
            this.doctorIDTableLayoutPanel.Location = new System.Drawing.Point(611, 58);
            this.doctorIDTableLayoutPanel.Name = "doctorIDTableLayoutPanel";
            this.doctorIDTableLayoutPanel.RowCount = 1;
            this.doctorIDTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doctorIDTableLayoutPanel.Size = new System.Drawing.Size(285, 33);
            this.doctorIDTableLayoutPanel.TabIndex = 3;
            // 
            // DoctorIDlabel
            // 
            this.DoctorIDlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DoctorIDlabel.AutoSize = true;
            this.DoctorIDlabel.Location = new System.Drawing.Point(16, 10);
            this.DoctorIDlabel.Name = "DoctorIDlabel";
            this.DoctorIDlabel.Size = new System.Drawing.Size(44, 12);
            this.DoctorIDlabel.TabIndex = 0;
            this.DoctorIDlabel.Text = "의사 ID";
            // 
            // DoctorIDtextBox
            // 
            this.DoctorIDtextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DoctorIDtextBox.Enabled = false;
            this.DoctorIDtextBox.Location = new System.Drawing.Point(103, 6);
            this.DoctorIDtextBox.Name = "DoctorIDtextBox";
            this.DoctorIDtextBox.Size = new System.Drawing.Size(154, 21);
            this.DoctorIDtextBox.TabIndex = 1;
            // 
            // depTableLayoutPanel
            // 
            this.depTableLayoutPanel.ColumnCount = 2;
            this.depTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01754F));
            this.depTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98245F));
            this.depTableLayoutPanel.Controls.Add(this.depLabel, 0, 0);
            this.depTableLayoutPanel.Controls.Add(this.depTextBox, 1, 0);
            this.depTableLayoutPanel.Location = new System.Drawing.Point(902, 58);
            this.depTableLayoutPanel.Name = "depTableLayoutPanel";
            this.depTableLayoutPanel.RowCount = 1;
            this.depTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.depTableLayoutPanel.Size = new System.Drawing.Size(285, 33);
            this.depTableLayoutPanel.TabIndex = 4;
            // 
            // depLabel
            // 
            this.depLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.depLabel.AutoSize = true;
            this.depLabel.Location = new System.Drawing.Point(23, 10);
            this.depLabel.Name = "depLabel";
            this.depLabel.Size = new System.Drawing.Size(29, 12);
            this.depLabel.TabIndex = 0;
            this.depLabel.Text = "소속";
            // 
            // depTextBox
            // 
            this.depTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.depTextBox.Enabled = false;
            this.depTextBox.Location = new System.Drawing.Point(103, 6);
            this.depTextBox.Name = "depTextBox";
            this.depTextBox.Size = new System.Drawing.Size(154, 21);
            this.depTextBox.TabIndex = 1;
            // 
            // PrescriptionInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1002);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrescriptionInterfaceForm";
            this.Text = "PrescriptionInterfaceForm";
            this.panel1.ResumeLayout(false);
            this.dateTableLayoutPanel.ResumeLayout(false);
            this.dateTableLayoutPanel.PerformLayout();
            this.doctorNametableLayoutPanel.ResumeLayout(false);
            this.doctorNametableLayoutPanel.PerformLayout();
            this.doctorIDTableLayoutPanel.ResumeLayout(false);
            this.doctorIDTableLayoutPanel.PerformLayout();
            this.depTableLayoutPanel.ResumeLayout(false);
            this.depTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel doctorNametableLayoutPanel;
        private System.Windows.Forms.Label docNamelabel;
        private System.Windows.Forms.TextBox doctorNameTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel dateTableLayoutPanel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TableLayoutPanel doctorIDTableLayoutPanel;
        private System.Windows.Forms.Label DoctorIDlabel;
        private System.Windows.Forms.TextBox DoctorIDtextBox;
        private System.Windows.Forms.TableLayoutPanel depTableLayoutPanel;
        private System.Windows.Forms.Label depLabel;
        private System.Windows.Forms.TextBox depTextBox;
    }
}