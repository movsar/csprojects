namespace ConsoleUtils
{
    public class InputService
    {
        // Ввод числа с плавающей запятой
        public static double? GetDouble()
        {
            // Создается пустая переменная для результата
            double result;

            // Берем ввод пользователя и сохраняем как строку в input
            string? input = Console.ReadLine();

            bool parsingResult = double.TryParse(input, out result);
            if (!parsingResult)
            {
                Console.WriteLine("Неверный ввод");
            }

            return result;
        }

        public static int? GetOption(string[] modeDescriptions)
        {
            Console.WriteLine("Выберите режим: ");

            foreach (var modeDescription in modeDescriptions)
            {
                Console.WriteLine(modeDescription);
            }

            try
            {
                // Пытаемся получить числовое значение
                int? mode = Convert.ToInt32(Console.ReadLine());

                if (mode < 0 || mode > modeDescriptions.Length)
                {
                    // Если ошибка, запускаем текущий метод, заново
                    return GetOption(modeDescriptions);
                }

                // Если код дошел сюда, возвращаем значение выбранного режима
                return mode;
            }
            catch (Exception)
            {
                // Если ошибка, запускаем текущий метод, заново
                return GetOption(modeDescriptions);
            }
        }

        // Ввод числа
        public static int? GetInt()
        {
            int result;
            string? input = Console.ReadLine();
            bool parsResult = int.TryParse(input, out result);
            if (!parsResult)
            {
                Console.WriteLine("Ошибка ввода");
            }
            return result;
        }

        // Ввод даты
        public static DateTime? GetDate()
        {
            string? rawDate = Console.ReadLine();
            DateTime date;
            bool dateGood = DateTime.TryParse(rawDate, out date);
            if (!dateGood)
            {
                Console.WriteLine("Ошибка ввода");
            }
            return date;
        }

        // Ввод текста (строки)
        public static string? GetString()
        {
            string? rawString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rawString))
            {
                return null;
            }
            return rawString;
        }
    }
}