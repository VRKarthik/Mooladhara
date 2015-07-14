using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMooladhara
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : MetroWindow, ISplashScreen
    {
        public Splash()
        {
            InitializeComponent();

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            //lblAppName.Content = versionInfo.ProductName;
            //lblAppDescription.Content = versionInfo.Comments;
            //lblCompany.Content = versionInfo.CompanyName;
            //lblVersion.Content = "Version " + versionInfo.ProductVersion;
        }

        private void SplashScreen_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void SplashScreen_Initialized(object sender, System.EventArgs e)
        {
        }

        public void AddMessage(string message)
        {
            Dispatcher.Invoke((Action)delegate()
            {
                this.lblStatus.Content = message;
            });
        }

        public void LoadComplete()
        {
            Dispatcher.InvokeShutdown();
        }
    }

    public interface ISplashScreen
    {
        void AddMessage(string message);
        void LoadComplete();
    }
}
