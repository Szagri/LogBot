using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using Microsoft.VisualBasic.ApplicationServices;
using OverlayWidgetApp.Controllers;


namespace OverlayWidgetApp.Services
{
    public class ReminderService
    {
        private readonly ReminderController _controller;
        private readonly SettingsService _settings;
        private readonly UserDataService _user;
        private readonly LogoutService _logout;
        private bool _reminderShown = false;
        private DateTime _logoutTime;

        public readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public ReminderService(UserDataService user, SettingsService settings, ReminderController controller, LogoutService logout)
        {
            _settings = settings;
            _user = user;
            _controller = controller;
            _logout = logout;
        }
        /// <summary>
        /// Function that start timer time also can restart the timer
        /// </summary>
        public void Start()
        {
            timer.Stop();
            timer.Tick -= Tick;
            timer.Tick += Tick;
            timer.Interval = 1000;
            _reminderShown = false;

            if (_user.Date.TimeOfDay < TimeSpan.FromHours(7))
            {
                _logoutTime = new DateTime(_user.Date.Year, _user.Date.Month, _user.Date.Day, 15, 0, 0);
            }
            else
            {
                _logoutTime = _user.Date.AddHours(8);
            }

            timer.Start();
        }

        public void Tick(object sender, EventArgs e)
        {
            if (_reminderShown || !_settings.ShowMessageOnEndWork) return;

            if (DateTime.Now >= _logoutTime)
            {
                _reminderShown = true;
                _controller.Show();
            }
        }

        public void Delay(int wait)
        {
            _reminderShown = false;
            _logoutTime = DateTime.Now.AddMinutes(wait);
        }
    }
}
