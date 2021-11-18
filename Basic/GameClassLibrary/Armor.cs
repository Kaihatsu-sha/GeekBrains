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
        protected List<(AttributesEnum, int)> _attributes;

        protected Armor(string name, string icon, int armorHealthPoints) : base(name, icon)
        {
            _armorHealthPoints = armorHealthPoints;
            _attributes = new List<(AttributesEnum, int)>();
        }

        public List<(AttributesEnum, int)> Attributes 
        {
            get { return _attributes; }
        }

    }
}
