using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp.Controllers
{
    public class ReminderController
    {
        private readonly LogoutService _logout;
        private readonly ReminderService _reminder;
        private ReminderForm _reminderForm;
        public ReminderController(UserDataService user, SettingsService settings, LogoutService logout) 
        {
            _logout = logout;
            _reminder = new ReminderService(user, settings, this, logout);
        }
        public void Show()
        {
            if (_reminderForm == null || _reminderForm.IsDisposed)
            {
                _reminderForm = new ReminderForm(
                onLogout: () =>
                {
                    _reminderForm.Close();
                    _reminderForm.Dispose();
                    _logout.LogoutUser();
                },
                onDelay: () =>
                {
                    _reminder.Delay(_reminderForm.delay);
                    _reminderForm.Close();
                    _reminderForm.Dispose();
                });

                _reminderForm.ShowDialog();
            }
            else
            {
                _reminderForm.BringToFront();
                _reminderForm.Activate();
            }
        }

        public void Start() => _reminder.Start();
    }
}
