namespace Task04
{
    internal interface IUnit
    {
        string Nickname { get; set; }

        int Hp { get; set; }

        int Mana { get; set; }

        int Damage { get; set; }
		//Severity	Code	Description	Project	File	Line	Suppression State
	    //Warning SA1516 : CSharp.Layout : Adjacent elements must be separated by a blank line.Task04 E:\mentoring\External lab\Tasks_Q4_2017\-EPAM_Ext_Lab_Q4_2017_Chikurov_Nikita\HWT_06\Task04\Interfaces\IUnit.cs	14	
		//просто пустыми строками свойства отделяй и не будет их 
        int Dex { get; set; } /// Ловкость
        int Str { get; set; } /// Сила SA1516 - НЕ ПОНИМАЮ ЧТО ЕМУ НАДО, ПЫТАЛСЯ РАСКРЫТЬ СКОБКИ СДЕЛАТЬ ОБЫЧНОЕ СВОЙСТВО- НЕ РАБОТАЕТ. ПРОСТО ПРОБЕЛЫ МЕЖДУ СТРОКАИ ТОЖЕ НЕ РАБОТАЮТ.
        int Int { get; set; } /// Интеллект
        int PosX { get; set; }

        int PosY { get; set; }

        int MoveSpeed { get; set; }
    }
}
