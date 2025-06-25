using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlayWidgetApp.Controllers;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp
{
    /// <summary>
    /// Class for gathering all obcjects in project, if you want start any service or controller here you should start it
    /// </summary>
    public class AppCore
    {
        public AutoLoginController Login { get; private set; }
        public LogoutService Logout { get; private set; }
        public SettingsService Settings { get; private set; }
        public UserDataService User { get; private set; }
        public OverlayController Overlay { get; private set; }
        public RegistrationController Registration { get; private set; }
        public ReminderController Reminder { get; private set; }
        public StateCheckerService State { get; private set; }

        public AppCore()
        {
            Settings = SettingsService.Load();
            User = UserDataService.Load();
            Registration = new RegistrationController(User);
        }
        /// <summary>
        /// Function that Initializate objects that is feature of program not a core objects to program start, they should be in right order
        /// </summary>
        public void Ini()
        {
            Overlay = new OverlayController(User, Settings);
            State = new StateCheckerService();
            Login = new AutoLoginController(User, Settings, Overlay, State);
            Login.Show();

            Logout = new LogoutService(User, Settings);
            Reminder = new ReminderController(User, Settings, Logout);
        }
    }
}
