using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CUDA_Administrator.Data.Miner;
using CUDA_Administrator.Data.Options;

namespace CUDA_Administrator.Data.Setting
{
    public class Settings
    {
        private List<GpuMinerData> _CudaMiners = new List<GpuMinerData>();
        public List<GpuMinerData> GpuMiners
        {
            get { return _CudaMiners; }
            set { _CudaMiners = value; }
        }

        private List<CpuMinerData> _CpuMiners = new List<CpuMinerData>();
        public List<CpuMinerData> CpuMiners
        {
            get { return _CpuMiners; }
            set { _CpuMiners = value; }
        }

        private OptionsData _Options = new OptionsData();
        public OptionsData Options
        {
            get { return _Options; }
            set { _Options = value; }
        }
    }
}
