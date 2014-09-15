using mshtml;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Jabbr
{
    public partial class MainWindow : Window
    {
        string css = "";

        public MainWindow()
        {
            InitializeComponent();

            var files = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "user.css"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "user.css"),
                System.IO.Path.Combine(Environment.CurrentDirectory, "dark-default.css")
            };

            var file = files.Where(f => File.Exists(f)).First();

            css = File.ReadAllText(file);

            NavigationCommands.GoToPage.Execute("http://jabbr.net", webBrowser);

            var dpiProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);
            var dpi = (int)dpiProperty.GetValue(null, null);
            var dpiScaleFactor = ((float)dpi) / 96f;


            webBrowser.InnerBrowser.Navigated += InnerBrowser_Navigated;

            webBrowser.Zoom = (int)Math.Round(dpiScaleFactor * 150);
        }

        void InnerBrowser_Navigated(object sender, NavigationEventArgs e)
        {

            var doc = webBrowser.InnerBrowser.Document as IHTMLDocument2;
            var style = doc.createStyleSheet("", 0);
            style.cssText = css;

            webBrowser.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
