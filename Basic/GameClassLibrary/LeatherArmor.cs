using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class LeatherArmor : Armor
    {
        public LeatherArmor(string name, int armorHealthPoints) : base(name, armorHealthPoints)
        {
            _attributes.Add((AttributesEnum.ChanceCriticalHit, 5));
            _attributes.Add((AttributesEnum.ChanceDodge, 10));
        }
    }
}
