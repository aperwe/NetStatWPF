using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetStatWPF.Test
{
    [TestClass]
    public class UnitTestSyncFusion
    {
        [TestMethod]
        public void TestLicenseActivation()
        {
            string licenseKey = "MjQ0MzUzQDMxMzgyZTMxMmUzMENPdnNTdDFPRHJPeUc5cVBXVDRzU3ZzMGV0bExUekJ3YWE5aUg3TTVPaU09";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            Assert.IsTrue(true, "License registered successfully"); //Will not reach this if something fails.
        }
    }
}
