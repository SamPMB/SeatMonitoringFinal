namespace LibraryUI
{
    partial class LoginForm1
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            loginPanel = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            password = new TextBox();
            userName = new TextBox();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.Top;
            loginPanel.BackColor = Color.WhiteSmoke;
            loginPanel.BorderRadius = 20;
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(button1);
            loginPanel.Controls.Add(linkLabel1);
            loginPanel.Controls.Add(label1);
            loginPanel.Controls.Add(password);
            loginPanel.Controls.Add(userName);
            loginPanel.Controls.Add(guna2Panel2);
            loginPanel.CustomizableEdges = customizableEdges3;
            loginPanel.Location = new Point(43, 40);
            loginPanel.Margin = new Padding(4, 3, 4, 3);
            loginPanel.Name = "loginPanel";
            loginPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            loginPanel.Size = new Size(696, 791);
            loginPanel.TabIndex = 0;
            loginPanel.Paint += guna2Panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(190, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(316, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.900001F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(12, 66, 111);
            label2.Location = new Point(3, 25);
            label2.Name = "label2";
            label2.Size = new Size(674, 46);
            label2.TabIndex = 7;
            label2.Text = "THE COPPERBELTY UNIVERSITY LIBRARY";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(51, 181, 229);
            button1.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(120, 597);
            button1.Name = "button1";
            button1.Size = new Size(471, 85);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(214, 719);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(292, 49);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot password?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monotype Corsiva", 14.1F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(120, 367);
            label1.Name = "label1";
            label1.Size = new Size(413, 56);
            label1.TabIndex = 3;
            label1.Text = "Enter your credentials";
            // 
            // password
            // 
            password.BackColor = Color.White;
            password.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            password.ForeColor = Color.FromArgb(12, 66, 111);
            password.Location = new Point(120, 530);
            password.Name = "password";
            password.PasswordChar = '*';
            password.PlaceholderText = " Password";
            password.Size = new Size(471, 61);
            password.TabIndex = 2;
            password.Text = "24680";
            password.TextChanged += password_TextChanged;
            // 
            // userName
            // 
            userName.BackColor = Color.White;
            userName.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            userName.ForeColor = Color.FromArgb(12, 66, 111);
            userName.Location = new Point(120, 426);
            userName.Name = "userName";
            userName.PlaceholderText = "Username";
            userName.Size = new Size(471, 70);
            userName.TabIndex = 1;
            userName.Text = "Samson Mumba";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(51, 181, 229);
            guna2Panel2.BorderColor = Color.Transparent;
            guna2Panel2.CustomizableEdges = customizableEdges1;
            guna2Panel2.Location = new Point(3, 781);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel2.Size = new Size(690, 10);
            guna2Panel2.TabIndex = 0;
            // 
            // LoginForm1
            // 
            AutoScaleDimensions = new SizeF(21F, 49F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 66, 111);
            ClientSize = new Size(778, 944);
            Controls.Add(loginPanel);
            Font = new Font("Monotype Corsiva", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(51, 181, 229);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(800, 1000);
            Name = "LoginForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel loginPanel;
        private Button button1;
        private LinkLabel linkLabel1;
        private Label label1;
        private TextBox password;
        private TextBox userName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Label label2;
        private PictureBox pictureBox1;
    }
}