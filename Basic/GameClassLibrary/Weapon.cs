using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Weapon : BaseObject
    {
        protected int _minDamageLevel;
        protected int _maxDamageLevel;
        protected int _chanceCriticalHit;
        protected int _actionPointCost;
        protected int _chanceHitting;

        protected Weapon(
            string name,
            string icon,
            int minDamageLevel,
            int maxDamageLevel,
            int chanceCriticalHit,
            int actionPointCost) : base(name, icon)
        {
            _minDamageLevel = minDamageLevel;
            _maxDamageLevel = maxDamageLevel;
            _chanceCriticalHit = chanceCriticalHit;
            _actionPointCost = actionPointCost;
           
        }

        public int MinDamageLevel { get { return _minDamageLevel; } }
        public int MaxDamageLevel { get { return _maxDamageLevel; } }
        public int ChanceCriticalHit { get { return _chanceCriticalHit; } }
        public int ActionPoinCost { get { return _actionPointCost; } }
        public int ChanceHitting { get { return _chanceHitting; } }
    }
}
