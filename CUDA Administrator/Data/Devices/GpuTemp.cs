using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUDA_Administrator.Data.Devices
{
    public class GpuTemp
    {
        private string _GPU = string.Empty;
        public string Name
        {
            get { return _GPU; }
            set { _GPU = value; }
        }

        private string _Temperature = string.Empty;
        public string Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
    }
}
