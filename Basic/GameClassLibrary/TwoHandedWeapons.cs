using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    internal class TwoHandedWeapons : Weapon
    {
        protected int _bonusChanceHitting;

        protected TwoHandedWeapons(
            int id, 
            string name, 
            string icon, 
            int minDamageLevel, 
            int maxDamageLevel, 
            int chanceCriticalHit,
            int bonusChanceHitting) : base(id, name, icon, minDamageLevel, maxDamageLevel, chanceCriticalHit, 2)
        {
            _bonusChanceHitting = bonusChanceHitting;
        }

        public override void Attack(Character enemy)
        {
            _chanceHitting += _bonusChanceHitting;
            base.Attack(enemy);
        }
    }
}
