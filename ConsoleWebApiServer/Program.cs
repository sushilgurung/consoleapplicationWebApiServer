using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebApiServer
{
    public class Program
    {
        #region Fields
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdshow);
        #endregion

        public static void Main(string[] args)
        {
            Init();
        }

        private static void Init()
        {
            // if windows hide
            if (true)
            {
                HideWindow();
            }
            StartServer();
        }

        private static void StartServer()
        {
            string domain = GetDomainName();
            //string domainAddress = "http://localhost:8081/";
            using (WebApp.Start(url: domain))
            {
                Console.WriteLine("Service Hosted " + domain);
                System.Threading.Thread.Sleep(-1);
            }
        }
        /// <summary>
        /// Get domain 
        /// </summary>
        /// <returns></returns>
        private static string GetDomainName()
        {
            string domainName = string.Empty;
            var enviroment = Enviroment.Localhost;
            switch (enviroment)
            {
                case Enviroment.Localhost:
                    domainName = "http://localhost:8081/";
                    break;
                case Enviroment.PublicIp:
                    domainName = "http://*:8081/";
                    break;
                default:
                    domainName = "http://*:8081/";
                    break;
            }
            return domainName;
        }

        /// <summary>
        /// function to hide the console application windows it will run in the background
        /// </summary>
        private static void HideWindow()
        {
            IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);
            }
        }
        public enum Enviroment
        {
            Localhost = 0,
            PublicIp = 1
        }
    }
}
