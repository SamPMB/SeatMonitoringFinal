namespace LibraryUI
{
    partial class SeatListForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            seat1Label = new Label();
            seat2Lable = new Label();
            seat3Label = new Label();
            seat4Label = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            label2 = new Label();
            taken = new Label();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            button1 = new Button();
            SuspendLayout();
            // 
            // seat1Label
            // 
            seat1Label.AutoSize = true;
            seat1Label.BackColor = SystemColors.HotTrack;
            seat1Label.BorderStyle = BorderStyle.Fixed3D;
            seat1Label.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            seat1Label.ForeColor = Color.White;
            seat1Label.Location = new Point(55, 205);
            seat1Label.MinimumSize = new Size(250, 100);
            seat1Label.Name = "seat1Label";
            seat1Label.Size = new Size(250, 100);
            seat1Label.TabIndex = 1;
            seat1Label.Text = "SEAT 1";
            seat1Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // seat2Lable
            // 
            seat2Lable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            seat2Lable.AutoSize = true;
            seat2Lable.BackColor = Color.Red;
            seat2Lable.BorderStyle = BorderStyle.Fixed3D;
            seat2Lable.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            seat2Lable.ForeColor = Color.White;
            seat2Lable.Location = new Point(500, 205);
            seat2Lable.MinimumSize = new Size(250, 100);
            seat2Lable.Name = "seat2Lable";
            seat2Lable.Size = new Size(250, 100);
            seat2Lable.TabIndex = 2;
            seat2Lable.Text = "SEAT 2";
            seat2Lable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // seat3Label
            // 
            seat3Label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            seat3Label.AutoSize = true;
            seat3Label.BackColor = Color.Yellow;
            seat3Label.BorderStyle = BorderStyle.Fixed3D;
            seat3Label.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            seat3Label.ForeColor = Color.White;
            seat3Label.Location = new Point(55, 389);
            seat3Label.MinimumSize = new Size(250, 100);
            seat3Label.Name = "seat3Label";
            seat3Label.Size = new Size(250, 100);
            seat3Label.TabIndex = 3;
            seat3Label.Text = "SEAT 3";
            seat3Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // seat4Label
            // 
            seat4Label.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            seat4Label.AutoSize = true;
            seat4Label.BackColor = SystemColors.HotTrack;
            seat4Label.BorderStyle = BorderStyle.Fixed3D;
            seat4Label.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            seat4Label.ForeColor = Color.White;
            seat4Label.Location = new Point(500, 389);
            seat4Label.MinimumSize = new Size(250, 100);
            seat4Label.Name = "seat4Label";
            seat4Label.Size = new Size(250, 100);
            seat4Label.TabIndex = 4;
            seat4Label.Text = "SEAT 4";
            seat4Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = SystemColors.HotTrack;
            guna2Panel2.CustomizableEdges = customizableEdges1;
            guna2Panel2.Location = new Point(101, 94);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel2.Size = new Size(58, 29);
            guna2Panel2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 126);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 6;
            label2.Text = "Available";
            // 
            // taken
            // 
            taken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            taken.AutoSize = true;
            taken.Location = new Point(663, 126);
            taken.Name = "taken";
            taken.Size = new Size(87, 25);
            taken.TabIndex = 8;
            taken.Text = "Occupied";
            // 
            // guna2Panel3
            // 
            guna2Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2Panel3.BackColor = Color.Red;
            guna2Panel3.CustomizableEdges = customizableEdges3;
            guna2Panel3.Location = new Point(676, 94);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel3.Size = new Size(58, 29);
            guna2Panel3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.BurlyWood;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.HotTrack;
            button1.Location = new Point(1, 0);
            button1.Name = "button1";
            button1.Size = new Size(799, 64);
            button1.TabIndex = 0;
            button1.Text = "THE COPPERBELT UNIVERSITY";
            button1.UseVisualStyleBackColor = false;
            // 
            // SeatListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(800, 613);
            Controls.Add(button1);
            Controls.Add(taken);
            Controls.Add(label2);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Controls.Add(seat4Label);
            Controls.Add(seat3Label);
            Controls.Add(seat2Lable);
            Controls.Add(seat1Label);
            Name = "SeatListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SeatListModel";
            Load += SeatListModel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label seat1Label;
        private Label seat2Lable;
        private Label seat3Label;
        private Label seat4Label;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Label label2;
        private Label taken;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Button button1;
    }
}