using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    internal class SingleHandedWeapons : Weapon
    {
        protected int _damagePenalty;//Штраф к урону в %

        protected SingleHandedWeapons(
            int id, 
            string name, 
            string icon, 
            int minDamageLevel, 
            int maxDamageLevel, 
            int chanceCriticalHit,
            int damagePenalty) : base(id, name, icon, minDamageLevel, maxDamageLevel, chanceCriticalHit, 1)
        {
            _damagePenalty = damagePenalty;
            _minDamageLevel *= (100 - _damagePenalty) / 100;
            _maxDamageLevel *= (100 - _damagePenalty) / 100;
        }
    }
}
