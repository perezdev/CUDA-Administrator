using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace CUDA_Administrator.Calls.ScheduleTasks
{
    public static class ScheduleTask
    {
        public static void CreateNewTask()
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.Principal.RunLevel = TaskRunLevel.Highest;
                td.Settings.DisallowStartIfOnBatteries = true; //If running on a notebook and it the PC starts while just on the battery (and the run on startup is true), then the task won't run
                td.Settings.StopIfGoingOnBatteries = true;
                td.RegistrationInfo.Description =
                    "Allows CUDA Administrator from requiring UAC on start. UAC is needed in order to obtain the CPU temperatures. " +
                    "This is setup for convenience and for running on startup.";
                td.Actions.Add(new ExecAction("\"" + Application.StartupPath + "\\Cuda Administrator.exe\"", "--autorun", null));
                ts.RootFolder.RegisterTaskDefinition("CudaAdministratorSkipUAC", td);
            }
        }

        public static void RunTask()
        {
            using (TaskService ts = new TaskService())
            {
                Task t = ts.GetTask("CudaAdministratorSkipUAC");
                if (t != null)
                {
                    t.Run();
                }
            }
        }
    }
}
