using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUDA_Administrator.Data.Miner
{
    public class CpuMinerData
    {
        private Guid _MinerGUID = Guid.NewGuid();
        public Guid MinerGUID
        {
            get { return _MinerGUID; }
            set { _MinerGUID = value; }
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

        private bool _LongPoll = true;
        public bool LongPoll
        {
            get { return _LongPoll; }
            set { _LongPoll = value; }
        }

        private bool _Stratum = true;
        public bool Stratum
        {
            get { return _Stratum; }
            set { _Stratum = value; }
        }

        private bool _Debug = false;
        public bool Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }
    }
}
