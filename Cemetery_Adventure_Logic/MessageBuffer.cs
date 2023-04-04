using System.Collections.Concurrent;

namespace Cemetery_Adventure_Logic;

public class MessageBuffer
{
    public ConcurrentQueue<string> Messages = new ConcurrentQueue<string>();
    public int Size { get; init; }

    public MessageBuffer(int size)
    {
        Size = size;
    }

    public void Add(string message)
    {
        Messages.Enqueue(message);
        if (Messages.Count > Size)
        {
            Messages.TryDequeue(out var _);
        }
    }
}