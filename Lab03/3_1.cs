using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct MyStruct
{
    public int X;
}

public class MyClass
{
    public int Value;
}

public class q3_1
{
    public static MyClass staticObj = new MyClass { Value = 999 };

    public static void Solution()
    {
        int a = 10; 
        MyStruct s;
        s.X = 5; 

        MyClass obj1 = new MyClass { Value = 1 };

        Console.WriteLine($"a = {a}");

        CreateObject();

        Console.WriteLine(obj1.Value);
    }

    public static void CreateObject()
    {
        MyClass obj2 = new MyClass { Value = 2 };

        int local = 42; 
        Console.WriteLine($"local = {local}");
    }
}