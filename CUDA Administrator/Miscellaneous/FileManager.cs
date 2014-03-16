using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUDA_Administrator.Miscellaneous
{
    public static class FileManager
    {
        public static string DataPath = Application.StartupPath + @"\Data\";
        public static string LogPath = Application.StartupPath + @"\Data\Logs\";
        public static string MinerLogsPath = Application.StartupPath + @"\Data\Logs\Miners\";
        public static string RootMinersPath = Application.StartupPath + @"\Miners\";
        public static string CpuMinerPath = Application.StartupPath + @"\Miners\CpuMiner\";
        public static string CudaMinerPath = Application.StartupPath + @"\MIners\CudaMiner\";
    }
}
