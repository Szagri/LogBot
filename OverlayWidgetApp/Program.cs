namespace OverlayWidgetApp
{
    internal static class Program
    {
        private static NotifyIcon trayIcon;
        private static ContextMenuStrip menu;
        /// <summary>
        /// Main function of program
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsForm settingsForm = null;
            try
            {
                //creating object of main classes with data
                AppCore core = new AppCore();
                //checking if it's first bootup and have to create a user
                if (string.IsNullOrWhiteSpace(core.User.Login) || string.IsNullOrWhiteSpace(core.User.Password))
                {
                    core.Registration.Show();
                }
                //if user exists program bootup
                if(!string.IsNullOrWhiteSpace(core.User.Login) && !string.IsNullOrWhiteSpace(core.User.Password))
                {
                    //start of rest objects that not storage data
                    core.Ini();

                    //creating tray icon with menu and adding items to it
                    trayIcon = new NotifyIcon();
                    menu = new ContextMenuStrip();

                    trayIcon.Text = "LogBot";
                    trayIcon.Icon = new Icon(Path.Combine(AppContext.BaseDirectory, "Images", "log.ico"));

                    menu.Items.Add(new ToolStripMenuItem("Wyloguj", null, (s, e) => core.Logout.LogoutUser())
                    {
                        BackColor = Color.LightCoral
                    });
                    if(core.User.Date.Date != DateTime.Today.Date)
                    {
                        menu.Items.Add(new ToolStripMenuItem("Zaloguj", null, (s, e) => core.Login.Show())
                        {
                            BackColor = Color.YellowGreen
                        });
                    }
                    menu.Items.Add(new ToolStripMenuItem("Ustawienia", null, (s, e) =>
                    {
                        if (settingsForm == null || settingsForm.IsDisposed)
                        {
                            settingsForm = new SettingsForm(core.Settings);
                            settingsForm.OnSettingsChanged = () => core.Overlay.Refresh();
                            settingsForm.FormClosed += (sender2, args) => settingsForm = null;
                            settingsForm.Show();
                        }
                        else
                        {
                            settingsForm.BringToFront();
                            settingsForm.Activate();
                        }
                    }));
                    menu.Items.Add(new ToolStripMenuItem("Zmiana Has³a", null, (s, e) => core.Registration.Show()));
                    menu.Items.Add(new ToolStripMenuItem("Zamknij", null, (s, e) => Application.Exit()));

                    trayIcon.ContextMenuStrip = menu;
                    trayIcon.Visible = true;
                    //starting reminder if it's on in options for pop up window when work is ended 
                    core.Reminder.Start();
                    core.Overlay.Show();

                    Application.Run();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d: {ex.Message}");
            }
        }
    }
}
