using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    internal class Character : BaseObject
    {
        private int _chanceDodge;
        private int _healthPoints;
        private int _actionPoints;
        private int _armorHealthPoints;
        private int _chanceCriticalHit;


        public int ChanceDodge { get { return _chanceDodge; } set { _chanceDodge = value;} }
        public int ChanceCriticalHit { get { return _chanceCriticalHit; } }
        public void TakingDamage(int damage)
        {

        }
    }
}
