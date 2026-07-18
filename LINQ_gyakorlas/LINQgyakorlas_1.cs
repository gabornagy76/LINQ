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
        }
    }
}
