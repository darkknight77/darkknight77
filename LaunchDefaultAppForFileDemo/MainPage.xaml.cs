using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaunchDefaultAppForFileDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        async void DefaultLaunch()
        {
            // Path to the file in the app package to launch
            //string imageFile = @"images\test.png";

            //var file = await Storage
                
            StorageFolder storageFolder = KnownFolders.PicturesLibrary;
            // StorageFile file = await storageFolder.CreateFileAsync("sample.png", CreationCollisionOption.ReplaceExisting);
            StorageFile file = await storageFolder.GetFileAsync("sample.jpg");
            if (file != null)
            {
                // Launch the retrieved file
                var success = await Windows.System.Launcher.LaunchFileAsync(file);

                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }

        async void DefaultLaunchWithOptions()
        {
            // Path to the file in the app package to launch
            // string imageFile = @"images\test.png";

            //  var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            StorageFolder storageFolder = KnownFolders.PicturesLibrary;
            StorageFile file = await storageFolder.GetFileAsync("sample.mkv");
            if (file != null)
            {
                // Set the option to show the picker
                var options = new Windows.System.LauncherOptions();
                options.DisplayApplicationPicker = true;

                // Launch the retrieved file
                bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }

        async private void btn_Click(object sender, RoutedEventArgs e)
        {
            //bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:defaultapps"));
            DefaultLaunch();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            DefaultLaunchWithOptions();
        }
    }
}
