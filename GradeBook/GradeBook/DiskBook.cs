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
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var results = new Statistics();

            using (var reader = File.OpenText($"../../../../{Name}.txt"))
            {
                var line = reader.ReadLine();
                // While it isnt the end of the file
                while (line != null)
                {
                    var number = double.Parse(line);
                    results.AddGrade(number);
                    line = reader.ReadLine();
                }
            }

            return results;

        }
    }
}
