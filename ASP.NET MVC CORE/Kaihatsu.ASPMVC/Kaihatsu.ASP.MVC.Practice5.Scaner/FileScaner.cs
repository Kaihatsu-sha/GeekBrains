namespace Kaihatsu.ASP.MVC.Practice5.Scaner;

public class FileScaner : IScaner
{
    private bool _isReady = false;

    public bool IsReady { get => _isReady; }

    public SystemResource SystemResource
    {
        get => new SystemResource
        {
            Time = DateTime.Now,
            MemoryLoad = new Random().Next(0, 8_000),
            ProcessorLoad = new Random().Next(5, 100)
        };
    }

    public FileScaner()
    {
        _isReady = true;
    }

    public byte[] Scanning(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();

        FileInfo file = new FileInfo(path);

        _isReady = false;
        byte[] data;

        try
        {
            using (FileStream stream = file.OpenRead())
            {
                data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
            }
        }
        finally
        {
            _isReady = true;
        }

        return data;
    }

}
