using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gonzo.Networking;
using MacAddressVendorLookup;
using wclWiFi;

namespace Gonzo
{
    public partial class FormMain : Form
    {

        delegate void NetworkListAddDelegate(Guid networkId);
        delegate void NetworkListDeleteDelegate(Guid networkId);

        private readonly Nose _nozyParker;

        private readonly wclNetworkListManager _networkListManager = new wclNetworkListManager();

        public FormMain()
        {
            InitializeComponent();

            _nozyParker = new Nose(Utils.GetNetworkIpAddress(), Properties.Settings.Default.MaliciousBSSID, Properties.Settings.Default.PingSiteList, Properties.Settings.Default.PingBody, Properties.Settings.Default.PingTimeout);

            _nozyParker.WifiConnected += HandleNozyParkerWifiConnected;
            _nozyParker.WifiDisconnecting += _nozyParker_WifiDisconnecting;
            _nozyParker.LogMessage += _nozyParker_LogMessage;
            _nozyParker.Startup();

            _networkListManager.OnNetworkAdded += _networkListManager_OnNetworkAdded;
            _networkListManager.OnNetworkDeleted += _networkListManager_OnNetworkDeleted;

            _networkListManager.AfterOpen += _networkListManager_AfterOpen;

            _networkListManager.Open();


        }

        private void _networkListManager_AfterOpen(object sender, EventArgs e)
        {
            lstvewNetworks.Enabled = true;
        }

        private void _networkListManager_OnNetworkDeleted(object Sender, Guid NetworkId)
        {
            if (lstvewNetworks.InvokeRequired)
            {
                lstvewNetworks.Invoke(new NetworkListAddDelegate(AddNetwork), new[] {NetworkId});
            }
            else
            {
                AddNetwork(NetworkId);
            }
        }

        private void _networkListManager_OnNetworkAdded(object Sender, Guid NetworkId)
        {
            if (lstvewNetworks.InvokeRequired)
            {
                lstvewNetworks.Invoke(new NetworkListDeleteDelegate(DeleteNetwork), new[] { NetworkId });
            }
            else
            {
                DeleteNetwork(NetworkId);
            }
        }

        private void AddNetwork(Guid networkId)
        {
            var key = networkId.ToString("N");

            if (!lstvewNetworks.Items.ContainsKey(key))
            {
                lstvewNetworks.Items.Add(key, "Network", 1);
            }
        }

        private void DeleteNetwork(Guid networkId)
        {
            var key = networkId.ToString("N");

            if (!lstvewNetworks.Items.ContainsKey(key))
            {
                lstvewNetworks.Items.Remove(lstvewNetworks.Items[key]);
            }
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
            var vendorInfoProvider = new MacAddressVendorLookup.MacVendorBinaryReader();
            using (var resourceStream = MacAddressVendorLookup.ManufBinResource.GetStream().Result)
            {
                vendorInfoProvider.Init(resourceStream).Wait();
            }
            var addressMatcher = new MacAddressVendorLookup.AddressMatcher(vendorInfoProvider);

            var networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                .Where(ni => ni.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Tunnel)
                .Where(ni => ni.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                .Where(ni => !ni.GetPhysicalAddress().Equals(System.Net.NetworkInformation.PhysicalAddress.None));

            foreach (var ni in networkInterfaces)
            {
                var vendorInfo = addressMatcher.FindInfo(ni.GetPhysicalAddress());
                tailvewLog.Append("\nAdapter: " + ni.Description);
                tailvewLog.Append($"\t{vendorInfo}");
                var macAddr = BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes()).Replace('-', ':');
                tailvewLog.Append($"\tMAC Address: {macAddr}");
            }
        }
    }
}
