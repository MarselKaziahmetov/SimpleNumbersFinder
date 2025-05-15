namespace SimpleNumbersSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var simpleNumbers = new SimpleNumbersFinder();
            simpleNumbers.ExecuteSimpleNumbersFinder();
        }
    }

    public class SimpleNumbersFinder
    {
        private int leftPoint;
        private int rightPoint;
        private List<int> interval = new List<int>();
        private List<int> simpleNumbers = new List<int>();

        public void ExecuteSimpleNumbersFinder()
        {
            InputInterval();
            FillInterval(leftPoint, rightPoint, interval);
            DetermineSimpleNumbers(interval);
            Console.WriteLine($"Количество простых чисел наденных в интервале: {simpleNumbers.Count}");
        }

        private void InputInterval()
        {
            bool isValidated = false;

            while (!isValidated)
            {
                Console.Write("Введите левую точку интервала: ");
                var a = Console.ReadLine();

                Console.Write("Введите правую точку интервала: ");
                var b = Console.ReadLine();

                isValidated = ValidateInput(a, b);
            }
        }

        private bool ValidateInput(string a, string b)
        {
            try
            {
                leftPoint = int.Parse(a);
                rightPoint = int.Parse(b);
            }
            catch (Exception)
            {
                Console.WriteLine("\nВведены некоректные данные, попробуйте еще раз...\n");
                return false;
                throw;
            }

            if (leftPoint > rightPoint)
            {
                Console.WriteLine("\nВведены некоректные данные, попробуйте еще раз...\n");
                return false;
            }
            
            return true;
        }

        private void FillInterval(int a, int b, List<int> array)
        {
            Console.Write("\nПолученный интервал: [");

            for (int i = a; i <= b; i++)
            {
                array.Add(i);
                Console.Write($"{i}, ");
            }

            Console.Write("]\n");
        }

        private void DetermineSimpleNumbers(List<int> array)
        {
            Console.Write("\nПростые числа: [");
            foreach (int i in array)
            {
                if (IsSimpleNumber(i))
                {
                    simpleNumbers.Add(i);
                    Console.Write($"{i}, ");
                }
            }
            Console.Write("]\n");
        }

        private bool IsSimpleNumber(int number)
        {
            if (number <= 1) 
                return false;
            if (number == 2) 
                return true;
            if (number % 2 == 0) 
                return false;

            int boundary = (int)Math.Sqrt(number);
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}