using ConsoleUtils;

namespace Zoo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            double? whatever = InputService.GetDouble();
            if (whatever == null)
            {
                return;
            }

            Console.WriteLine("Спасибо!");
        }


    }
}
