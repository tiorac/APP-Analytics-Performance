using Fiddler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPerformance
{
    public static class FiddlerMenu
    {
        private static AppAnalytics appAnalytics;

        private static MenuItem mnuAppPerformance;
        private static MenuItem mnuRunAnalytics;
        private static MenuItem mnuConfig;



        public static MenuItem InitializeMenu(AppAnalytics analytics)
        {
            appAnalytics = analytics;

            mnuAppPerformance = new MenuItem("&APP Analytics Performance");
            mnuAppPerformance.Index = 0;

            mnuRunAnalytics = new MenuItem("&Run APP Analytics");
            mnuRunAnalytics.Click += MnuRunAnalytics_Click;

            mnuConfig = new MenuItem("&Config");
            mnuConfig.Click += MnuConfig_Click;

            mnuAppPerformance.MenuItems.Add(mnuRunAnalytics);
            mnuAppPerformance.MenuItems.Add("-");
            mnuAppPerformance.MenuItems.Add(mnuConfig);

            return mnuAppPerformance;
        }

        private static void MnuConfig_Click(object sender, EventArgs e)
        {
            var configWindow = new AppPerformanceConfig(appAnalytics);
            
            configWindow.ShowDialog(FiddlerApplication.UI);
        }

        private static void MnuRunAnalytics_Click(object sender, EventArgs e)
        {
            appAnalytics.ApiAnalyticsRunning = !appAnalytics.ApiAnalyticsRunning;
            mnuRunAnalytics.Checked = appAnalytics.ApiAnalyticsRunning;

            if (appAnalytics.ApiAnalyticsRunning)
            {
                StartRun();
            }
            else
            {
                MessageBox.Show("Analytics Stopped!!!", "APP Analytics Performance");
            }
        }

        private static void StartRun()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Comma-Separated Values |*.csv";
            saveFileDialog.Title = "Report File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                appAnalytics.ReportFile = saveFileDialog.FileName;

                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);

                var lines = new List<string>();
                lines.Add("sep=,");
                lines.Add("Method,Url,Time,Request Size,Response Size");

                File.WriteAllLines(saveFileDialog.FileName, lines);
            }
        }
    }
}
