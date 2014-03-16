using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUDA_Administrator.Data.Options
{
    public class OptionsData
    {
        private bool _IsRunningOnStartup = false;
        public bool IsRunningOnStartup
        {
            get { return _IsRunningOnStartup; }
            set { _IsRunningOnStartup = value; }
        }

        private bool _IsTempProtectionActivated = true;
        public bool IsTempProtectionActivated
        {
            get { return _IsTempProtectionActivated; }
            set { _IsTempProtectionActivated = value; }
        }

        private bool _IsContinuousMinerLogging = false;
        public bool IsContinuousMinerLogging
        {
            get { return _IsContinuousMinerLogging; }
            set { _IsContinuousMinerLogging = value; }
        }

        private int _TemperatureMax = 80;
        public int TemperatureMax
        {
            get { return _TemperatureMax; }
            set { _TemperatureMax = value; }
        }

        private int _TemperatureShutdown = 100;
        public int TemperatureShutdown
        {
            get { return _TemperatureShutdown; }
            set { _TemperatureShutdown = value; }
        }
    }
}
