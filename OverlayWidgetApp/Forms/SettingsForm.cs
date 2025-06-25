using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settings;
        public Action? OnSettingsChanged;

        public SettingsForm(SettingsService settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var values = new object[] { 5, 10, 20, 30, 45, 60 };
            WaitTimeLoginCBX.Items.AddRange(values);
            WaitTimeLogoutCBX.Items.AddRange(values);
            WaitTimeLoginCBX.SelectedItem = _settings.WaitTimeLogin;
            WaitTimeLogoutCBX.SelectedItem = _settings.WaitTimeLogout;
            AutoStartCHK.Checked = IsAutoStartEnabled();
            LoginCHK.Checked = _settings.ShowMessageOnLogin;
            LogoutCHK.Checked = _settings.ShowMessageOnLogout;
            WorkEndCHK.Checked = _settings.ShowMessageOnEndWork;
            LogoutCloseCHK.Checked = _settings.CloseSystemOnLogout;
            InformPanelCHK.Checked = _settings.ShowInformationPanel;
        }

        private static void EnableAutoStart()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                key.SetValue("LogBot", AppPaths.exePath);
            }
        }

        private static void DisableAutoStart()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (key.GetValue("LogBot") != null)
                {
                    key.DeleteValue("LogBot");
                }
            }
        }

        private static bool IsAutoStartEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false))
            {
                var value = key?.GetValue("LogBot") as string;
                return value == System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AutoStartCHK.Checked)
                {
                    EnableAutoStart();
                }
                else
                {
                    DisableAutoStart();
                }
                _settings.ShowMessageOnLogin = LoginCHK.Checked;
                _settings.ShowMessageOnLogout = LogoutCHK.Checked;
                _settings.ShowMessageOnEndWork = WorkEndCHK.Checked;
                _settings.ShowInformationPanel = InformPanelCHK.Checked;
                _settings.CloseSystemOnLogout = LogoutCloseCHK.Checked;
                _settings.WaitTimeLogin = (int)WaitTimeLoginCBX.SelectedItem;
                _settings.WaitTimeLogout = (int)WaitTimeLogoutCBX.SelectedItem;
                _settings.Save();
                OnSettingsChanged?.Invoke();
                this.Close();
                this.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisu ustawień: {ex.Message}", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

        }
    }
}
