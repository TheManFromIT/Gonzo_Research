using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gonzo.Microservice;
using Gonzo.Networking;
using MacAddressVendorLookup;
using wclWiFi;

namespace Gonzo
{

    public class Nose
    {

        public const string TOXIC_MAC = "aa:40:a0:6f:04:a7";

        public const string CHROME_CAST = "FA:8F:CA";

        public event EventHandler WifiDisconnecting;
        public event EventHandler WifiConnected;
        public event EventHandler<MessageEvents> LogMessage;

        private wclWiFiClient _wiFiClient;
        private wclWiFiProfilesManager _profilesManager;
        private wclWiFiEvents _wiFiEvents;

        private readonly IPAddress _localIpAddress;
        private readonly string _maliciousBssid;
        private readonly StringCollection _pingSiteList;
        private readonly Guid _pingBody;
        private readonly TimeSpan _pingTimeout;
        private ICMPio _pingGenerator;

        private readonly AutoResetEvent _waitForResponseEvent = new AutoResetEvent(false);
        private readonly AutoResetEvent _waitForScanCompleteEvent = new AutoResetEvent(false);


        private IPAddress _currentPingAddress;

        //private AddressMatcher ouiDb;
        private OuiDb ouiDb = new OuiDb();

        public Nose(IPAddress localIpAddress, String maliciousBSSID, StringCollection pingSiteList, Guid pingBody, TimeSpan pingTimeout)
        {

            _localIpAddress = localIpAddress;
            _maliciousBssid = maliciousBSSID;
            _pingSiteList = pingSiteList;
            _pingBody = pingBody;
            _pingTimeout = pingTimeout;
        }

        public void Startup()
        {
            ouiDb.Load();

            SetupHostPing();

            SetupWifiScanner();
        }

        private void SetupHostPing()
        {
            _pingGenerator = new ICMPio(_localIpAddress);

            _pingGenerator.onPingReceive += HandlePingReceive;

        }

        private void SetupWifiScanner()
        {

            _wiFiClient = new wclWiFiClient();
            _wiFiClient.AfterOpen += HandleWiFiClientAfterOpen;
            _wiFiClient.BeforeClose += HandleWiFiClientBeforeClose;

            _profilesManager = new wclWiFiProfilesManager();

            _wiFiClient.Open();

            _wiFiEvents = new wclWiFiEvents();

            _wiFiEvents.OnAcmScanComplete += HandleOnAcmScanComplete;

        }

        private void HandleOnAcmScanComplete(object Sender, Guid IfaceId)
        {
            _waitForScanCompleteEvent.Set();
        }

        public void Log(string message)
        {
            LogMessage?.Invoke(this, new MessageEvents() { Message = $"[{DateTime.Now.ToShortDateString()}] [{DateTime.Now.ToLongTimeString()}] {message}" });
        }

        public List<AccessPoint> GetActiveAccesPoints()
        {

            //wclNetworkListManager networkListManager = new wclNetworkListManager();

            //networkListManager.Open();

            //wclNlmNetwork[] networks = null;

            //networkListManager.GetNetworks(wclNlmEnumNetwork.nlmEnumAll, out networks);

            //wclNlmConnection[] connections = null;

            //networkListManager.GetConnections(out connections);
            
            wclWiFiInterfaceData[] networkInterfaces = null;

            _wiFiClient.EnumInterfaces(out networkInterfaces);

            wclWiFiSniffer sniffer = new wclWiFiSniffer();            

            sniffer.OnRawFrameReceived += Sniffer_OnRawFrameReceived;

            foreach (var newtworkInterface in networkInterfaces)
            {
                Log($"{newtworkInterface.Description} {newtworkInterface.Id:N}");

                if (!sniffer.Active)
                {

                    sniffer.Open(newtworkInterface.Id);

                }

                _wiFiClient.Scan(newtworkInterface.Id, String.Empty);

                _waitForScanCompleteEvent.WaitOne(TimeSpan.FromMilliseconds(1500));

                wclWiFiBss[] bssList = null;

                var ssid = String.Empty;

                _wiFiClient.EnumBss(newtworkInterface.Id, ssid, wclWiFiBssType.bssAny, false, out bssList);

                if (bssList != null)
                {
                    foreach (var bss in bssList)
                    {                                               
                        

                        string type = bss.Mac.Equals(TOXIC_MAC, StringComparison.CurrentCultureIgnoreCase) ? "<<<< THIEVING BASTARTS" : String.Empty;

                        string status = bss.Mac.StartsWith(CHROME_CAST, StringComparison.CurrentCultureIgnoreCase) && String.IsNullOrEmpty(bss.Ssid) ? "CHROME CAST?" : String.Empty;

                        string mode = String.IsNullOrWhiteSpace(bss.Ssid) ? "<<< STEALTH >>>" : String.Empty;

                        string manufacturer = String.Empty;

                        OuiRecord record = null;

                        if (ouiDb.TryFind(bss.Mac, out record))
                        {
                            manufacturer = record.Manufacturer;
                        }

                        Log($"{bss.ChCenterFrequency} {bss.Ssid} {bss.Mac} {bss.Rssi} {type} {status} {mode} {manufacturer} {bss.PhyId}");
                    }
                }

            }

            return null;
        }

        private void Sniffer_OnRawFrameReceived(object Sender, byte[] Buffer)
        {
            var data = UTF8Encoding.UTF8.GetString(Buffer);
        }

        private void HandleWiFiClientBeforeClose(object sender, EventArgs e)
        {
            Log("Wifi Disconnecting!");

            WifiDisconnecting?.Invoke(this, new EventArgs());
        }

        private void HandleWiFiClientAfterOpen(object sender, EventArgs e)
        {

            Log("Wifi Connected");

            WifiConnected?.Invoke(this, new EventArgs());
        }

        protected virtual void HandlePingReceive(IPAddress remoteEndPoint, int packetSize, byte[] packetBody)
        {
            if (remoteEndPoint.Equals(_currentPingAddress))
            {
                _waitForResponseEvent.Set();
            }
        }

        public Boolean VerifyInternet()
        {
            foreach (var hostName in _pingSiteList.OfType<String>())
            {
                var hostEntry = Dns.GetHostEntry(hostName);

                foreach (var ipAddress in hostEntry.AddressList)
                {

                    lock (_currentPingAddress)
                    {
                        _currentPingAddress = ipAddress;
                    }

                    _pingGenerator.sendPacket(ipAddress, Encoding.UTF8.GetBytes(_pingBody.ToString("N")));

                    if (_waitForResponseEvent.WaitOne(_pingTimeout))
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }




    }

    public class AccessPoint
    {

        public string SSID { get; internal set; }
        public string BSSID { get; internal set; }
        public int Channel { get; internal set; }
        public FrequencyBand Frequency { get; internal set; }
        public uint Strength { get; internal set; }

    }

    public enum FrequencyBand
    {
        TwoPointFour,
        Five
    }

    public class MessageEvents : EventArgs
    {
        public string Message { get; internal set; }
    }
}
