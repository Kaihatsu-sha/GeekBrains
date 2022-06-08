namespace Kaihatsu.ASP.MVC.Practice5.Scaner;

public class FileScaner : IScaner
{
    private bool _isReady;
    private readonly FileInfo _file;

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

    public FileScaner(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();

        _file = new FileInfo(path);
        _isReady = true;
    }

    public byte[] Scanning()
    {
        _isReady = false;
        byte[] data;

        try
        {
            using (FileStream stream = _file.OpenRead())
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
