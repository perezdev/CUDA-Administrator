using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CUDA_Administrator.Calls.OptionsCall
{
    public class OptionsCall
    {
        public void SetStartupKey(ref string strError)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("CUDA_Administrator", "schtasks /Run /TN \"CudaAdministratorSkipUAC\"");
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }
        public void RemoveStartupKey(ref string strError)
        {
            try
            {
                RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.DeleteValue("CUDA_Administrator", false);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }
    }
}
