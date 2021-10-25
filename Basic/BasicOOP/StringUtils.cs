using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP
{
    public static class StringUtils
    {
        public static string RevertString(string inputString)
        {
            int length = inputString.Length;
            string revert = "";
            for (int i = length -1; i >=0 ; i--)
            {
                revert += inputString[i];
            }

            return revert;
        }

        public static void SearchMail(ref string s)
        {
            int indexSobaka = s.IndexOf('@');
            int startIndex = indexSobaka;
            while (true)
            {
                if (startIndex == -1)
                {
                    s = "";
                    return;
                }

                if (startIndex == 0 || s[startIndex -1] == ' ')
                {
                    break ;
                }

                startIndex -= 1;
            }

            int endIndex = indexSobaka;
            while (true)
            {
                if (endIndex == s.Length-1 || s[endIndex + 1] == ' ')
                {
                    endIndex += 1; 
                    break;
                }

                endIndex += 1;
            }

            s = s.Substring(startIndex, endIndex - startIndex);
        }

        public static string SearchMailsFromFile(string path, char separator)
        {
            string textFromFile = "";
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);

                textFromFile = Encoding.Default.GetString(array);
            }

            string[] splitText = textFromFile.Split(separator);
            textFromFile = "";
            for (int i = 0; i < splitText.Length; i++)
            {
                SearchMail(ref  splitText[i]);
                
                if (splitText[i].Length > 0)
                {
                    textFromFile += splitText[i] + separator;
                }
            }

            return textFromFile;
        }

        public static void WriteMailsToFile(string path, string mails)
        {
            using (FileStream fstream = File.Open(path, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fstream.Length];
                array = Encoding.Default.GetBytes(mails);
                fstream.Write(array, 0, array.Length);
            }
        }

    }
}
