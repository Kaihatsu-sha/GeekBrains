using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class HeavyArmor : Armor
    {
        protected HeavyArmor(string name, string icon, int armorHealthPoints) : base(name, icon, armorHealthPoints)
        {
            _attributes.Add((AttributesEnum.Damage, 5));
            _attributes.Add((AttributesEnum.ChanceDodge, -10));
            _attributes.Add((AttributesEnum.HealthPoints, 20));
        }
    }
}
