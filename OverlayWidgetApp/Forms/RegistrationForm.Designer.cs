namespace OverlayWidgetApp
{
    partial class RegistrationForm
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
            label1 = new Label();
            label2 = new Label();
            LoginTXB = new TextBox();
            PasswordTXB = new TextBox();
            ConfirmBtn = new Button();
            ErrorLBL = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Hasło";
            // 
            // LoginTXB
            // 
            LoginTXB.Location = new Point(55, 19);
            LoginTXB.MaxLength = 50;
            LoginTXB.Name = "LoginTXB";
            LoginTXB.Size = new Size(183, 23);
            LoginTXB.TabIndex = 2;
            // 
            // PasswordTXB
            // 
            PasswordTXB.Location = new Point(55, 48);
            PasswordTXB.MaxLength = 50;
            PasswordTXB.Name = "PasswordTXB";
            PasswordTXB.Size = new Size(183, 23);
            PasswordTXB.TabIndex = 3;
            PasswordTXB.UseSystemPasswordChar = true;
            // 
            // ConfirmBtn
            // 
            ConfirmBtn.BackColor = SystemColors.Control;
            ConfirmBtn.Location = new Point(90, 77);
            ConfirmBtn.Name = "ConfirmBtn";
            ConfirmBtn.Size = new Size(75, 23);
            ConfirmBtn.TabIndex = 4;
            ConfirmBtn.Text = "Zatwierdź";
            ConfirmBtn.UseVisualStyleBackColor = false;
            ConfirmBtn.Click += Confirm_Click;
            // 
            // ErrorLBL
            // 
            ErrorLBL.AutoSize = true;
            ErrorLBL.ForeColor = Color.Red;
            ErrorLBL.Location = new Point(12, 74);
            ErrorLBL.Name = "ErrorLBL";
            ErrorLBL.Size = new Size(51, 15);
            ErrorLBL.TabIndex = 5;
            ErrorLBL.Text = "ErrorLBL";
            ErrorLBL.Visible = false;
            // 
            // RegistrationForm
            // 
            AcceptButton = ConfirmBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 111);
            Controls.Add(ErrorLBL);
            Controls.Add(ConfirmBtn);
            Controls.Add(PasswordTXB);
            Controls.Add(LoginTXB);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegistrationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rejestracja/Zmiana hasła";
            TopMost = true;
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox LoginTXB;
        private TextBox PasswordTXB;
        private Button ConfirmBtn;
        private Label ErrorLBL;
    }
}