using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NetStatWPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register SyncFusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ0MzUzQDMxMzgyZTMxMmUzMENPdnNTdDFPRHJPeUc5cVBXVDRzU3ZzMGV0bExUekJ3YWE5aUg3TTVPaU09");
        }
    }
}
