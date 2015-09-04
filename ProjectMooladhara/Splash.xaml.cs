using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Reflection;

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