using System;

namespace OOP_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ACoder coder = new ACoder();
            coder.Message = "АБВГДЯя";
            Console.WriteLine(coder.Message);

            coder.Encode();
            Console.WriteLine(coder.Message);

            coder.Decode();
            Console.WriteLine(coder.Message);

            BCoder bCoder = new BCoder();
            bCoder.Message = "АБВГДЯя";
            Console.WriteLine(bCoder.Message);

            bCoder.Encode();
            Console.WriteLine(bCoder.Message);

            bCoder.Decode();
            Console.WriteLine(bCoder.Message);

            Console.ReadKey();
        }
    }
}
