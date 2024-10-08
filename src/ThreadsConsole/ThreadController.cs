﻿using System.IO.Pipes;

namespace ThreadsConsole;

public class ThreadController(NamedPipeServerStream serverStream)
{
    private readonly List<FileReader> _readers = [];
    
    public void AddReaders(string path, int delay, int itemsPerIteration, int count)
    {
        for (var _ = 0; _ < count; _++)
        {
            var reader = new FileReader(path, delay, itemsPerIteration, _readers.Count + 1);
            _readers.Add(reader);
            reader.StartReader(new StreamWriter(serverStream));
        }
    }
    public void RemoveLastReader()
    {
        _readers.Last().StopReader();
        _readers.RemoveAt(_readers.Count - 1);
    }
    
    public void StopAllReaders()
    {
        while (_readers.Count != 0)
        {
            RemoveLastReader();
        }
    }
}