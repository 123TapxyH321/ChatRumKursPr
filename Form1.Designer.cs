
namespace ConsoleApp1
{
    partial class Form1
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
            this.Lbox_InfoAbon = new System.Windows.Forms.ListBox();
            this.tBox_MyMessag = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.Lbox_Chat = new System.Windows.Forms.ListBox();
            this.comBox_NameAbon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbox_InfoAbon
            // 
            this.Lbox_InfoAbon.FormattingEnabled = true;
            this.Lbox_InfoAbon.ItemHeight = 16;
            this.Lbox_InfoAbon.Location = new System.Drawing.Point(544, 69);
            this.Lbox_InfoAbon.Name = "Lbox_InfoAbon";
            this.Lbox_InfoAbon.Size = new System.Drawing.Size(233, 308);
            this.Lbox_InfoAbon.TabIndex = 1;
            // 
            // tBox_MyMessag
            // 
            this.tBox_MyMessag.Location = new System.Drawing.Point(23, 400);
            this.tBox_MyMessag.Name = "tBox_MyMessag";
            this.tBox_MyMessag.Size = new System.Drawing.Size(499, 22);
            this.tBox_MyMessag.TabIndex = 2;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(544, 399);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(233, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Отправить";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // Lbox_Chat
            // 
            this.Lbox_Chat.FormattingEnabled = true;
            this.Lbox_Chat.ItemHeight = 16;
            this.Lbox_Chat.Location = new System.Drawing.Point(13, 15);
            this.Lbox_Chat.Name = "Lbox_Chat";
            this.Lbox_Chat.Size = new System.Drawing.Size(509, 372);
            this.Lbox_Chat.TabIndex = 4;
            // 
            // comBox_NameAbon
            // 
            this.comBox_NameAbon.FormattingEnabled = true;
            this.comBox_NameAbon.Location = new System.Drawing.Point(633, 15);
            this.comBox_NameAbon.Name = "comBox_NameAbon";
            this.comBox_NameAbon.Size = new System.Drawing.Size(144, 24);
            this.comBox_NameAbon.TabIndex = 5;
            this.comBox_NameAbon.SelectedIndexChanged += new System.EventHandler(this.comBox_NameAbon_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Абонент";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_NameAbon);
            this.Controls.Add(this.Lbox_Chat);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.tBox_MyMessag);
            this.Controls.Add(this.Lbox_InfoAbon);
            this.Name = "Form1";
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Lbox_InfoAbon;
        private System.Windows.Forms.TextBox tBox_MyMessag;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.ListBox Lbox_Chat;
        private System.Windows.Forms.ComboBox comBox_NameAbon;
        private System.Windows.Forms.Label label3;
    }
}