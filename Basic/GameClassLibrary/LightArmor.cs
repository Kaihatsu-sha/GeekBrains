using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class LightArmor : Armor
    {
        public LightArmor(string name, int armorHealthPoints) : base(name, armorHealthPoints)
        {
            _attributes.Add((AttributesEnum.ChanceHitting, 15));
            _attributes.Add((AttributesEnum.ChanceDodge, 15));
        }
    }
}
