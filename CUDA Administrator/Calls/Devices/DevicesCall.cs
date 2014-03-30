using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CUDA_Administrator.Data.Devices;
using CUDA_Administrator.Nvidia_API.Hardware;
using CUDA_Administrator.Nvidia_API.Hardware.Nvidia;

namespace CUDA_Administrator.Calls.Devices
{
    public class DevicesCall
    {
        public List<VideoCard> GetVideoCards(ref string strError)
        {
            List<VideoCard> cards = new List<VideoCard>();

            int index = 0;
            NvidiaGroup gpus = new NvidiaGroup();
            foreach (NvidiaGPU gpu in gpus.Hardware)
            {
                gpu.Update();
                index++;

                VideoCard card = new VideoCard();
                card.Name = gpu.Name;
                card.Number = index;

                foreach (Sensor sensor in gpu.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                        card.TemperatureSensors.Add(sensor);
                    else if (sensor.SensorType == SensorType.Control)
                        card.FanSensors.Add(sensor);
                    else if (sensor.SensorType == SensorType.Clock)
                        card.ClockSensors.Add(sensor);
                }

                cards.Add(card);
            }
            return cards;
        }

        //public List<GpuTemp> GetGpuTemps()
        //{
        //    List<GpuTemp> gpuTemps = new List<GpuTemp>();

        //    NvidiaGroup gpus = new NvidiaGroup();
        //    foreach (NvidiaGPU gpu in gpus.Hardware)
        //    {
        //        gpu.Update();
        //        gpuTemps.Add(new GpuTemp() 
        //        { 
        //            Name = gpu.Name.Replace("NVIDIA", "").Replace("GeForce", "").Trim(),
        //            Temperature = gpu.Sensors.SingleOrDefault(x => x.SensorType == SensorType.Temperature).Value.ToString() 
        //        });
        //    }

        //    return gpuTemps;
        //}

    }
}
