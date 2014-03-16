using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CUDA_Administrator.Nvidia_API.Hardware;
using CUDA_Administrator.Nvidia_API.Hardware.Nvidia;

namespace CUDA_Administrator.Data.Devices
{
    public class VideoCard
    {
        private NvidiaGPU _GPU = null;
        internal NvidiaGPU GPU
        {
            get { return _GPU; }
            set { _GPU = value; }
        }

        private List<Sensor> _TemperatureSensors = new List<Sensor>();
        internal List<Sensor> TemperatureSensors
        {
            get { return _TemperatureSensors; }
            set { _TemperatureSensors = value; }
        }

        private List<Sensor> _FanSensors = new List<Sensor>();
        internal List<Sensor> FanSensors
        {
            get { return _FanSensors; }
            set { _FanSensors = value; }
        }
    }
}
