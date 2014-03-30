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
        private int _Number = 0;
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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
        private List<Sensor> _ClockSensors = new List<Sensor>();
        internal List<Sensor> ClockSensors
        {
            get { return _ClockSensors; }
            set { _ClockSensors = value; }
        }
    }
}
