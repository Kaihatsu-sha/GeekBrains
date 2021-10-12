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
        /// В классе банковский счет, удалить методы заполнения полей. Вместо этих методов создать конструкторы. 
        /// Переопределить конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета, 
        /// конструктор для заполнения баланса и типа банковского счета. 
        /// Каждый конструктор должен вызывать метод, генерирующий номер счета.
        ///
        static int _accountNumbers = 0;
        int _accountNumber =-1;
        double _accountBalance;
        AccountTypeEnum _accountType;


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

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        public double GetAccountBalance()
        {
            return _accountBalance;
        }

        public AccountTypeEnum GetAccountType()
        {
            return _accountType;
        }
    }
}
