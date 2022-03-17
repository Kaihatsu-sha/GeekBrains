using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPCore.Lesson1
{
    internal class Worker
    {
        public Worker() 
        {
            Console.WriteLine("Worker start");
            //Start();
            Console.WriteLine("Worker ending");
        }

        internal async Task Start() 
        {
            Console.WriteLine("Create tasks");
            List<Task> gettingPostTasks = new List<Task> { };
            for (int i = 4; i < 14; i++)
            {
                Client client = new Client();
                gettingPostTasks.Add(client.GetPost("https://jsonplaceholder.typicode.com/posts/" + i));
            }

            Console.WriteLine("Await tasks");

            while (gettingPostTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(gettingPostTasks);
                Post post = ((Task<Post>)finishedTask).Result;
                Console.WriteLine($"FinishedTask: {post.Id}");
                await StartWrite(post);
                gettingPostTasks.Remove(finishedTask);
            }

            Console.WriteLine("Complit Getting All");
        } 

        private async Task StartWrite(Post post) 
        {
            Console.WriteLine($"Start write: {post.Id}");

            string path = Path.Combine(Directory.GetCurrentDirectory(), "result.txt");
            Writer writer = new Writer(path);
            await writer.AddInFile(post);

            Console.WriteLine($"Complit write: {post.Id}");
        }
    }
}
