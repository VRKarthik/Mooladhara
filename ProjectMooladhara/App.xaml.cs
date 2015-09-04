﻿using System.Threading;
using System.Windows;

namespace ProjectMooladhara
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ISplashScreen splashScreen;

        private ManualResetEvent ResetSplashCreated;
        private Thread SplashThread;

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // ManualResetEvent acts as a block. It waits for a signal to be set.
                ResetSplashCreated = new ManualResetEvent(false);

                // Create a new thread for the splash screen to run on
                SplashThread = new Thread(ShowSplash);
                SplashThread.SetApartmentState(ApartmentState.STA);
                SplashThread.IsBackground = true;
                SplashThread.Name = "Splash Screen";
                SplashThread.Start();

                // Wait for the blocker to be signaled before continuing. This is essentially the same as: while(ResetSplashCreated.NotSet) {}
                ResetSplashCreated.WaitOne();
                base.OnStartup(e);
            }
            catch { }
        }

        private void ShowSplash()
        {
            try
            {
                // Create the window
                Splash animatedSplashScreenWindow = new Splash();
                splashScreen = animatedSplashScreenWindow;

                // Show it
                animatedSplashScreenWindow.Show();

                // Now that the window is created, allow the rest of the startup to run
                ResetSplashCreated.Set();
                System.Windows.Threading.Dispatcher.Run();
            }
            catch { }
        }
    }
}