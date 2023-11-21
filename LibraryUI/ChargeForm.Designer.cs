namespace LibraryUI
{
    partial class ChargeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button1 = new Button();
            ChargeGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)ChargeGrid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.BurlyWood;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.HotTrack;
            button1.Location = new Point(-4, 1);
            button1.Name = "button1";
            button1.Size = new Size(803, 64);
            button1.TabIndex = 5;
            button1.Text = "THE COPPERBELT UNIVERSITY";
            button1.UseVisualStyleBackColor = false;
            // 
            // ChargeGrid
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            ChargeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ChargeGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChargeGrid.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ChargeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ChargeGrid.ColumnHeadersHeight = 27;
            ChargeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ChargeGrid.DefaultCellStyle = dataGridViewCellStyle3;
            ChargeGrid.GridColor = Color.FromArgb(231, 229, 255);
            ChargeGrid.Location = new Point(2, 87);
            ChargeGrid.Name = "ChargeGrid";
            ChargeGrid.RowHeadersVisible = false;
            ChargeGrid.RowHeadersWidth = 62;
            ChargeGrid.RowTemplate.Height = 33;
            ChargeGrid.Size = new Size(796, 276);
            ChargeGrid.TabIndex = 6;
            ChargeGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            ChargeGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            ChargeGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ChargeGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ChargeGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ChargeGrid.ThemeStyle.BackColor = SystemColors.ButtonFace;
            ChargeGrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            ChargeGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            ChargeGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ChargeGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ChargeGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ChargeGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ChargeGrid.ThemeStyle.HeaderStyle.Height = 27;
            ChargeGrid.ThemeStyle.ReadOnly = false;
            ChargeGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            ChargeGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ChargeGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ChargeGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            ChargeGrid.ThemeStyle.RowsStyle.Height = 33;
            ChargeGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            ChargeGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // ChargeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChargeGrid);
            Controls.Add(button1);
            Name = "ChargeForm";
            Text = "ChargeForm";
            ((System.ComponentModel.ISupportInitialize)ChargeGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Guna.UI2.WinForms.Guna2DataGridView ChargeGrid;
    }
}