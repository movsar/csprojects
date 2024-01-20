using System;

public class Class1
{
    void DisplayRandomNumbers()
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{random.Next(1, 100)} ");
        }

        Console.WriteLine();
    }
}
