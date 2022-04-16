using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.Visitor;

// Визитёр - граф, иерархическая структура.
internal class FileSystemVisitor
{
    public int Count { get; private set; }

    public void Visit(DirectoryInfo dirInfo)
    {
        foreach (FileInfo cs_file in dirInfo.GetFiles("*.cs"))
        {
            int count = GetLinesCount(cs_file);
            Count += count;
        }

        foreach (DirectoryInfo dir in dirInfo.GetDirectories())
        {
            Visit(dir);
        }

    }

    private int GetLinesCount(FileInfo fileInfo)
    {
        int count = GetLines(fileInfo)
            .Select(s => s.Trim())
            .Count(s => !string.IsNullOrEmpty(s) && s.StartsWith("//"));

        return count;
    }

    private IEnumerable<string> GetLines(FileInfo fileInfo)
    {
        using (StreamReader reader = fileInfo.OpenText())
        {
            while (!reader.EndOfStream)
            {
                yield return reader.ReadLine();
            }
        }
    }
}
