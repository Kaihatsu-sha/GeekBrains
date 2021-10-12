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
        /// Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам и был уникальным. 
        /// Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
        ///
        static int _accountNumbers = 0;
        int _accountNumber =-1;
        double _accountBalance;
        AccountTypeEnum _accountType;

        public void SetAccountNumber()
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
