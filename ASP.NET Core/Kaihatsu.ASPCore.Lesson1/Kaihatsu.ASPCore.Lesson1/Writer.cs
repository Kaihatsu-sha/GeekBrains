using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPCore.Lesson1
{
    internal class Writer
    {
        private string _path;
        public Writer(string path)
        {
            _path = path;
        }

        public async Task AddInFile(Post post)
        {
            using (FileStream streamWriter = new FileStream(_path, FileMode.Append))
            {
                try
                {

                    string postStr = post.ToString();
                    byte[] buffer = new byte[postStr.Length];
                    buffer = Encoding.ASCII.GetBytes(postStr);
                    await streamWriter.WriteAsync(buffer);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
