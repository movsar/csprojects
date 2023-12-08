namespace ConsoleUtils
{
    public static class InputService
    {
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

        public static int? SelectMode(string[] modeDescriptions)
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
                    return SelectMode(modeDescriptions);
                }

                // Если код дошел сюда, возвращаем значение выбранного режима
                return mode;
            }
            catch (Exception)
            {
                // Если ошибка, запускаем текущий метод, заново
                return SelectMode(modeDescriptions);
            }
        }
    }
}
