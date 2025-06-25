using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayWidgetApp
{
    public partial class ReminderForm : Form
    {
        private readonly Action _onLogout, _onDelay;
        public int delay { get; private set; } = 0;
        public ReminderForm(Action onLogout, Action onDelay)
        {
            InitializeComponent();
            _onLogout = onLogout;
            _onDelay = onDelay;
        }

        private void LogoutBTN_Click(object sender, EventArgs e)
        {
            _onLogout.Invoke();
        }

        private void DelayBTN_Click(object sender, EventArgs e)
        {
            delay = (int)NumberTXB.Value;
            _onDelay.Invoke();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
