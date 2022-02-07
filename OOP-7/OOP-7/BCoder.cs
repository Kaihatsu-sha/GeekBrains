using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_7
{
    internal class BCoder : IСoder
    {
        private int _start;
        private int _end;


        public string Message { get; set; }

        public BCoder()
        {
            _start = 'А';//С 1040 по 1103
            _end = 'я';          
        }

        public void Decode()
        {
            if (Message.Length <= 0)
            {
                throw new ArgumentNullException("Пустое сообщение");
            }
            StringBuilder sb = new StringBuilder();
            foreach (char item in Message)
            {
                int number = item;
                number = _end - number;//Из текущей позии вычитаем начало
                number += _start;

                string s = Char.ConvertFromUtf32(number);
                sb.Append(s);
            }
            Message = sb.ToString();
        }

        public void Encode()
        {
            if (Message.Length <= 0)
            {
                throw new ArgumentNullException("Пустое сообщение");
            }

            StringBuilder sb = new StringBuilder();
            foreach (char item in Message)
            {
                int number = item;
                number -=_start;//Из текущей позии вычитаем начало
                number = _end - number;   

                string s = Char.ConvertFromUtf32(number);
                sb.Append(s);
            }
            Message = sb.ToString();
        }
    }
}
