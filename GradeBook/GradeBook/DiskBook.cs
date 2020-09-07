using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GradeBook
{
    // Write to file class
    public class DiskBook : Book, IBook
    {
        public DiskBook(string name, string category) : base(name, category)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"../../../../{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
