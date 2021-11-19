using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Character : BaseObject
    {
        private int _healthPoints;//Очки здоровья
        private int _actionPoints;//Очки действий
        private int _chanceCriticalHit;//Шанс нанести критический удар
        private int _chanceDodge;//Уклонение
        private int _chanceHitting;
        private int _armorHealthPoints;
        private Armor _chestArmor;//Броня
        private Weapon _rightHand; //Правая рука
        private Weapon _leftHand;//Левая рука

        private bool _isDead;

        public Character(string name) : base(name)
        {
            _healthPoints = 100;
            _actionPoints = 4;
            _armorHealthPoints = 0;
            _chanceCriticalHit = 0;
            _chanceDodge = 5;
            _chanceHitting = 95;//шанс попасть
            _isDead = false;
        }

        public Weapon RightHand 
        { 
            get { return _rightHand; } 
            set 
            { 
                _rightHand = value; //Добавление характеристик оружия
            } 
        }
        public Weapon LeftHand 
        { 
            get { return _leftHand; } 
            set 
            {
                Weapon weapon = _rightHand as TwoHandedWeapons;
                
                if(weapon is not null)
                {
                    _leftHand =  null;
                }

                _leftHand = value; 
            } 
        }
        public Armor Chest
        {
            get { return _chestArmor; }
            set 
            {
                CleaningCharacteristics();
                _chestArmor = value;
                AddingCharacteristics(value);
            }
        }
        
        public int ChanceHitting { get { return _chanceHitting; } }
        public int ChanceDodge { get { return _chanceDodge; } }
        public int ChanceCriticalHit { get { return _chanceCriticalHit; } }
        public bool IsDead { get { return _isDead;} }

        public void TakingDamage(int damage)
        {
            _healthPoints -= damage;
            if (_healthPoints <= 0)
            {
                _healthPoints = 0;
                _isDead=true;
                _notify?.Invoke($"{_name}", $"Погибает. ");
            }
        }

        public void NewRound()
        {
            _actionPoints = 4;
        }

        public void Restore()
        {
            _actionPoints = 4;
            _healthPoints = 100;
            _armorHealthPoints = _chestArmor is null ? 0 : _chestArmor.ArmorHealthPoints;
        }

        public void Attack(Character enemy)
        {
            if (_isDead)
            {
                return;
            }

            while(IsAcion(_rightHand.ActionPoinCost))
            {
                if (enemy.IsDead)
                {
                    return;
                }

                Weapon weapon = _rightHand as TwoHandedWeapons;

                if (weapon is not null)
                {
                    Attack(enemy, weapon);
                }
                else
                {
                    Attack(enemy, _rightHand as SingleHandedWeapons);
                    if (!IsAcion(_leftHand.ActionPoinCost))
                    {
                        return;//Больше не может совершать действия
                    }
                    Attack(enemy, _leftHand as SingleHandedWeapons);
                }
            }            
        }

        public void Attack(Character enemy, Weapon weapon)
        {
            int calculatedChanceHitting = new Random().Next(0, 100);
            if (_chanceHitting - enemy.ChanceDodge < calculatedChanceHitting)// промах
            {
                _notify?.Invoke($"{_name}", $"Промахивается по {enemy.Name}");
                return;
            }

            int damage = new Random().Next(weapon.MinDamageLevel, weapon.MaxDamageLevel);
            int calculatedChanceCriticalHit = new Random().Next(0, 100);

            damage = calculatedChanceCriticalHit < _chanceCriticalHit ? damage * 2 : damage;

            _notify?.Invoke($"{_name}", $"Попадает по {enemy.Name} и наносит [{damage}] едениц урона ");
            enemy.TakingDamage(damage);
        }

        private bool IsAcion(int actionPoints)
        {
            if (_actionPoints - actionPoints < 0)
            {
                return false;
            }
            else
            {
                _actionPoints -= actionPoints;
                return true;
            }
        }

        private void AddingCharacteristics(Armor armor)
        {
            _armorHealthPoints = armor.ArmorHealthPoints;
            foreach (var attribute in armor.Attributes)
            {
                switch (attribute.Name)
                {
                    case AttributesEnum.ChanceCriticalHit:
                        _chanceCriticalHit += attribute.Value;
                        break;
                    case AttributesEnum.ChanceDodge:
                        _chanceDodge += attribute.Value;
                        break;
                    case AttributesEnum.ChanceHitting:
                        _chanceHitting += attribute.Value;
                        break;
                    case AttributesEnum.HealthPoints:
                        _healthPoints += attribute.Value;
                        break;
                }
            }
        }

        private void CleaningCharacteristics()
        {
            if (_chestArmor is null)
            {
                return;
            }

            foreach (var attribute in _chestArmor.Attributes)
            {
                switch (attribute.Name)
                {
                    case AttributesEnum.ChanceCriticalHit:
                        _chanceCriticalHit -= attribute.Value;
                        break;
                    case AttributesEnum.ChanceDodge:
                        _chanceDodge -= attribute.Value;
                        break;
                    case AttributesEnum.ChanceHitting:
                        _chanceHitting -= attribute.Value;
                        break;
                    case AttributesEnum.HealthPoints:
                        _healthPoints -= attribute.Value;
                        break;
                }
            }
        }
        
    }
}
