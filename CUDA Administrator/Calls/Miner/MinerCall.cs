using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CUDA_Administrator.Data.Miner;

namespace CUDA_Administrator.Calls.Miner
{
    public class MinerCall
    {
        public bool IsMinersRunning()
        {
            bool isRunning = false;

            Process[] CudaMinerProcesses = Process.GetProcessesByName("cudaminer");
            Process[] CpuMinerProcesses = Process.GetProcessesByName("minerd");

            if (CudaMinerProcesses.Count() > 0 || CpuMinerProcesses.Count() > 0)
                isRunning = true;

            return isRunning;
        }
        public void ShutdownMiners()
        {
            Process[] CudaMinerProcesses = Process.GetProcessesByName("cudaminer");
            Process[] CpuMinerProcesses = Process.GetProcessesByName("minerd");

            foreach (Process proc in CudaMinerProcesses)
            {
                if (!proc.CloseMainWindow()) //Try to close the app normall
                    proc.Kill(); //But if it gets stuck, just kill it
            }
            foreach (Process proc in CpuMinerProcesses)
            {
                if (!proc.CloseMainWindow()) //Try to close the app normall
                    proc.Kill(); //But if it gets stuck, just kill it
            }
        }
    }
}
