using System;

namespace net5trimerror
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[net5trimerror] Begin");
            Console.WriteLine(Helper.GetDedicatedGPUName());
            Console.WriteLine("[net5trimerror] End");
        }
    }
}
