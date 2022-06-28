
namespace ConsoleApp1
{
    partial class LoginSettings
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
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.groupBoxNewUser = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLolg = new System.Windows.Forms.Button();
            this.tb_Login = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Логин = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_NewUser = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            this.groupBoxNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.tb_Password);
            this.groupBoxLogin.Controls.Add(this.tb_Login);
            this.groupBoxLogin.Controls.Add(this.btnLolg);
            this.groupBoxLogin.Controls.Add(this.label2);
            this.groupBoxLogin.Controls.Add(this.label1);
            this.groupBoxLogin.Location = new System.Drawing.Point(12, 23);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(255, 187);
            this.groupBoxLogin.TabIndex = 0;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Вход";
            // 
            // groupBoxNewUser
            // 
            this.groupBoxNewUser.Controls.Add(this.btn_NewUser);
            this.groupBoxNewUser.Controls.Add(this.label4);
            this.groupBoxNewUser.Controls.Add(this.Логин);
            this.groupBoxNewUser.Controls.Add(this.textBox2);
            this.groupBoxNewUser.Controls.Add(this.textBox1);
            this.groupBoxNewUser.Location = new System.Drawing.Point(295, 23);
            this.groupBoxNewUser.Name = "groupBoxNewUser";
            this.groupBoxNewUser.Size = new System.Drawing.Size(250, 187);
            this.groupBoxNewUser.TabIndex = 1;
            this.groupBoxNewUser.TabStop = false;
            this.groupBoxNewUser.Text = "Новый пользователь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // btnLolg
            // 
            this.btnLolg.Location = new System.Drawing.Point(22, 136);
            this.btnLolg.Name = "btnLolg";
            this.btnLolg.Size = new System.Drawing.Size(210, 23);
            this.btnLolg.TabIndex = 2;
            this.btnLolg.Text = "Вход";
            this.btnLolg.UseVisualStyleBackColor = true;
            this.btnLolg.Click += new System.EventHandler(this.btnLolg_Click);
            // 
            // tb_Login
            // 
            this.tb_Login.Location = new System.Drawing.Point(105, 49);
            this.tb_Login.Name = "tb_Login";
            this.tb_Login.Size = new System.Drawing.Size(127, 22);
            this.tb_Login.TabIndex = 3;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(105, 88);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(127, 22);
            this.tb_Password.TabIndex = 4;
            this.tb_Password.TextChanged += new System.EventHandler(this.tb_Password_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Логин
            // 
            this.Логин.AutoSize = true;
            this.Логин.Location = new System.Drawing.Point(20, 55);
            this.Логин.Name = "Логин";
            this.Логин.Size = new System.Drawing.Size(47, 17);
            this.Логин.TabIndex = 2;
            this.Логин.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Location = new System.Drawing.Point(23, 135);
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(210, 23);
            this.btn_NewUser.TabIndex = 4;
            this.btn_NewUser.Text = "Новый Клиент";
            this.btn_NewUser.UseVisualStyleBackColor = true;
            this.btn_NewUser.Click += new System.EventHandler(this.btn_NewUser_Click);
            // 
            // LoginSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 236);
            this.Controls.Add(this.groupBoxNewUser);
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "LoginSettings";
            this.Text = "LoginSettings";
            this.Load += new System.EventHandler(this.LoginSettings_Load);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBoxNewUser.ResumeLayout(false);
            this.groupBoxNewUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_Login;
        private System.Windows.Forms.Button btnLolg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxNewUser;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Логин;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}