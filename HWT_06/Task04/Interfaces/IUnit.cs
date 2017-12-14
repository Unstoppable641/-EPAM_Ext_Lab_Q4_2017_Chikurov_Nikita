namespace Task04
{
    internal interface IUnit
    {
        string Nickname { get; set; }

        int Hp { get; set; }

        int Mana { get; set; }

        int Damage { get; set; }

        int Dex { get; set; } /// Ловкость
        int Str { get; set; } /// Сила SA1516 - НЕ ПОНИМАЮ ЧТО ЕМУ НАДО, ПЫТАЛСЯ РАСКРЫТЬ СКОБКИ СДЕЛАТЬ ОБЫЧНОЕ СВОЙСТВО- НЕ РАБОТАЕТ. ПРОСТО ПРОБЕЛЫ МЕЖДУ СТРОКАИ ТОЖЕ НЕ РАБОТАЮТ.
        int Int { get; set; } /// Интеллект
        int PosX { get; set; }

        int PosY { get; set; }

        int MoveSpeed { get; set; }
    }
}
