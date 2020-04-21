using NetStatWPF.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetStatWPF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NetStatDataSet netStatDataSet;
        public MainWindow()
        {
            InitializeComponent();
            netStatDataSet = new NetStatDataSet();
        }

        private void GetBtn_Click(object sender, RoutedEventArgs e)
        {
            var command = "netstat";
            var args = "-s";
            var psi = new ProcessStartInfo(command, args)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var netStatCommand = Process.Start(psi);
            //netStatCommand.WaitForExit();
            var output = netStatCommand.StandardOutput.ReadToEnd();
            Output.Text = output;
            CreateDataSetHierarchy(output);
            NumEntriesTextBlock.Text = string.Format("{0}", netStatDataSet.MainTable.Count);

        }
        void CreateDataSetHierarchy(string output)
        {
            var mainRow = netStatDataSet.MainTable.AddMainTableRow(DateTime.Now, output); //parent row

            NetStatDataRecord parsedObject = NetStatOutputParser.ParseFromString(mainRow.UnparsedOutput); //parsed temporary object

            var topRecord = netStatDataSet.NetStatDataRecordTable.AddNetStatDataRecordTableRow(mainRow);
            var ipv4Record = netStatDataSet.IPv4StatisticsTable.AddIPv4StatisticsTableRow(topRecord, parsedObject.IPv4Statistics);
            var ipv6Record = netStatDataSet.IPv6StatisticsTable.AddIPv6StatisticsTableRow(topRecord, parsedObject.IPv6Statistics);
            
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            netStatDataSet.WriteXml("NetStatWPF.db.xml");
        }

        private void ChartBtn_Click(object sender, RoutedEventArgs e)
        {
            Charts.DashboardChart dashboardChart = new Charts.DashboardChart();
            dashboardChart.ShowDialog();
        }
    }
}
