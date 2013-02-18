using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Linq;

namespace ZiFM
{
    class Program
    {
        static void Main(string[] args)
        {
            MXit.ExternalApp.ExternalAppService<MXit.ExternalApp.ExternalAppUserSession, ZiFMEngine> externalApp = null;
            try
            {
                externalApp = new MXit.ExternalApp.ExternalAppService<MXit.ExternalApp.ExternalAppUserSession, ZiFMEngine>(new ZiFMEngine(), "APPLICATION_NAME", "PASSWORD", 10, 50);
                externalApp.Start();
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR:\n" + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
            }
            finally
            {
                if (externalApp != null && externalApp.Status != MXit.ExternalApp.ExternalAppServiceStatus.Stopped)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The server has shutdown.");
                    Console.ForegroundColor = ConsoleColor.White;
                    externalApp.Stop();
                }
            }
        }
    }
}