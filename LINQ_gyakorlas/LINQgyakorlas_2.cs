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


            // Csoportműveletek
            // Osztályátlag számítás
            Console.WriteLine("\nOsztályonkénti átlag számítás:");
            Console.WriteLine("------------------------");
            var classAverages = students
                // Csoportosítunk osztálynév (ClassName) szerint, az st egy egyedi Student objektum a students objektumlistából
                .GroupBy(st => st.ClassName)
                
                // Kiválasztjuk a csoportból azokat a tulajdonságokat (mezőket), amelyekre szükségünk van.
                .Select(classGroup => new
                {
                    // A .Key mindig azt a tulajdonságot jelenti ami alapján csoportosítottunk ( itt a .GroupBy(st => st.ClassName) )
                    Osztaly = classGroup.Key,
                    // Megnézi csoportonként, hogy hány darab eleme van az adott csoportnak:
                    TanuloSzam = classGroup.Count(),
                    // Átlagot számít csoportonként a tagok Average tulajdonsága (mezője) alapján:
                    OsztalyAtlag = classGroup.Average(st => st.Average)
                });

            foreach(var item in classAverages)
            {
                Console.WriteLine($"{item.Osztaly,4}: {item.TanuloSzam} fő, átlag: {item.OsztalyAtlag:F2}");
            }


            // Több feltételes szűrés:
            // Keressünk olyan tanulókat, akik legalább 16 évesek, legalább 3-as az átlaguk és nem a 12.C osztályba járnak.
            Console.WriteLine("\n:");
            Console.WriteLine("------------------------");
        }
    }
}
