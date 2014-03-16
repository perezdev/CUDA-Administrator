using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CUDA_Administrator.Nvidia_API.Hardware
{
    public interface IVisitor
    {
        void VisitHardware(IHardware hardware);
        void VisitSensor(ISensor sensor);
        void VisitParameter(IParameter parameter);
    }
}
