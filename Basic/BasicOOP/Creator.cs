using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP
{
    public class Creator//Конкретная фабрика
    {
        private static Hashtable _builings = new Hashtable();//Выделение при обращении??!
        private Creator()
        {
        }

        public static Building CreateBuild()
        {
            return CreateBuild("Default CreateBuild");
        }

        public static Building CreateBuild(string name)//Создание конкретного "продукта"
        {
            return CreateBuild(name, 1);//Или указать сразу "полный" метод?
        }

        public static Building CreateBuild(string name, int numberFloors)//Создание конкретного "продукта"
        {
            return CreateBuild(name, numberFloors, 1);
        }

        public static Building CreateBuild(string name, int numberFloors, int numberApartmentsPerFloor)//Создание конкретного "продукта"
        {
            return CreateBuild(name, numberFloors, numberApartmentsPerFloor, 1);
        }

        public static Building CreateBuild(
            string name, 
            int numberFloors, 
            int numberApartmentsPerFloor,
            int numberEntrances)//Создание конкретного "продукта"
        {
            return CreateBuild(name, numberFloors, numberApartmentsPerFloor, numberEntrances, 2.0);
        }

        public static Building CreateBuild(
           string name,
           int numberFloors,
           int numberApartmentsPerFloor,
           int numberEntrances,
           double floorHeight)//Создание конкретного "продукта"
        {
            Building building = new Building();
            building.Name = name;
            building.NumberFloors = numberFloors;
            building.NumberApartmentsPerFloor = numberApartmentsPerFloor;
            building.NumberEntrances = numberEntrances;
            building.FloorHeight = floorHeight;

            _builings.Add(building.BuildingNumber, building);
            return building;
        }

        public static void DestroyBuilding(int buildingNumber)
        {
            _builings.Remove(buildingNumber);
        }
    }
}
