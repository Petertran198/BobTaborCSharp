using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class NamedObject
    {
        public string Name { get; set; }
        public NamedObject(string name)
        {
            Name = name;
        }
    }
}
