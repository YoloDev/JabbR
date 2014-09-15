using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows;

namespace Jabbr
{
    public partial class App : Application
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetProcessDPIAware();

        public App()
        {
            SetProcessDPIAware();
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", "Jabbr.exe", 11001);
        }
    }
}
