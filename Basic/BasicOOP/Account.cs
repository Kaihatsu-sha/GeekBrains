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
        /// Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип). 
        /// Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать
        ///
        int _accountNumber;
        double _accountBalance;
        AccountTypeEnum _accountType;

        public void SetAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber;   
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        public void SetAccountBalance(double accountBalance)
        {
            _accountBalance = accountBalance;
        }

        public double GetAccountBalance()
        {
            return _accountBalance;
        }

        public void SetAccountType(AccountTypeEnum accountType)
        {
            _accountType = accountType;
        }

        public AccountTypeEnum GetAccountType()
        {
            return _accountType;
        }
    }
}
