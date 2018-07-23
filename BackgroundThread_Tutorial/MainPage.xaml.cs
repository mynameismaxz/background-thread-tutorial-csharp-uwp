using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundThread_Tutorial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// refer : https://www.tutorialspoint.com/windows10_development/windows10_development_background_execution.htm
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();

            switch (access)
            {
                case BackgroundAccessStatus.Unspecified:
                    break;
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.Denied:
                    break;
                default:
                    break;
            }

            var task = new BackgroundTaskBuilder
            {
                Name = "Test Task",
                TaskEntryPoint = typeof(BackgroundStuff.MyBackgroundTask).ToString()
            };

            var trigger = new ApplicationTrigger();
            task.SetTrigger(trigger);

            await trigger.RequestAsync();
        }
    }
}
