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
            var psi = new ProcessStartInfo(command, args);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            var netStatCommand = Process.Start(psi);
            //netStatCommand.WaitForExit();
            var output = netStatCommand.StandardOutput.ReadToEnd();
            Output.Text = output;
            netStatDataSet.MainTable.AddMainTableRow(DateTime.Now, output);
            NumEntriesTextBlock.Text = string.Format("{0}", netStatDataSet.MainTable.Count);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            netStatDataSet.WriteXml("NetStatWPF.db.xml");
        }
    }
}
