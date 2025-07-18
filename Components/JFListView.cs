﻿using JFlash.Classes;
using System.Diagnostics;

namespace JFlash.Components;

public class JfListView : ListView
{
    const int MaxItems = 600;

    private long LastFileSize = 0;
    private string LogFilePath = string.Empty;
    private FileSystemWatcher? fsWatcher;
    private readonly ListViewGroup MistakesListViewGroup;

    public JfListView()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        UpdateStyles();

        MistakesListViewGroup = new()
        {
            Header = "Mistakes",
            Name = "mistakes",
            Subtitle = "Kanji to English"
        };

        Groups.Add(MistakesListViewGroup);

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
        catch (IOException ex)
        {
            LastFileSize = 0;

            // Log or handle read errors
            JfHelper.LogError($"ReadNewLogLines, ex:\n{ex.Message}");
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

        string[] logData = logEntry.Split(';');

        if (logData.Length < Columns.Count)
        {
            Debug.WriteLine($"Skipping malformed log line: {logEntry}");
            EndUpdate();
            return;
        }

        if (logData.Length != Columns.Count)
        {
            Array.Resize(ref logData, Columns.Count);
        }

        // Build new item list starting with the new entry
        var updatedItems = new List<string[]>
        {
            logData
        };

        foreach (ListViewItem item in Items.OfType<ListViewItem>().Take(MaxItems - 1))
        {
            if (item.Tag is string[] existingData)
            {
                updatedItems.Add(existingData);
            }
        }

        Items.Clear();

        var newItems = updatedItems
            .Select(data => CreateListViewItem(data, MistakesListViewGroup))
            .ToArray();

        Items.AddRange(newItems);

        if (MistakesListViewGroup.Items.Count > 0)
        {
            MistakesListViewGroup.Items[0].EnsureVisible();
        }

        EndUpdate();
    }

    private static ListViewItem CreateListViewItem(string[] entry, ListViewGroup group)
    {
        return new([.. entry], group)
        {
            Tag = entry,
        };
    }

    private static ListViewItem CreateListViewItem(string entry, ListViewGroup group)
    {
        string[] x = entry.Split(';');
        return CreateListViewItem(x, group);
    }

    private long ReadAllLinesToListView()
    {
        if (!File.Exists(LogFilePath))
            return 0;

        try
        {
            var logEntries = File.ReadAllLines(LogFilePath);
            var recentItems = logEntries
                .Reverse()
                .Take(MaxItems)
                .Select(entry => CreateListViewItem(entry, MistakesListViewGroup))
                .ToArray();

            Items.AddRange(recentItems);

            return new FileInfo(LogFilePath).Length;
        }
        catch (IOException ex)
        {
            JfHelper.LogError($"ReadAllLinesToListView,\n  Ex: {ex.Message}");
            return 0;
        }
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
            JfHelper.LogError($"ClearLogs,\n  Ex:: {ex.Message}");
            MessageBox.Show("Failed to clear log: " + ex.Message);
        }
    }
}
