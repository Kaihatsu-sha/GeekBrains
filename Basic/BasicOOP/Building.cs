using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP
{
    public class Building
    {
        private static int _totalBuildings = 0;//Уникальный номер
        private int _buildingNumber;//Номер
        private int _numberFloors;//Этажей
        private int _numberApartmentsPerFloor;//Комнат на этаже в подъезде
        private int _numberEntrances;//Подъездов в здании
        private double _floorHeight;//Высота этажа
        private string _name = "";//Название

        /// <summary>
        /// Уникальный номер здания
        /// </summary>
        public int BuildingNumber
        {
            get { return _buildingNumber; }
        }

        /// <summary>
        /// Количество этажей в здании
        /// </summary>
        public int NumberFloors
        {
            get { return _numberFloors; }
            set 
            {
                if (value < 1)
                {
                    throw new ArgumentException("Этажей не может быть меньше 1!!!");
                }
                _numberFloors = value; 
            }
        }

        /// <summary>
        /// Количество квартир на этаж
        /// </summary>
        public int NumberApartmentsPerFloor
        {
            get { return _numberApartmentsPerFloor; }
            set { _numberApartmentsPerFloor = value; }
        }

        /// <summary>
        /// Количество подъездов
        /// </summary>
        public int NumberEntrances
        {
            get { return _numberEntrances; }
            set { _numberEntrances = value; }
        }

        /// <summary>
        /// Высота одного этажа
        /// </summary>
        public double FloorHeight
        {
            get { return _floorHeight; }
            set 
            {
                if (value < 2.0)
                {
                    throw new ArgumentException("Высота не может быть меньше 2-х метров!!!");
                }
                _floorHeight = value; 
            }
        }

        /// <summary>
        /// Название здания
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Вычисление высоты этажа
        /// </summary>
        /// <param name="numberFloor">Этаж</param>
        /// <returns>Высота</returns>
        public double HeightSelectFloor(int numberFloor)
        {
            if (numberFloor <= 1)
                return 0;

            return (numberFloor - 1) * _floorHeight;
        }

        /// <summary>
        /// Количество квартир на этаж во всех подьездах
        /// </summary>
        /// <returns></returns>
        public int NumberApartmentsFloorInAllEntrances()
        {
            return _numberEntrances * _numberApartmentsPerFloor;
        }

        /// <summary>
        /// Количество квартир в подъезде
        /// </summary>
        /// <returns></returns>
        public int NumberApartmentsInEntrance()
        {
            return _numberApartmentsPerFloor * _numberFloors;
        }

        /// <summary>
        /// Создание здания
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="numberFloors">Количество этажей</param>
        /// <param name="numberApartmentsPerFloor">Количество квартир на этаж</param>
        /// <param name="numberEntrances">Количество подъездов</param>
        /// <param name="floorHeight">Высота этажа</param>
        internal Building(string name, int numberFloors, int numberApartmentsPerFloor, int numberEntrances, double floorHeight)
        {
            _name = name;
            _numberFloors = numberFloors;
            _numberApartmentsPerFloor = numberApartmentsPerFloor;
            _numberEntrances = numberEntrances;
            _floorHeight = floorHeight;

            _buildingNumber = GetBuildingNumber;
        }

        /// <summary>
        /// Создание здания с базовыми параметрами
        /// </summary>
        /// <param name="name">Название</param>
        internal Building(string name) : this(name, 1, 0, 0, 2.0)
        {

        }

        internal Building() { }

        public override string ToString()
        {
            return $"Здание \"{_name}\" с номером {_buildingNumber}{Environment.NewLine}" +
                   "Технические данные:" + Environment.NewLine +
                   $"Количество этажей:{_numberFloors}" + Environment.NewLine +
                   $"Количество квартир на этаж:{_numberApartmentsPerFloor}" + Environment.NewLine +
                   $"Количество подъездов:{_numberEntrances}" + Environment.NewLine +
                   $"Высота этажа:{_floorHeight}";
        }

        
        private int GetBuildingNumber
        {
            get { return _totalBuildings += 1; }
        }
    }
}
