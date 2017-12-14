namespace Task01
{
    using System;

    public class Round : Circle
    {
            public double GetArea()
            {
                return Math.PI * this.radius * this.radius;//todo pn ты должен использовать открытое свойство, а не поле
		}

            public string DisplayInfo()
            {
                return
                    $"\nThe circle with the center ({X}; {Y}) and the radius R = {Radius} has the area = {GetArea(): 0. ##} and the perimeter = {GetLength(): 0. ##}";
            }
    }
}
