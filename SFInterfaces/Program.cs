using System;

class Program
{
    public static void Main()
    {
        Writer writer = new Writer();
        ((IWriter)writer).Write();

        Worker worker = new Worker();
        worker.Build();
    }
}

public interface IWriter
{
    void Write();
}

public interface IReader
{
    void Read();
}

public interface IMailer
{
    void SendEmail();
}

public interface IWorker
{
    public void Build();
}

public class Writer: IWriter
{
    void IWriter.Write()
    {
        Console.WriteLine("Oh yeaaaah");
    }
}

public class Worker: IWorker
{
    public void Build()
    {
        Console.WriteLine("Build!");
    }
}

public class FIleManager : IWriter, IReader, IMailer
{
    public void Read()
    {
        throw new NotImplementedException();
    }

    public void SendEmail()
    {
        throw new NotImplementedException();
    }

    public void Write()
    {
        throw new NotImplementedException();
    }
}

