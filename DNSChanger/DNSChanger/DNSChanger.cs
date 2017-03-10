using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace DNSChanger
{
    static class DNSChanger
    {

        public static bool Set()
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = objMC.GetInstances();
            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].Equals("[00000004] Intel(R) Dual Band Wireless-AC 8260"))
                    {
                        try
                        {
                            
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    
                }
            }


            return true;
        }

        public static bool Delete()
        {
            return true;
        }

    }
}
