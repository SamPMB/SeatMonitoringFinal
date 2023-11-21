namespace LibraryUI
{
    partial class RegisterForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            loginPanel = new Guna.UI2.WinForms.Guna2Panel();
            label3 = new Label();
            registerRole = new ComboBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            registerUserButton = new Button();
            label1 = new Label();
            userpasswordRegister = new TextBox();
            userNameRegister = new TextBox();
            comfirmPassword = new TextBox();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.BackColor = Color.FromArgb(51, 181, 229);
            guna2Panel1.BorderColor = Color.Transparent;
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(88, 724);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(629, 10);
            guna2Panel1.TabIndex = 9;
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.Top;
            loginPanel.BackColor = Color.WhiteSmoke;
            loginPanel.BorderRadius = 20;
            loginPanel.Controls.Add(comfirmPassword);
            loginPanel.Controls.Add(label3);
            loginPanel.Controls.Add(registerRole);
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(guna2Panel2);
            loginPanel.Controls.Add(registerUserButton);
            loginPanel.Controls.Add(label1);
            loginPanel.Controls.Add(userpasswordRegister);
            loginPanel.Controls.Add(userNameRegister);
            loginPanel.CustomizableEdges = customizableEdges5;
            loginPanel.Location = new Point(41, 36);
            loginPanel.Margin = new Padding(4, 3, 4, 3);
            loginPanel.Name = "loginPanel";
            loginPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            loginPanel.Size = new Size(696, 857);
            loginPanel.TabIndex = 10;
            loginPanel.Paint += loginPanel_Paint_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(51, 181, 229);
            label3.Location = new Point(110, 585);
            label3.Name = "label3";
            label3.Size = new Size(80, 44);
            label3.TabIndex = 10;
            label3.Text = "Role";
            // 
            // registerRole
            // 
            registerRole.FormattingEnabled = true;
            registerRole.Location = new Point(130, 632);
            registerRole.Name = "registerRole";
            registerRole.Size = new Size(182, 33);
            registerRole.TabIndex = 9;
            registerRole.SelectedIndexChanged += registerRole_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(235, 99);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(12, 66, 111);
            label2.Location = new Point(27, 31);
            label2.Name = "label2";
            label2.Size = new Size(631, 45);
            label2.TabIndex = 7;
            label2.Text = "THE COPPERBELTY UNIVERSITY LIBRARY";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(51, 181, 229);
            guna2Panel2.BorderColor = Color.Transparent;
            guna2Panel2.CustomizableEdges = customizableEdges3;
            guna2Panel2.Location = new Point(0, 847);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(696, 10);
            guna2Panel2.TabIndex = 0;
            // 
            // registerUserButton
            // 
            registerUserButton.BackColor = Color.FromArgb(51, 181, 229);
            registerUserButton.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            registerUserButton.ForeColor = Color.White;
            registerUserButton.Location = new Point(120, 691);
            registerUserButton.Name = "registerUserButton";
            registerUserButton.Size = new Size(471, 53);
            registerUserButton.TabIndex = 5;
            registerUserButton.Text = "Register";
            registerUserButton.UseVisualStyleBackColor = false;
            registerUserButton.Click += registerUserButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(51, 181, 229);
            label1.Location = new Point(120, 304);
            label1.Name = "label1";
            label1.Size = new Size(208, 44);
            label1.TabIndex = 3;
            label1.Text = "Register staff";
            // 
            // userpasswordRegister
            // 
            userpasswordRegister.BackColor = Color.White;
            userpasswordRegister.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            userpasswordRegister.ForeColor = Color.FromArgb(12, 66, 111);
            userpasswordRegister.Location = new Point(130, 449);
            userpasswordRegister.Name = "userpasswordRegister";
            userpasswordRegister.PasswordChar = '*';
            userpasswordRegister.PlaceholderText = " Password";
            userpasswordRegister.Size = new Size(471, 45);
            userpasswordRegister.TabIndex = 2;
            // 
            // userNameRegister
            // 
            userNameRegister.BackColor = Color.White;
            userNameRegister.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            userNameRegister.ForeColor = Color.FromArgb(12, 66, 111);
            userNameRegister.Location = new Point(130, 351);
            userNameRegister.Name = "userNameRegister";
            userNameRegister.PlaceholderText = "User name";
            userNameRegister.Size = new Size(471, 45);
            userNameRegister.TabIndex = 1;
            // 
            // comfirmPassword
            // 
            comfirmPassword.BackColor = Color.White;
            comfirmPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            comfirmPassword.ForeColor = Color.FromArgb(12, 66, 111);
            comfirmPassword.Location = new Point(130, 528);
            comfirmPassword.Name = "comfirmPassword";
            comfirmPassword.PasswordChar = '*';
            comfirmPassword.PlaceholderText = " Comfirm";
            comfirmPassword.Size = new Size(471, 45);
            comfirmPassword.TabIndex = 11;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 66, 111);
            ClientSize = new Size(778, 944);
            Controls.Add(loginPanel);
            Controls.Add(guna2Panel1);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel loginPanel;
        private Label label3;
        private ComboBox registerRole;
        private PictureBox pictureBox1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Button registerUserButton;
        private Label label1;
        private TextBox userpasswordRegister;
        private TextBox userNameRegister;
        private TextBox comfirmPassword;
    }
}