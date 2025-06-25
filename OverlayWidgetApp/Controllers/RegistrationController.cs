using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using OverlayWidgetApp;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp.Controllers
{
    public class RegistrationController
    {
        private RegistrationForm _registrationForm;
        private readonly UserDataService _user;

        public RegistrationController(UserDataService user)
        {
            _user = user;
        }

        public void Show()
        {
            if (_registrationForm == null || _registrationForm.IsDisposed)
            {
                using (_registrationForm = new RegistrationForm(_user))
                {
                    _registrationForm.ShowDialog();
                }
            }
            else
            {
                _registrationForm.BringToFront();
                _registrationForm.Activate();
            }
        }
    }
}
