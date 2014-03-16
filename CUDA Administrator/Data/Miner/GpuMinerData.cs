using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUDA_Administrator.Data.Miner
{
    public class GpuMinerData
    {
        private Guid _MinerGUID = Guid.NewGuid();
        public Guid MinerGUID
        {
            get { return _MinerGUID; }
            set { _MinerGUID = value; }
        }

        private int _Device = 0;
        public int Device
        {
            get { return _Device; }
            set { _Device = value; }
        }

        private int _Retries = 0;
        public int Retries
        {
            get { return _Retries; }
            set { _Retries = value; }
        }

        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _Active = false;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private bool _Failover = false;
        public bool Failover
        {
            get { return _Failover; }
            set { _Failover = value; }
        }

        private string _CommandLine = string.Empty;
        public string CommandLine
        {
            get { return _CommandLine; }
            set { _CommandLine = value; }
        }

        private string _PoolAddress = string.Empty;
        public string PoolAddress
        {
            get { return _PoolAddress; }
            set { _PoolAddress = value; }
        }

        private string _WorkerName = string.Empty;
        public string WorkerName
        {
            get { return _WorkerName; }
            set { _WorkerName = value; }
        }

        private string _WorkerPassword = string.Empty;
        public string WorkerPassword
        {
            get { return _WorkerPassword; }
            set { _WorkerPassword = value; }
        }

        private string _Algorithm = string.Empty;
        public string Algorithm
        {
            get { return _Algorithm; }
            set { _Algorithm = value; }
        }

        private string _Kernel = string.Empty;
        public string Kernel
        {
            get { return _Kernel; }
            set { _Kernel = value; }
        }

        private string _CpuAssist = string.Empty;
        public string CpuAssist
        {
            get { return _CpuAssist; }
            set { _CpuAssist = value; }
        }
        
        private string _TextureCache = string.Empty;
        public string TextureCache
        {
            get { return _TextureCache; }
            set { _TextureCache = value; }
        }

        private int _LookupGap = 0;
        public int LookupGap
        {
            get { return _LookupGap; }
            set { _LookupGap = value; }
        }
        
        private int _Batchsize = 0;
        public int Batchsize
        {
            get { return _Batchsize; }
            set { _Batchsize = value; }
        }

        bool _Debug = false;
        public bool Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }
        
        bool _Interactive = false;
        public bool Interactive
        {
            get { return _Interactive; }
            set { _Interactive = value; }
        }
        
        bool _SingleMemory = false;
        public bool SingleMemory
        {
            get { return _SingleMemory; }
            set { _SingleMemory = value; }
        }
    }
}
