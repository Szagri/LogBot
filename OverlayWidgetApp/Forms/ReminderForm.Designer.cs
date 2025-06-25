namespace OverlayWidgetApp
{
    partial class ReminderForm
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
            LogoutBTN = new Button();
            DelayBTN = new Button();
            CloseBTN = new Button();
            NumberTXB = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)NumberTXB).BeginInit();
            SuspendLayout();
            // 
            // LogoutBTN
            // 
            LogoutBTN.Location = new Point(24, 76);
            LogoutBTN.Name = "LogoutBTN";
            LogoutBTN.Size = new Size(75, 23);
            LogoutBTN.TabIndex = 0;
            LogoutBTN.Text = "Wyloguj";
            LogoutBTN.UseVisualStyleBackColor = true;
            LogoutBTN.Click += LogoutBTN_Click;
            // 
            // DelayBTN
            // 
            DelayBTN.Location = new Point(105, 76);
            DelayBTN.Name = "DelayBTN";
            DelayBTN.Size = new Size(75, 23);
            DelayBTN.TabIndex = 1;
            DelayBTN.Text = "Czekaj";
            DelayBTN.UseVisualStyleBackColor = true;
            DelayBTN.Click += DelayBTN_Click;
            // 
            // CloseBTN
            // 
            CloseBTN.Location = new Point(186, 76);
            CloseBTN.Name = "CloseBTN";
            CloseBTN.Size = new Size(75, 23);
            CloseBTN.TabIndex = 2;
            CloseBTN.Text = "Zamknij";
            CloseBTN.UseVisualStyleBackColor = true;
            CloseBTN.Click += CloseBTN_Click;
            // 
            // NumberTXB
            // 
            NumberTXB.Location = new Point(125, 47);
            NumberTXB.Name = "NumberTXB";
            NumberTXB.Size = new Size(39, 23);
            NumberTXB.TabIndex = 3;
            NumberTXB.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(260, 35);
            label1.TabIndex = 4;
            label1.Text = "Zakończyłeś pracę. Możesz się teraz wylogować albo przypomnieć o tym później.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReminderForm
            // 
            AcceptButton = LogoutBTN;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseBTN;
            ClientSize = new Size(284, 111);
            Controls.Add(label1);
            Controls.Add(NumberTXB);
            Controls.Add(CloseBTN);
            Controls.Add(DelayBTN);
            Controls.Add(LogoutBTN);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReminderForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Praca zakończona";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)NumberTXB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button LogoutBTN;
        private Button DelayBTN;
        private Button CloseBTN;
        private NumericUpDown NumberTXB;
        private Label label1;
    }
}