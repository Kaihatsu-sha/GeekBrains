using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class TwoHandedWeapons : Weapon
    {
        protected int _bonusChanceHitting;

        public TwoHandedWeapons(
            string name, 
            string icon, 
            int minDamageLevel, 
            int maxDamageLevel, 
            int chanceCriticalHit,
            int bonusChanceHitting) : base(name, icon, minDamageLevel, maxDamageLevel, chanceCriticalHit, 2)
        {
            _bonusChanceHitting = bonusChanceHitting;
            _chanceHitting += _bonusChanceHitting;
        }
    }
}
