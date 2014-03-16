using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CUDA_Administrator.Data.Setting;
using CUDA_Administrator.Miscellaneous;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CUDA_Administrator.Calls.Setting
{
    public class SettingCall
    {

        #region Public Methods

        public Settings GetSettings(ref string strError)
        {
            Settings settings = new Settings();

            try
            {
                if (File.Exists(FileManager.DataPath + "settings.dat"))
                    settings = DeSerializeSettings();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }

            return settings;
        }

        public void CreateFolders(ref string strError)
        {
            try
            {
                if (!Directory.Exists(FileManager.DataPath))
                    Directory.CreateDirectory(FileManager.DataPath);
                if (!Directory.Exists(FileManager.CudaMinerPath))
                    Directory.CreateDirectory(FileManager.CudaMinerPath);
                if (!Directory.Exists(FileManager.CpuMinerPath))
                    Directory.CreateDirectory(FileManager.CpuMinerPath);
                if (!Directory.Exists(FileManager.LogPath))
                    Directory.CreateDirectory(FileManager.LogPath);
                if (!Directory.Exists(FileManager.MinerLogsPath))
                    Directory.CreateDirectory(FileManager.MinerLogsPath);
            }
            catch (Exception ex)
            {
                strError = "An error occurred while trying to create the necessary folders for CUDA Admin to run. Did you forget to extract the contents?\r\n\r\nError: " + ex.Message;
            }
        }

        public void SeriliazeSettings(Settings data)
        {
            using (var stream = File.Create(FileManager.DataPath + "settings.dat"))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(stream, data);
            }
        }

        public Settings DeSerializeSettings()
        {
            using (var stream = File.OpenRead(FileManager.DataPath + "settings.dat"))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                return (Settings)serializer.Deserialize(stream);
            }
        }

        public Icon GetApplicationIcon()
        {
            Icon ico = null;

            if (File.Exists(Application.StartupPath + @"\ca.ico"))
                ico = new Icon(Application.StartupPath + @"\ca.ico");

            return ico;
        }

        public bool IsNewVersionAvailable(ref string strError)
        {
            bool isNewVersion = false;

            try
            {
                string tags;

                using (WebClient wc = new WebClient())
                {
                    WebRequest req = HttpWebRequest.Create("http://www.reddit.com/r/CudaAdministrator/wiki/versioncontrol.json");
                    req.Timeout = 5000; //5 second timeout
                    req.Method = "GET";
                    using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                        tags = reader.ReadToEnd();
                }

                Version NewVersion = null;
                Version.TryParse(JObject.Parse(tags)["data"]["content_md"].ToString(), out NewVersion);
                Version OldVersion = Assembly.GetExecutingAssembly().GetName().Version;

                if (NewVersion > OldVersion)
                    isNewVersion = true;
                else
                    isNewVersion = false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }

            return isNewVersion;
        }

        #endregion

        #region Private Methods



        #endregion

    }

    public class VersionControl
    {
        public VersionControl()
        {
            Version = string.Empty;
        }

        [JsonProperty("content_md")]
        public string Version { get; set; }

        public class Data
        {
            [JsonProperty("content_md")]
            string test = string.Empty;
        }
    }
}
