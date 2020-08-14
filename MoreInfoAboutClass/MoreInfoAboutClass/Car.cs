using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsNObjects
{
    class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        // ------------   In c# you can overload constructors as well. If I do not include a parameter it's Make will be defaulted to Honda ------------- 
        public Car(string Make, string Color)
        {
            this.Make = Make;
            this.Color = Color;
        }
        public Car()
        {
            Make = "Honda";
            Color = "Red";
        }
    }
}
