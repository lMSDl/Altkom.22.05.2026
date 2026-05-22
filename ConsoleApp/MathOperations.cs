namespace ConsoleApp
{
    internal static class MathOperations
    {
        public static int Sum(float a, float b) => (int)(a + b);

        //substract two float numbers and return integer, use block body syntax
        public static int Subtraction(float a, float b)
        {
            return (int)(a - b);
        }

        //multiply two numbers
        public static float Multiply(float a, float b)
        {
            return a * b;
        }

        //pierwotnie wygenerowana funkcja Sum została zmodyfikowana przez użytkownika
        //co spwodowało, że model dostosował kolejny generowany kod (Multiply) do zmian użytkownika
        //kontenst "nauki" copilot jest ograniczony do bieżącej sesji - np. wyłączenie IDE powoduje utratę pamięci "nauki"

        //dzielenie dwóch liczb
        public static float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return a / b;
        }

        //potęgowanie - podnoszenie do potęgi
        public static float Power(float a, float b)
        {
            return (float)Math.Pow(a, b);
        }

    }
}