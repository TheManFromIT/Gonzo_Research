using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gonzo.Microservice;
using Gonzo.Networking;

namespace Gonzo
{
    public partial class FormMain : Form
    {

        private readonly Nose _nozyParker;

        public FormMain()
        {
            InitializeComponent();

            _nozyParker = new Nose(Utils.GetNetworkIpAddress(), Properties.Settings.Default.MaliciousBSSID, Properties.Settings.Default.PingSiteList, Properties.Settings.Default.PingBody, Properties.Settings.Default.PingTimeout);

            _nozyParker.WifiConnected += HandleNozyParkerWifiConnected;
            _nozyParker.WifiDisconnecting += _nozyParker_WifiDisconnecting;
            _nozyParker.LogMessage += _nozyParker_LogMessage;
            _nozyParker.Startup();

        }

        private void _nozyParker_LogMessage(object sender, MessageEvents e)
        {
            tailvewLog.Append(e.Message);
        }


        private void _nozyParker_WifiDisconnecting(object sender, EventArgs e)
        {

        }

        private void HandleNozyParkerWifiConnected(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void HandlePingTest(object sender, EventArgs e)
        {
            if (_nozyParker.VerifyInternet() == false)
                tailvewLog.Append($"\r\f Failed");
            else tailvewLog.Append($"\r\f Sucesss");
        }

        private void butListNeworks_Click(object sender, EventArgs e)
        {

            _nozyParker.GetActiveAccesPoints();

        }

        private void butLoadOUIDB_Click(object sender, EventArgs e)
        {
            var db = new OuiDb();

            db.Load();
        }
    }
}
