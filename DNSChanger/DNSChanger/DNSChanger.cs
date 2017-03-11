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
        
        public static List<string> CheckNetworks()
        {
            List<string> networks = new List<string>();
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = objMC.GetInstances();
            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    networks.Add(obj["Caption"].ToString());
                }
            }
            return networks;
        }


        public static bool Set(string networkName)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = objMC.GetInstances();
            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].Equals(networkName))
                    {
                        try
                        {
                            ManagementBaseObject  objNewDNS = obj.GetMethodParameters("SetDNSServerSearchOrder");
                            string[] newDNS = (string[])obj["DNSServerSearchOrder"];
                            newDNS[0] = "213.184.238.6";
                            newDNS[1] = "213.184.238.45";
                            objNewDNS["DNSServerSearchOrder"] = new string[] { newDNS[0], newDNS[1] };
                            ManagementBaseObject objSetDNS = obj.InvokeMethod("SetDNSServerSearchOrder", objNewDNS, null);
                            uint result = (uint)objSetDNS["returnValue"];
                            if (result == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    
                }
            }
            return false;
        }

        public static bool Delete(string networkName)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = objMC.GetInstances();
            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].Equals(networkName))
                    {
                        try
                        {
                            ManagementBaseObject objNewDNS = obj.GetMethodParameters("SetDNSServerSearchOrder");
                            objNewDNS["DNSServerSearchOrder"] = null;
                            ManagementBaseObject objSetDNS = obj.InvokeMethod("SetDNSServerSearchOrder", objNewDNS, null);
                            uint result1 = (uint)objSetDNS["returnValue"];

                            if (result1 == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                }
            }
            return false;
        }

    }
}
