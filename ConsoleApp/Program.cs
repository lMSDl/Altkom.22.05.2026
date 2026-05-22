
//funkcja wygenerowana na podstawie nagłówka funkcji
using ConsoleApp;

int Sum(float a, float b) => (int)(a + b);


//substract two float numbers and return integer, use block body syntax
int Subtract(float a, float b)
{
    return (int)(a - b);
}

//multiply two numbers
float Multiply(float a, float b)
{
    return (a * b);
}

//pierwotnie wygenerowana funkcja Sum została zmodyfikowana przez użytkownika
//co spwodowało, że model dostosował kolejny generowany kod (Multiply) do zmian użytkownika
//kontenst "nauki" copilot jest ograniczony do bieżącej sesji - np. wyłączenie IDE powoduje utratę pamięci "nauki"

//dzielenie dwóch liczb
float Divide(float a, float b) 
{
    if (b == 0)
    {
        throw new DivideByZeroException("Nie można dzielić przez zero.");
    }
    return a / b;
}


/*
 		Opisowe(naturalny język) – piszemy w komentarzu dokładnie, co chcemy uzyskać. Przykład:
		// Napisz metodę, która zwraca listę użytkowników posortowaną malejąco po dacie rejestracji
		Copilot wygeneruje kod odpowiadający opisowi.

		Deklaratywne – zamiast opisywać krok po kroku, wskazujemy efekt końcowy. Przykład:
		// Walidacja numeru PESEL
		Copilot wygeneruje całą metodę walidacji, łącznie z regexem lub logiką.

		Krok po kroku – dzielimy zadanie na mniejsze fragmenty, dzięki czemu mamy większą kontrolę nad wynikiem. Przykład:
		// 1. Sprawdź, czy numer ma 11 cyfr
		// 2. Oblicz sumę kontrolną
		// 3. Zwróć true/false

		Każdy styl ma swoje zastosowanie – opisowy dla szybkiego prototypowania, krokowy dla bardziej krytycznego kodu, deklaratywny dla standardowych fragmentów.
*/

Point3D CreatePoint(float[] tab)
{
    if (tab.Length != 3)
    {
        throw new ArgumentException("Tablica musi zawierać dokładnie 3 elementy.");
    }
    return new Point3D(tab[0], tab[1], tab[2]);
}




//funkcja generująca 10 produktów; użyj klasy Product
List<Product> GenerateProducts()
{
    var products = new List<Product>();
    for (int i = 1; i <= 10; i++)
    {
        products.Add(new Product
        {
            Name = $"Product {i}",
            Price = i * 10,
            Description = $"Description for Product {i}",
            Category = $"Category {((i - 1) / 5) + 1}",
            CategoryName = $"Category Name {((i - 1) / 5) + 1}"
        });
    }
    return products;
}


