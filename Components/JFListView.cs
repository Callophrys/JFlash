using System.Diagnostics;

namespace JFlash.Components;

public class JFListView : ListView
{
    private long LastFileSize = 0;
    private string LogFilePath = string.Empty;
    private FileSystemWatcher? fsWatcher;

    public JFListView()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        UpdateStyles();

        CreateColumns();
    }

    private void CreateColumns()
    {
        Columns.Add("Prompt", 80);
        Columns.Add("Answer", 80);
        Columns.Add("Attempt", 80);
        Columns.Add("Source", 80);
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

    public void WriteLogLine(string query, string correctEntry, string wrongEntry, string setName)
    {
        File.AppendAllText(LogFilePath, $"{query};{correctEntry};{wrongEntry};{setName}{Environment.NewLine}");
    }

    public void InsertLineToListViewTop(string logEntry)
    {
        if (InvokeRequired)
        {
            Invoke(() => InsertLineToListViewTop(logEntry));
            return;
        }

        BeginUpdate();

        if (Columns.Count == 0)
        {
            CreateColumns();
        }

        string[] logData = logEntry.Split(';');
        //Debug.WriteLine($"[AddLog] Columns: {Columns.Count}, Items: {Items.Count}, Split Count: {x.Length}");

        if (logData.Length < Columns.Count)
        {
            Debug.WriteLine($"Skipping malformed log line: {logEntry}");
            return;
        }

        // Trim or pad the array to exactly Columns.Count
        if (logData.Length != Columns.Count)
        {
            Array.Resize(ref logData, Columns.Count);
        }

        // Limit to last N entries
        const int mxItems = 1000;
        if (Items.Count > mxItems) Items.RemoveAt(Items.Count - 1);

        int itemsToKeep = Math.Min(Items.Count, mxItems - 1); // Subtract 1 to allow for insert to top.
        ListViewItem[] temp = new ListViewItem[itemsToKeep + 1];
        temp[0] = new([..logData]);
        for (int i = 0; i < itemsToKeep; i++)
            temp[i + 1] = Items[i];

        Items.Clear();
        Items.AddRange(temp);

        Items[0].EnsureVisible();

        EndUpdate();
    }

    private static ListViewItem CreateListViewItem(string entry)
    {
        string[] x = entry.Split(';');
        //Debug.WriteLine($"[AddLog] Columns: {Columns.Count}, Items: {Items.Count}, Split Count: {x.Length}");

        return new([..x]);
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
            Items.AddRange(logEntry.Reverse().Select(x => CreateListViewItem(x)).ToArray());

            return new FileInfo(LogFilePath).Length;
        }
        catch (IOException ex)
        {
            // Handle error (e.g., log to debug output)
            Debug.WriteLine("Error reading log file: " + ex.Message);
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
