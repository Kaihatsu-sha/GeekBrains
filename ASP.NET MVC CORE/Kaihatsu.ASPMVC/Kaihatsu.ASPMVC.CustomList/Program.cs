// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASPMVC.CustomList;

CustomConcurrentList<int> concurentList = new CustomConcurrentList<int>();

concurentList.Contains(1);
concurentList.Add(1);
concurentList.Add(2);
concurentList.Contains(1);
concurentList.Add(3);
concurentList.Add(4);
concurentList.Add(5);
concurentList.Remove(6);
concurentList.Remove(1);
concurentList.Add(7);

concurentList.Clear();
concurentList.Add(1);
concurentList.Add(2);
concurentList.Insert(1, 8);

concurentList.IndexOf(5);

foreach (int item in concurentList)
{
    Console.WriteLine(item);
}
