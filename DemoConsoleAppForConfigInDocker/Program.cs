using System;
using System.Configuration; 
using System.Collections.Generic;

namespace DemoConsoleAppForConfigInDocker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var appSettings = SystemConfigurationLoader.Instance.GetAppSettings(); 
            Console.WriteLine("Config value: "+ appSettings["Demo"]??"Unset"); 
        }
    }
}
