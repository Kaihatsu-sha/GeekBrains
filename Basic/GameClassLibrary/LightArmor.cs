using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class LightArmor : Armor
    {
        public LightArmor(string name, string icon, int armorHealthPoints) : base(name, icon, armorHealthPoints)
        {
            _attributes.Add((AttributesEnum.ChanceHitting, 10));
            _attributes.Add((AttributesEnum.ChanceDodge, 10));
        }
    }
}
