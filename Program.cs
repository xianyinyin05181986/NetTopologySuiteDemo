using NetTopologySuiteClassLib;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader r = new FileReader();
            string path = @"C:\Users\vts-developer\Downloads\ShapeFile\ShapeFile\points.shp";

            Console.WriteLine(r.GetAttributeValueSum("value1",path));
        }
    }
}
