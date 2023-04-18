using OtherCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQlliT3xTdEdnXnZadnU=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXpScEdjW31ad31TRmE=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Xd0NhWX1cdHNcQWRd;MTc0MTcyMUAzMjMxMmUzMTJlMzMzNURNWFBiTTd4TmNMYVZRR1QweG8vWXBRbGRwUzBHZ2V3YjkzUXNneWdrbms9;MTc0MTcyMkAzMjMxMmUzMTJlMzMzNUhZZFJFTkVqNXYyNVRMNDNmaU13RkJhYzBIb1dVWWVwQlVic2VYNHAzakk9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TckRlW39ccnBdRmReUA==;MTc0MTcyNEAzMjMxMmUzMTJlMzMzNUdVMm5FbVZyTHQ4WUllV25lY1J4eGVxdWhjSFBFZzk3U3ZkeDA1TThvK0E9;MTc0MTcyNUAzMjMxMmUzMTJlMzMzNW9NK2tFN3lkaktXNU1sQi8vYUFPTXFMdVI3NythRnBjd3BEQzYrYzJoM0U9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Xd0NhWX1cdHxURGhd;MTc0MTcyN0AzMjMxMmUzMTJlMzMzNVk0a0RDOGNKSmN6YUpDT0w2bHBrMGx4c1lQdkpORjRGTlRhcnpsalNiL009;MTc0MTcyOEAzMjMxMmUzMTJlMzMzNVlsbm12R3RzMDZsVm1pZ1o3b0lwemdtMjZ0UmFJblJyMERRM0hSRWUxZmM9;MTc0MTcyOUAzMjMxMmUzMTJlMzMzNUdVMm5FbVZyTHQ4WUllV25lY1J4eGVxdWhjSFBFZzk3U3ZkeDA1TThvK0E9");
            //Application.Run(new GranttChart());
            Application.Run(new Form1());

        }
    }
}
