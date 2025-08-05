using System;
using System.Text;

namespace Module18._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //создадим отправителя
            var sender = new Sender();

            //создадим получателя
            var receiver = new Receiver();

            //создадим команду
            var commandOne = new CommandOne(receiver);

            //инициализация команды
            sender.SetCommand(commandOne);
                        
            //выполнение
            sender.Run();
        }
    }
}
