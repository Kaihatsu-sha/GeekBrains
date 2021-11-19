using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Armor : BaseObject
    {
        protected int _armorHealthPoints;//Броня        
        protected List<(AttributesEnum Name, int Value)> _attributes;

        protected Armor(string name, int armorHealthPoints) : base(name)
        {
            _armorHealthPoints = armorHealthPoints;
            _attributes = new List<(AttributesEnum, int)>();
        }

        public List<(AttributesEnum Name, int Value)> Attributes 
        {
            get { return _attributes; }
        }

        public int ArmorHealthPoints
        { get { return _armorHealthPoints; } }
    }
}
