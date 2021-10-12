using System;
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
            if (amount > 0)
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
    }
}
