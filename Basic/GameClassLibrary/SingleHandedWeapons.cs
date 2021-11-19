using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class SingleHandedWeapons : Weapon
    {
        protected int _damagePenalty;//Штраф к урону в %

        public SingleHandedWeapons(
            string name,
            int minDamageLevel, 
            int maxDamageLevel, 
            int chanceCriticalHit,
            int damagePenalty) : base(name, minDamageLevel, maxDamageLevel, chanceCriticalHit, 1)
        {
            _damagePenalty = damagePenalty;
            _minDamageLevel = minDamageLevel * (100 - _damagePenalty) / 100;
            _maxDamageLevel = maxDamageLevel * (100 - _damagePenalty) / 100;
        }
    }
}
