using System;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Module18._4
{
    class CommandOne(Receiver receiver) : Command
    {
        Receiver receiver = receiver;

        public override void Run()
        {
            Console.WriteLine("Запущен процесс...");
            Receiver.OperationVideo().GetAwaiter().GetResult(); // Ждем завершения операции
        }
    }
}
