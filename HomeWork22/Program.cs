internal class Program
{
    public static double ConvertToDouble(string value)
    {
        if(value == null) return 0;
        bool checkComma = false;//проверка на запятую
        double result = 0, afterComma = 0;//результат и число после запятой
        ulong toComma = 0; // до запятой
        char[] chars = value.ToCharArray();
        foreach (char c in chars)
        {
            if (c == ',' || c == '.' && checkComma == false) { checkComma = true; continue; }
            if (c == ',' || c == '.' && checkComma == true) { throw new Exception($"Символ разделитель использовался повторно."); }
            if (!Char.IsDigit(c)) { throw new Exception($"Используется недопустимы символ \"{c}\""); }
            if (checkComma == false)
            {
                switch (c)
                {
                    case '1': toComma *= 10; toComma += 1; break;
                    case '2': toComma *= 10; toComma += 2; break;
                    case '3': toComma *= 10; toComma += 3; break;
                    case '4': toComma *= 10; toComma += 4; break;
                    case '5': toComma *= 10; toComma += 5; break;
                    case '6': toComma *= 10; toComma += 6; break;
                    case '7': toComma *= 10; toComma += 7; break;
                    case '8': toComma *= 10; toComma += 8; break;
                    case '9': toComma *= 10; toComma += 9; break;
                    case '0': toComma *= 10; toComma += 0; break;
                }
            }
            else
            {
                switch (c)
                {
                    case '1': afterComma *= 10; afterComma += 1; break;
                    case '2': afterComma *= 10; afterComma += 2; break;
                    case '3': afterComma *= 10; afterComma += 3; break;
                    case '4': afterComma *= 10; afterComma += 4; break;
                    case '5': afterComma *= 10; afterComma += 5; break;
                    case '6': afterComma *= 10; afterComma += 6; break;
                    case '7': afterComma *= 10; afterComma += 7; break;
                    case '8': afterComma *= 10; afterComma += 8; break;
                    case '9': afterComma *= 10; afterComma += 9; break;
                    case '0': afterComma *= 10; afterComma += 0; break;
                }
            }
        } 
        if(chars.Length > 17) { throw new Exception("Тип double может вмещать не более 16 значащих цифр"); }
        ulong i = 10; //число на которое нужно разделить afterComma, чтобы получить 0.afterComma
        while(true) //не хотел использовать Convert.ToString, чтобы узнать количество цифр
        { 
            if ((afterComma / i) < 1) { break; } 
            i *= 10; 
        }

        result = toComma + (afterComma / i);
        return result;
    }
    private static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Введите число");
            string a = Console.ReadLine();
            try
            {
                double d = ConvertToDouble(a);
                Console.WriteLine($"double = {d}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}