using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace DemoConsoleAppForConfigInDocker
{
    public  class SystemConfigurationLoader
    {
        public SystemConfigurationLoader()
        {
            System.Configuration.ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = "./App.config";
            System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            foreach (var key in configuration.AppSettings.Settings.AllKeys)
            {
                try
                {
                    System.Configuration.ConfigurationManager.AppSettings[key] = configuration.AppSettings.Settings[key].Value;
                }
                catch (Exception)
                {
                   
                }
            }
            Console.WriteLine("Loaded System Configuration");
        }
        public static SystemConfigurationLoader Instance { get { return NestedInstance.instance; } }

        private class NestedInstance
        {
            static NestedInstance()
            {

            }
            internal static readonly SystemConfigurationLoader instance = new SystemConfigurationLoader(); 
        }
        public System.Collections.Specialized.NameValueCollection GetAppSettings()
        {
            return System.Configuration.ConfigurationManager.AppSettings; 
        }
    }
}

