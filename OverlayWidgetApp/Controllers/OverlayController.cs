using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp.Controllers
{
    public class OverlayController
    {
        private OverlayForm _overlayForm;
        private UserDataService _user;
        private readonly SettingsService _settings;
        public OverlayController(UserDataService user, SettingsService settings)
        {
            _user = user;
            _settings = settings;
        }

        public void Show()
        {
            if (_settings.ShowInformationPanel)
            {
                if(_overlayForm == null || _overlayForm.IsDisposed)
                {
                    _overlayForm = new OverlayForm();
                    _overlayForm.Start(_user.Date);
                    _overlayForm.Show();
                }
                else
                {
                    _user.RefreshDate();
                    _overlayForm.Start(_user.Date);
                }
            }
        }

        public void Hide()
        {
            if (_overlayForm != null && !_overlayForm.IsDisposed)
            {
                _overlayForm.Close();
                _overlayForm.Dispose();
                _overlayForm = null;
            }
        }

        public void Refresh()
        {
            if (_settings.ShowInformationPanel)
            {
                _user.RefreshDate();
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}
