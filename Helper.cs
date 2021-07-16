using Microsoft.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net5trimerror
{
    public static class Helper
    {
        static public string GetDedicatedGPUName()
        {
            try
            {
                Console.WriteLine("CimSession.Create");
                using var session = CimSession.Create(null);

                Console.WriteLine("QueryInstances");
                var instances = session.QueryInstances(@"root\cimv2", "WQL", $"SELECT Name FROM Win32_VideoController");

                foreach (var instance in instances)
                {
                    try
                    {
                        Console.WriteLine("CimInstanceProperties");
                        var value = instance.CimInstanceProperties["Name"].Value as string;

                        if (value != null)
                            return value;
                    }
                    finally
                    {
                        Console.WriteLine("finally");
                        instance.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return "";
        }

    }
}
