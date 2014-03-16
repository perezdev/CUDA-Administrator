namespace CUDA_Administrator.Nvidia_API.Hardware
{
    internal interface IGroup
    {

        IHardware[] Hardware { get; }

        string GetReport();

        void Close();
    }
}
