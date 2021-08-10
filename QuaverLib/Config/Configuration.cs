using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;

namespace MusicLib.Config
{
    public class Configuration
    {
        #region Constants
        const string CONFIG = ".config";

        const string PARAM_SERVER_ENABLED = "PARAM_SERVER_ENABLED";
        const string PARAM_LIBRARY_PATHS = "PARAM_LIBRARY_PATHS";
        #endregion

        #region Serialization Functions
        private static void SaveConfig(Dictionary<string, object> config)
        {
            Serializer serializer = new Serializer();
            string yaml = serializer.Serialize(config);
            File.WriteAllText(CONFIG, yaml);
        }

        private static Dictionary<string, object> GetConfig()
        {
            if (File.Exists(CONFIG))
            {
                Deserializer deserializer = new Deserializer();
                string yaml = File.ReadAllText(CONFIG);
                return (Dictionary<string, object>)deserializer.Deserialize(yaml, typeof(Dictionary<string, object>));
            }
            return new Dictionary<string, object>();
        }
        #endregion

        #region Config Properties
        public static bool ServerEnabled
        {
            get
            {
                var config = GetConfig();


                if (config.TryGetValue(PARAM_SERVER_ENABLED, out object res))
                    return bool.Parse((string)res);
                return false;
            }
            set
            {
                var config = GetConfig();
                config[PARAM_SERVER_ENABLED] = value;
                SaveConfig(config);

                ConfigChanged?.Invoke(null, new ConfigEventArgs() { Config = ConfigEventArgs.Configs.Serverenabled, Arg = value });
            }
        }
        public static string LibraryPath
        {
            get
            {
                var config = GetConfig();

                if (config.TryGetValue(PARAM_LIBRARY_PATHS, out object res))
                    return (string)res;
                return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }
            set
            {
                var config = GetConfig();
                config[PARAM_LIBRARY_PATHS] = value;
                SaveConfig(config);

                ConfigChanged?.Invoke(null, new ConfigEventArgs() { Config = ConfigEventArgs.Configs.LibraryPath, Arg = value });
            }
        }
        #endregion

        public static event EventHandler<ConfigEventArgs> ConfigChanged;
    }

    public class ConfigEventArgs : EventArgs
    {
        public enum Configs
        {
            Serverenabled,
            LibraryPath
        }

        public Configs Config { get; set; }
        public object Arg { get; set; }
    }
}
