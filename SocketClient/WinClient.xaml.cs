using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;

namespace SocketClient
{
    /// <summary>
    ///     WinClient.xaml 的交互逻辑
    /// </summary>
    public partial class WinClient : Window
    {
        private readonly List<IPAddress> _ipAddresses = new List<IPAddress>();

        public WinClient()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetLocalIpAddress();
            LocalIpCombox.Items.Clear();
            foreach (IPAddress ipAddress in _ipAddresses)
            {
                LocalIpCombox.Items.Add(ipAddress);
            }
            LocalIpCombox.SelectedIndex = 0;
        }

        private void GetLocalIpAddress()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection allAddress = adapterProperties.UnicastAddresses;

                IPAddress[] ips = (from add in allAddress
                                   where add.Address.AddressFamily == AddressFamily.InterNetwork
                                   select add.Address).ToArray();

                _ipAddresses.AddRange(ips);
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {


            MsgTextBox.Clear();
        }
    }
}