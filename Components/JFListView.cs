namespace JFlash.Components;

public class JFListView : ListView
{
    private long LastFileSize = 0;
    private string LogFilePath = string.Empty;
    private FileSystemWatcher? fsWatcher;

    public JFListView()
    {
        //this.View = View.Details;
        Columns.Add("Prompt", 80);
        Columns.Add("Answer", 80);
        Columns.Add("Attempt", 80);
    }

    public void Start(string logFile)
    {
        LogFilePath = logFile;
        Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath) ?? string.Empty);

        // Load existing log lines at startup
        LastFileSize = ReadAllLinesToListView();

        StartWatchingLogFile();
    }

    private void StartWatchingLogFile()
    {
        fsWatcher = new FileSystemWatcher
        {
            Path = Path.GetDirectoryName(LogFilePath) ?? string.Empty,
            Filter = Path.GetFileName(LogFilePath),
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
            EnableRaisingEvents = true
        };

        fsWatcher.Changed += (s, e) => ReadNewLogLines();
    }

    private void ReadNewLogLines()
    {
        try
        {
            using var fs = new FileStream(LogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fs.Seek(LastFileSize, SeekOrigin.Begin);
            using var sr = new StreamReader(fs);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                InsertLineToListViewTop(line);
            }

            LastFileSize = fs.Length;
        }
        catch (IOException)
        {
            LastFileSize = 0;

            // Log or handle read errors
        }
    }

    public void WriteLogHeading(string heading)
    {
        File.AppendAllText(LogFilePath, heading);
    }

    public void WriteLogLine(string query, string correctEntry, string wrongEntry)
    {
        File.AppendAllText(LogFilePath, $"{query};{correctEntry};{wrongEntry};{DateTime.Now}{Environment.NewLine}");
    }

    public void InsertLineToListViewTop(string logEntry)
    {
        if (InvokeRequired)
        {
            Invoke(() => InsertLineToListViewTop(logEntry));
            return;
        }

        // Example: Parse line into columns
        string timestamp = DateTime.Now.ToString("HH:mm:ss");

        string[] x = logEntry.Split(';');

        ListViewItem item = new([..x]);
        Items.Insert(0, item); // Most recent at top

        // Optional: Limit to last N entries
        if (Items.Count > 1000)
            Items.RemoveAt(Items.Count - 1);
    }

    private long ReadAllLinesToListView()
    {
        try
        {
            if (!File.Exists(LogFilePath))
            {
                return 0;
            }

            string[] logEntry = File.ReadAllLines(LogFilePath);
            foreach (string entry in logEntry)
            {
                InsertLineToListViewTop(entry);
            }

            return new FileInfo(LogFilePath).Length;
        }
        catch (IOException ex)
        {
            // Handle error (e.g., log to debug output)
            Console.WriteLine("Error reading log file: " + ex.Message);
        }

        return 0;
    }

    public void ClearLogs()
    {
        try
        {
            File.WriteAllText(LogFilePath, string.Empty); // Clear log file
            Items.Clear();                                // Clear UI
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to clear log: " + ex.Message);
        }
    }
}
