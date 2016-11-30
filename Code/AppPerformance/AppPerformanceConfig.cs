using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPerformance
{
    public partial class AppPerformanceConfig : Form
    {
        public AppPerformanceConfig(AppAnalytics analytics)
        {
            appAnalytics = analytics;
            InitializeComponent();

            textApiFilter.Text = analytics.ApiFilter;
        }

        private AppAnalytics appAnalytics;

        private void save_Click(object sender, EventArgs e)
        {
            appAnalytics.ApiFilter = textApiFilter.Text;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
