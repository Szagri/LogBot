using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace OverlayWidgetApp.Services
{
    public class StateCheckerService
    {
        public StateCheckerService() { }

        public bool CheckState()
        {
            try
            {
                using var enumerator = new MMDeviceEnumerator();
                var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                if (device == null || device.FriendlyName == null)
                {
                    return false;
                }
                return device.FriendlyName.Contains("Audio zdalne", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd audio: {ex.Message}", "Błąd audio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
 