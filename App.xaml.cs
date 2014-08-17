using Microsoft.Win32;
using System.Windows;

namespace Jabbr
{
    public partial class App : Application
    {
        public App()
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", "Jabbr.exe", 11001);
        }
    }
}
