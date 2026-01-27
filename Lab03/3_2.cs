using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BigObject
{
    public byte[] Data = new byte[1024 * 1024];
}

public class q3_2
{
    public static void Solution()
    {
        Console.WriteLine($"Memory before: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

        List<BigObject> list = new List<BigObject>();

        for (int i = 0; i < 100; i++)
        {
            list.Add(new BigObject());
        }

        Console.WriteLine($"After allocation: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

#pragma warning disable CS8600
        list = null; 
#pragma warning restore CS8600

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"After GC: {GC.GetTotalMemory(true) / 1024 / 1024} MB");
    }
}