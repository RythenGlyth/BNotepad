using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SymbolIconSource = Microsoft.UI.Xaml.Controls.SymbolIconSource;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BNotepad {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();

            Debug.WriteLine("aa:");
            Debug.WriteLine(String.Join(", ", Directory.GetDirectories("C:\\Windows\\System32")));
            /*using(var sr = new StreamReader("C:\\Windows\\System32")) {
                Console.WriteLine(sr.ReadToEnd());
            }*/

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;

            Window.Current.SetTitleBar(this.CustomDragRegion);

            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args) {
            CustomDragRegion.MinWidth = sender.SystemOverlayRightInset;
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args) {
            if(sender.IsVisible) {
                TabViewEl.Visibility = Visibility.Visible;
            } else {
                TabViewEl.Visibility = Visibility.Collapsed;
            }
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(SettingsPage));
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e) {
            ApplicationView view = ApplicationView.GetForCurrentView();
            if(view.IsFullScreenMode) {
                view.ExitFullScreenMode();
            } else {
                var succeeded = view.TryEnterFullScreenMode();
            }
        }
    }
}
