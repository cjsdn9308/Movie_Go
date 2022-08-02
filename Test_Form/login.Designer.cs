
namespace Test_Form
{
    partial class login
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Login_info = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.login_pw_txtbox = new System.Windows.Forms.TextBox();
            this.login_id_txtbox = new System.Windows.Forms.TextBox();
            this.Login_pw_label = new System.Windows.Forms.Label();
            this.login_id_label = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.Login_info);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.login_pw_txtbox);
            this.panel1.Controls.Add(this.login_id_txtbox);
            this.panel1.Controls.Add(this.Login_pw_label);
            this.panel1.Controls.Add(this.login_id_label);
            this.panel1.Controls.Add(this.LogoBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 242);
            this.panel1.TabIndex = 0;
            // 
            // Login_info
            // 
            this.Login_info.Enabled = false;
            this.Login_info.Location = new System.Drawing.Point(51, 174);
            this.Login_info.Name = "Login_info";
            this.Login_info.Size = new System.Drawing.Size(218, 23);
            this.Login_info.TabIndex = 6;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(96, 207);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(134, 24);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // login_pw_txtbox
            // 
            this.login_pw_txtbox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_pw_txtbox.Location = new System.Drawing.Point(148, 134);
            this.login_pw_txtbox.Name = "login_pw_txtbox";
            this.login_pw_txtbox.PasswordChar = '*';
            this.login_pw_txtbox.Size = new System.Drawing.Size(144, 23);
            this.login_pw_txtbox.TabIndex = 4;
            this.login_pw_txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_tbx_pw);
            // 
            // login_id_txtbox
            // 
            this.login_id_txtbox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_id_txtbox.Location = new System.Drawing.Point(148, 85);
            this.login_id_txtbox.Name = "login_id_txtbox";
            this.login_id_txtbox.Size = new System.Drawing.Size(145, 23);
            this.login_id_txtbox.TabIndex = 3;
            this.login_id_txtbox.TextChanged += new System.EventHandler(this.Login_id_change);
            this.login_id_txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_tbx_id);
            // 
            // Login_pw_label
            // 
            this.Login_pw_label.AutoSize = true;
            this.Login_pw_label.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Login_pw_label.Location = new System.Drawing.Point(12, 129);
            this.Login_pw_label.Name = "Login_pw_label";
            this.Login_pw_label.Size = new System.Drawing.Size(92, 28);
            this.Login_pw_label.TabIndex = 2;
            this.Login_pw_label.Text = "패스워드";
            // 
            // login_id_label
            // 
            this.login_id_label.AutoSize = true;
            this.login_id_label.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_id_label.Location = new System.Drawing.Point(12, 85);
            this.login_id_label.Name = "login_id_label";
            this.login_id_label.Size = new System.Drawing.Size(72, 28);
            this.login_id_label.TabIndex = 1;
            this.login_id_label.Text = "아이디";
            // 
            // LogoBox
            // 
            this.LogoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoBox.Location = new System.Drawing.Point(0, 0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(323, 61);
            this.LogoBox.TabIndex = 0;
            this.LogoBox.TabStop = false;
            // 
            // login
            // 
            this.ClientSize = new System.Drawing.Size(323, 242);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovieGO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox login_pw_txtbox;
        private System.Windows.Forms.TextBox login_id_txtbox;
        private System.Windows.Forms.Label Login_pw_label;
        private System.Windows.Forms.Label login_id_label;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox Login_info;
    }
}

