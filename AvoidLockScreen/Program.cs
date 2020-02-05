using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AvoidLockScreen
{
    class Program
    {

        [DllImport("user32.dll")]
        internal static extern bool SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);
        static Int32 WM_SYSCOMMAND = 0x0112;
        static Int32 SC_MINIMIZE = 0x0F020;


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        static void Main(string[] args)
        {
            //var psi = new ProcessStartInfo();
            //psi.CreateNoWindow = true;
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOS);
            Console.SetWindowSize(90, 11);
            Console.Write(@"
                   _     _      _            _                                      
   __ ___   _____ (_) __| |    | | ___   ___| | __     ___  ___ _ __ ___  ___ _ __  
  / _` \ \ / / _ \| |/ _` |    | |/ _ \ / __| |/ /    / __|/ __| '__/ _ \/ _ \ '_ \ 
 | (_| |\ V / (_) | | (_| |    | | (_) | (__|   <     \__ \ (__| | |  __/  __/ | | |
  \__,_| \_/ \___/|_|\__,_|    |_|\___/ \___|_|\_\    |___/\___|_|  \___|\___|_| |_|


    ... as long this app is running.");
            Console.Read();
        }
    }

    [FlagsAttribute]
    public enum EXECUTION_STATE : uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001,
    }

}