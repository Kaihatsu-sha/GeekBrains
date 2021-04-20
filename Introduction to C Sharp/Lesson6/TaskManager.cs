using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson6
{
    class TaskManager
    {
        Process[] _processes;
        public TaskManager()
        {
            _processes = Process.GetProcesses();
        }

        public void PrintAllProcesses()
        {
            for (int i = 0; i < _processes.Length; i++)
            {
                Console.WriteLine($"[{_processes[i].Id}] - {_processes[i].ProcessName}");
            }
        }

        public void KillProcessByName(string name)
        {
            Dictionary<int, string> processes = new Dictionary<int, string>();

            foreach (Process item in _processes)
            {
                if (item.ProcessName.Equals(name))
                {
                    processes.Add(item.Id, item.ProcessName);
                    item.Kill(); 
                }
            }

            PrintProcesses(processes);
        }

        public void KillProcessesById(int id)
        {
            Dictionary<int, string> processes = new Dictionary<int, string>();

            foreach (Process item in _processes)
            {
                if (item.Id.Equals(id))
                {
                    processes.Add(item.Id, item.ProcessName);
                    item.Kill();
                }
            }

            PrintProcesses(processes);
        }

        private void PrintProcesses(Dictionary<int, string> processes)
        {
            if (processes.Count == 0)
            {
                Console.WriteLine("Процесс не найден.");
                return;
            }

            Console.WriteLine("Завершенные процессы: ");
            foreach (KeyValuePair<int, string> item in processes)
            {
                Console.WriteLine($"[{item.Key}] - {item.Value}");
            }
        }
    }
}
