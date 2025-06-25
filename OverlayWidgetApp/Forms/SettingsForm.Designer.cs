using System.Diagnostics;

namespace OverlayWidgetApp
{
    partial class SettingsForm
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
            groupBox1 = new GroupBox();
            WaitTimeLoginCBX = new ComboBox();
            label1 = new Label();
            LoginCHK = new CheckBox();
            groupBox2 = new GroupBox();
            LogoutCloseCHK = new CheckBox();
            WorkEndCHK = new CheckBox();
            label2 = new Label();
            WaitTimeLogoutCBX = new ComboBox();
            LogoutCHK = new CheckBox();
            groupBox3 = new GroupBox();
            InformPanelCHK = new CheckBox();
            groupBox4 = new GroupBox();
            AutoStartCHK = new CheckBox();
            ConfirmBTN = new Button();
            CancelBTN = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(WaitTimeLoginCBX);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(LoginCHK);
            groupBox1.Location = new Point(12, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 81);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ustawienia logowania";
            // 
            // WaitTimeLoginCBX
            // 
            WaitTimeLoginCBX.DropDownStyle = ComboBoxStyle.DropDownList;
            WaitTimeLoginCBX.FormattingEnabled = true;
            WaitTimeLoginCBX.Location = new Point(6, 47);
            WaitTimeLoginCBX.Name = "WaitTimeLoginCBX";
            WaitTimeLoginCBX.Size = new Size(47, 23);
            WaitTimeLoginCBX.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 50);
            label1.Name = "label1";
            label1.Size = new Size(153, 15);
            label1.TabIndex = 3;
            label1.Text = "Czas oczekiwania (sekundy)";
            // 
            // LoginCHK
            // 
            LoginCHK.AutoSize = true;
            LoginCHK.Location = new Point(6, 22);
            LoginCHK.Name = "LoginCHK";
            LoginCHK.Size = new Size(187, 19);
            LoginCHK.TabIndex = 0;
            LoginCHK.Text = "Potwierdzenie po zalogowaniu";
            LoginCHK.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LogoutCloseCHK);
            groupBox2.Controls.Add(WorkEndCHK);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(WaitTimeLogoutCBX);
            groupBox2.Controls.Add(LogoutCHK);
            groupBox2.Location = new Point(12, 156);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(315, 132);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ustawienia wylogowania";
            // 
            // LogoutCloseCHK
            // 
            LogoutCloseCHK.AutoSize = true;
            LogoutCloseCHK.Location = new Point(6, 72);
            LogoutCloseCHK.Name = "LogoutCloseCHK";
            LogoutCloseCHK.Size = new Size(200, 19);
            LogoutCloseCHK.TabIndex = 6;
            LogoutCloseCHK.Text = "Zamknij system po wylogowaniu";
            LogoutCloseCHK.UseVisualStyleBackColor = true;
            // 
            // WorkEndCHK
            // 
            WorkEndCHK.AutoSize = true;
            WorkEndCHK.Location = new Point(6, 22);
            WorkEndCHK.Name = "WorkEndCHK";
            WorkEndCHK.Size = new Size(218, 19);
            WorkEndCHK.TabIndex = 5;
            WorkEndCHK.Text = "Powiadomienie o zakończeniu pracy";
            WorkEndCHK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 100);
            label2.Name = "label2";
            label2.Size = new Size(153, 15);
            label2.TabIndex = 4;
            label2.Text = "Czas oczekiwania (sekundy)";
            // 
            // WaitTimeLogoutCBX
            // 
            WaitTimeLogoutCBX.DropDownStyle = ComboBoxStyle.DropDownList;
            WaitTimeLogoutCBX.FormattingEnabled = true;
            WaitTimeLogoutCBX.Location = new Point(6, 97);
            WaitTimeLogoutCBX.Name = "WaitTimeLogoutCBX";
            WaitTimeLogoutCBX.Size = new Size(47, 23);
            WaitTimeLogoutCBX.TabIndex = 2;
            // 
            // LogoutCHK
            // 
            LogoutCHK.AutoSize = true;
            LogoutCHK.Location = new Point(6, 47);
            LogoutCHK.Name = "LogoutCHK";
            LogoutCHK.Size = new Size(191, 19);
            LogoutCHK.TabIndex = 1;
            LogoutCHK.Text = "Potwierdzenie po wylogowaniu";
            LogoutCHK.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(InformPanelCHK);
            groupBox3.Location = new Point(12, 294);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(315, 51);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Panel informacyjny";
            // 
            // InformPanelCHK
            // 
            InformPanelCHK.AutoSize = true;
            InformPanelCHK.Location = new Point(6, 22);
            InformPanelCHK.Name = "InformPanelCHK";
            InformPanelCHK.Size = new Size(99, 19);
            InformPanelCHK.TabIndex = 0;
            InformPanelCHK.Text = "Włącz/Wyłącz";
            InformPanelCHK.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(AutoStartCHK);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(315, 51);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ogólne";
            // 
            // AutoStartCHK
            // 
            AutoStartCHK.AutoSize = true;
            AutoStartCHK.Location = new Point(6, 22);
            AutoStartCHK.Name = "AutoStartCHK";
            AutoStartCHK.Size = new Size(185, 19);
            AutoStartCHK.TabIndex = 0;
            AutoStartCHK.Text = "Uruchom przy starcie systemu";
            AutoStartCHK.UseVisualStyleBackColor = true;
            // 
            // ConfirmBTN
            // 
            ConfirmBTN.Location = new Point(97, 351);
            ConfirmBTN.Name = "ConfirmBTN";
            ConfirmBTN.Size = new Size(75, 23);
            ConfirmBTN.TabIndex = 4;
            ConfirmBTN.Text = "Zapisz";
            ConfirmBTN.UseVisualStyleBackColor = true;
            ConfirmBTN.Click += ConfirmBtn_Click;
            // 
            // CancelBTN
            // 
            CancelBTN.Location = new Point(178, 351);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new Size(75, 23);
            CancelBTN.TabIndex = 5;
            CancelBTN.Text = "Anuluj";
            CancelBTN.UseVisualStyleBackColor = true;
            CancelBTN.Click += CancelBTN_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = ConfirmBTN;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBTN;
            ClientSize = new Size(339, 386);
            Controls.Add(CancelBTN);
            Controls.Add(ConfirmBTN);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ustawienia";
            TopMost = true;
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox LoginCHK;
        private GroupBox groupBox3;
        private CheckBox LogoutCHK;
        private ComboBox WaitTimeLoginCBX;
        private Label label1;
        private Label label2;
        private ComboBox WaitTimeLogoutCBX;
        private CheckBox InformPanelCHK;
        private CheckBox WorkEndCHK;
        private GroupBox groupBox4;
        private CheckBox AutoStartCHK;
        private Button ConfirmBTN;
        private Button CancelBTN;
        private CheckBox LogoutCloseCHK;
    }
}