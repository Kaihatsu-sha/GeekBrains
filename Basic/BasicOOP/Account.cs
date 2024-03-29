﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP
{
    
    public class Account
    {
        ///
        /// В классе все методы для заполнения и получения значений полей заменить на свойства. Написать тестовый пример.
        ///(*) Добавить в класс счет в банке два метода: снять со счета и положить на счет.
        ///Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.
        ///
        static int _accountNumbers = 0;
        int _accountNumber =-1;
        double _accountBalance;
        AccountTypeEnum _accountType;


        public int Number
        { get { return _accountNumber; } }

        public double Balance
        { get {  return _accountBalance; }  }

        public AccountTypeEnum Type
        {  get {  return _accountType; }  }


        public Account()
            : this(0, AccountTypeEnum.Debit)
        {

        }

        public Account(double accountBalance)
            : this(accountBalance, AccountTypeEnum.Debit)
        { 

        }

        public Account(AccountTypeEnum accountType)
            : this(0, accountType)
        {

        }

        public Account(double accountBalance, AccountTypeEnum accountType)
        {
            _accountBalance = accountBalance;
            _accountType = accountType;
            SetAccountNumber();
        }


        void SetAccountNumber()
        {
            if (_accountNumber < 0)
            {
                _accountNumber = ++_accountNumbers;
            }
        }

        /// <summary>
        /// Снятие со счёта
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Withdraw(double amount)//Снятие
        {
            if (amount >= 0)
            {
                if (_accountBalance - amount >= 0)
                {
                    _accountBalance -= amount;
                }
                else
                {
                    throw new ArgumentException($"Указанная сумма недоступна для снятия. Баланс:{_accountBalance}");
                }
            }
            else
            {
                throw new ArgumentException("Сумма на снятие не может быть меньше 0.");
            }
        }

        public void TransferFromAccount(Account sender,double amount)//Перевод со счета
        {
            try
            {
                sender.Withdraw(amount);
                Replenish(amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// Пополнение счёта
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Replenish(double amount)//Пополнение
        {
            if (amount > 0)
            {
                _accountBalance += amount;
            }
            else
            {
                throw new ArgumentException("Сумма на пополнение не может быть меньше 0.");
            }
        }

        //Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
        //Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode(). 
        //Переопределить метод ToString() для печати информации о счете.
        //Протестировать функционирование переопределенных методов и операторов на простом примере.

        public static bool operator ==(Account accountA, Account accountB)
        {
            if(accountA is null && accountB is null)
            {
                return true;
            }

            return accountA.Equals(accountB);            
        }

        public static bool operator !=(Account accountA, Account accountB)
        {
            if (accountA is null && accountB is null)
            {
                return false;
            }

            return !accountA.Equals(accountB);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Account);
        }

        public bool Equals(Account account)
        {
            if(account is null)
            {
                return false;
            }

            return account.Number == Number && account.Type == Type && account.Balance == Balance;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode() + Type.GetHashCode() + Balance.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Type} счет {Number} с балансом {Balance}";
        }
    }
}
