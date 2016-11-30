using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using System.IO;

namespace AppPerformance
{
    public class AppAnalytics : Fiddler.IAutoTamper3
    {
        public AppAnalytics()
        {
            ApiFilter = "http://localhost:5555/api";
        }

        public string ApiFilter { get; set; }
        public bool ApiAnalyticsRunning { get; set; }
        public string ReportFile { get; set; }

        private static object _lockWriteFile = new object();




        public void OnLoad()
        {
            var menuList = FiddlerApplication.UI.mnuMain.MenuItems.Cast<System.Windows.Forms.MenuItem>();
            var menuTools = menuList.FirstOrDefault(a => a.Text == "&Tools");

            if (menuTools != null)
            {
                //menuTools.MenuItems.Add("-");
                menuTools.MenuItems.Add(FiddlerMenu.InitializeMenu(this));
            }
        }


        public void AutoTamperRequestAfter(Session oSession)
        {
            
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            if ((ApiAnalyticsRunning) && oSession.fullUrl.StartsWith(ApiFilter.ToLower(), StringComparison.InvariantCultureIgnoreCase))
            {
                var a = DateTime.Now - oSession.Timers.ClientBeginRequest;

                lock (_lockWriteFile)
                {
                    File.AppendAllLines(ReportFile, new string[] 
                    {
                        $"{oSession.RequestMethod},{oSession.fullUrl},{a},{oSession.requestBodyBytes.Length},{oSession.responseBodyBytes.Length}"
                    });
                }
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {
            
        }

        public void OnBeforeUnload()
        {
            
        }

        

        public void OnPeekAtRequestHeaders(Session oSession)
        {
            
        }

        public void OnPeekAtResponseHeaders(Session oSession)
        {
            
        }
    }
}
