using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class HeavyArmor : Armor
    {
        public HeavyArmor(string name, int armorHealthPoints) : base(name, armorHealthPoints)
        {
            _attributes.Add((AttributesEnum.ChanceDodge, -10));
            _attributes.Add((AttributesEnum.HealthPoints, 25));
        }
    }
}
