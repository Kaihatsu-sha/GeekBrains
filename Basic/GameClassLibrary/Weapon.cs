using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    internal class Weapon : BaseObject
    {
        protected int _minDamageLevel;
        protected int _maxDamageLevel;
        protected int _chanceCriticalHit;
        protected int _actionPointCost;
        protected int _chanceHitting;

        protected Weapon(
            int id, 
            string name, 
            string icon, 
            int minDamageLevel, 
            int maxDamageLevel, 
            int chanceCriticalHit, 
            int actionPointCost) : base(id, name, icon)
        {
            _minDamageLevel = minDamageLevel;
            _maxDamageLevel = maxDamageLevel;
            _chanceCriticalHit = chanceCriticalHit;
            _actionPointCost = actionPointCost;
            _chanceHitting = 95;//шанс попасть
        }

        public int MinDamageLevel { get { return _minDamageLevel; } set { _minDamageLevel = value; } }
        public int MaxDamageLevel { get { return _maxDamageLevel; } set { _maxDamageLevel = value; } }
        public int ChanceCriticalHit { get { return _chanceCriticalHit; } set { _chanceCriticalHit = value; } }
        public int ActionPoinCost { get { return _actionPointCost; } }
        public int ChanceHitting { get { return _chanceHitting;} set { _chanceCriticalHit += value; } }

        public virtual void Attack(Character enemy)
        {
            int calculatedChanceHitting = new Random().Next(0, 100);
            if(_chanceHitting - enemy.ChanceDodge > calculatedChanceHitting)// промах
            {
                return;
            }

            int damage = new Random().Next(_minDamageLevel, _maxDamageLevel);
            int calculatedChanceCriticalHit = new Random().Next(0, 100);

            damage = calculatedChanceCriticalHit > _chanceCriticalHit? damage * 2 : damage;
            
            enemy.TakingDamage(damage);
        }
    }
}
