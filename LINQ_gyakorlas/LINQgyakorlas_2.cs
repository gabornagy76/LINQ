using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_gyakorlas
{
    internal class LINQgyakorlas_2
    {
        public static void Futtatas(List<Student> students)
        {
            // Több művelet.
            // Keressük meg a 17 éves, legalább 3.5 átlagú tanulókat, majd rendezzük őket átlag szerinti csökkenő sorrendbe.
            // Csak a nevüket és átlagukat kérjük le.
            Console.WriteLine("\nVan-e 3-as átlag feletti tanuló, aki 17 éves:");
            Console.WriteLine("------------------------");
            // Mivel a gyakorlatban szinte sosem a teljes objektumot adjuk át, ezért a Select() részben egy névtelen kollekciót hozunk létre.
            var selectedStudents = students
                .Where(st => st.Age == 17)
                .Where(st => st.Average >= 3.5)
                .OrderByDescending(st => st.Average)
                // Csak a nevüket és átlagukat kérjük le.
                .Select(st => new
                {
                    TanuloNev = st.Name,
                    TanuloAtlag = st.Average
                });

            // A Where() záradékok össze is vonhatóak:
            // .Where(st => st.Age == 17 && st.Average >= 3.5)

            foreach (var item in selectedStudents)
            {
                Console.WriteLine($"{item.TanuloNev,-18} : {item.TanuloAtlag}");
            }


            // Csoportosítás - GroupBy()
            // Csoportosítsuk a tanulókat osztály szerint.
            Console.WriteLine("\nCsoportosítás osztály szerint:");
            Console.WriteLine("------------------------");

            var studentsByClass = students
                .GroupBy(st => st.ClassName);

            foreach (var classGroup in studentsByClass)
            {
                // A .Key mindig a csoportosítás szerinti mezőt jeleni.
                Console.WriteLine($"Oszály: {classGroup.Key}");
                foreach (var item in classGroup)
                {
                    Console.WriteLine($"\t{item.Name} - {item.Average}");
                }
            }


            //
        }
    }
}
