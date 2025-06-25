using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp.Controllers
{
    public class AutoLoginController
    {
        private readonly UserDataService _user;
        private readonly SettingsService _settings;
        private AutoLoginService _autoLoginService;
        private readonly OverlayController _overlay;
        private readonly StateCheckerService _state;
        public AutoLoginController(UserDataService user, SettingsService settings, OverlayController overlay, StateCheckerService state) 
        {
            _user = user;
            _settings = settings;
            _overlay = overlay;
            _state = state;
        }

        public void Show ()
        {
            _autoLoginService = new AutoLoginService(_user, _settings, onLogin: () => _overlay.Show(), _state);
            _autoLoginService.LoginUser();
        }
    }
}
