using System;
using System.Collections.Generic;
using System.Linq;

class Товар
{
    public string Назва { get; set; }
    public decimal Ціна { get; set; }
}

class Користувач
{
    public string Логін { get; set; }
    public string Пароль { get; set; }
    public List<Товар> ІсторіяПокупок { get; } = new List<Товар>();
}

class Магазин
{
    public List<Товар> Товари { get; } = new List<Товар>();
    public List<Користувач> Користувачі { get; } = new List<Користувач>();

    public void ДодатиКористувача(Користувач користувач)
    {
        Користувачі.Add(користувач);
    }

    public void ДодатиТовар(Товар товар)
    {
        Товари.Add(товар);
    }

    public List<Товар> ЗнайтиТовариЗаЦіною(decimal мінЦіна, decimal максЦіна)
    {
        return Товари.Where(товар => товар.Ціна >= мінЦіна && товар.Ціна <= максЦіна).ToList();
    }
}

class Program
{
    static void Main()
    {
        Магазин магазин = new Магазин();

        магазин.ДодатиТовар(new Товар { Назва = "Товар 1", Ціна = 100 });
        магазин.ДодатиТовар(new Товар { Назва = "Товар 2", Ціна = 50 });

        Користувач користувач = new Користувач { Логін = "user1", Пароль = "password1" };
        магазин.ДодатиКористувача(користувач);

        List<Товар> результатПошуку = магазин.ЗнайтиТовариЗаЦіною(30, 80);
        foreach (var товар in результатПошуку)
        {
            Console.WriteLine($"Знайдено: {товар.Назва}, Ціна: {товар.Ціна}");
        }
    }
}
