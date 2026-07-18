using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_gyakorlas
{
    internal class LINQgyakorlas_1
    {
        public static void Futtatas(List<Student> students)
        {
            Console.WriteLine("LINQ gyakorló alkalmazás");
            Console.WriteLine("------------------------");

            // Nézzük meg a lista (tábla) elemeit
            Console.WriteLine("\nA tanulók adatai:");
            Console.WriteLine("------------------------");

            foreach (Student item in students)
            {
                Console.WriteLine(
                    $"{item.Id,3}. {item.Name,-18}" +
                    $"{item.Age} éves, " +
                    $"{item.ClassName,5}, " +
                    $"{item.Average} "
                    );
            }


            // Where - szűrés
            Console.WriteLine("\nLegalább 4-es átlagú tanulók:");
            Console.WriteLine("------------------------");

            IEnumerable<Student> goodStudents = students
                // Az aktuális Student objektumot veszi és megtartja a feltételnek (az átlaga >= 4) megfelelőt
                .Where(st => st.Average >= 4);

            foreach (Student item in goodStudents)
            {
                Console.WriteLine($"{item.Name,-18} - {item.Average,4:F2}");
            }


            // Sorbarendezés
            Console.WriteLine("\nNév szerinti sorbarendezés:");
            Console.WriteLine("------------------------");

            IEnumerable<Student> studentsByName = students.OrderBy(st => st.Name);

            foreach (Student item in studentsByName)
            {
                Console.WriteLine($"{item.Name}");
            }


            // Csökkenő sorrendbe rendezés
            Console.WriteLine("\nÁtlag szerint csökkenő sorrend:");
            Console.WriteLine("------------------------");

            IEnumerable<Student> studentsByAverage = students.OrderByDescending(st => st.Average);

            foreach (Student item in studentsByAverage)
            {
                Console.WriteLine($"{item.Name,-18}  - {item.Average,4:F2}");
            }


            // Több szempont szerinti rendezés
            Console.WriteLine("\nosztály szerinti, majd név szerint csökkenő sorrend:");
            Console.WriteLine("------------------------");

            IEnumerable<Student> orderedStudents = students
                .OrderBy(st => st.ClassName)
                // Ez a záradék csak akkor lép életbe, ha az első rendezési szempont alapján több elem azonos helyre kerülne.
                .ThenByDescending(st => st.Name);

            foreach (Student item in orderedStudents)
            {
                Console.WriteLine($"{item.ClassName,-5}  - {item.Name,-18}");
            }


            // Select: Csak bizoyos adatok kiválasztása
            Console.WriteLine("\nCsak a tanulónevek gyűjteménybe gyűjtése:");
            Console.WriteLine("------------------------");

            IEnumerable<string> studentNames = students
                .Select(st => st.Name);

            foreach(string item in studentNames)
            {
                Console.WriteLine(item);
            }



        }
    }
}
