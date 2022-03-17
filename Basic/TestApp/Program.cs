using BasicOOP;
using System;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void BuildingTest()
        {
            Building buildingC = Creator.CreateBuild();
            Console.WriteLine(buildingC);
            Creator.DestroyBuilding(buildingC.BuildingNumber);

            Building buildingD = Creator.CreateBuild("Simple building");
            Console.WriteLine(buildingC);
            //
        }
    }
}
