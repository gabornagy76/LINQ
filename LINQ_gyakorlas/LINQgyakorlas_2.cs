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

            foreach (var item in classAverages)
            {
                Console.WriteLine($"{item.Osztaly,4}: {item.TanuloSzam} fő, átlag: {item.OsztalyAtlag:F2}");
            }


            // Több feltételes szűrés:
            // Keressünk olyan tanulókat, akik legalább 16 évesek, legalább 3-as az átlaguk és nem a 12.C osztályba járnak.
            Console.WriteLine("\n:Tanulók, akik legalább 16 évesek, legalább 3-as az átlaguk és nem a 12.C osztályba járnak");
            Console.WriteLine("------------------------");
            IEnumerable<Student> selectedStudents_2 = students
                .Where(st =>
                st.Age >= 16
                &&
                st.Average >= 3
                &&
                st.ClassName != "12.C");

            foreach (Student item in selectedStudents_2)
            {
                Console.WriteLine($"{item.Name,-18} - {item.Age,2} éves - {item.Average,-4} - {item.ClassName,4}");
            }


            // Összett feltételt
            // Keressük azokat, akik VAGY a 10.A osztályba járnak VAGY legalább 4,5 az átlaguk ÉS legalább 16 évesek.
            Console.WriteLine("\n:Tanulók, akik VAGY a 10.A osztályba járnak VAGY legalább 4,5 az átlaguk ÉS legalább 16 évesek");
            Console.WriteLine("------------------------");

            IEnumerable<Student> selectedStudents_3 = students
                .Where(st =>
                (
                st.ClassName == "10.A"
                ||
                st.Average >= 4.5
                )
                &&
                st.Age >= 16
                );

            foreach (Student item in selectedStudents_3)
            {
                Console.WriteLine($"{item.Name,-18} - {item.Average,4} - {item.Age,2} - {item.ClassName,4}");
            }


            // Szűrés és többszintű rendezés
            // Szűrjük ki a legalább 3-as átlagú tanulókat, madj rendezzük őket osztály szerint, azon belül átlag szerint csökkenően, azonos átlag esetén pedig név szerint növekvően.
            Console.WriteLine("\nSzűrés és rendezés");
            Console.WriteLine("------------------------");
            IEnumerable<Student> orderedStudents = students
                .Where(st => st.Average >= 3)
                .OrderBy(st => st.ClassName)
                .ThenByDescending(st => st.Average)
                .ThenBy(st => st.Name);

            foreach (Student item in orderedStudents)
            {
                Console.WriteLine(
                    $"{item.Name,-18} - " +
                    $"{item.ClassName,-5} - " +
                    $"{item.Average,-4}"
                    );
            }


            // Számított mező Select kategóriákkal.
            // Minden tanuló mellé írjuk ki a szöveges értékelését is.
            Console.WriteLine("\nSzöveges értékelés");
            Console.WriteLine("------------------------");

            var studentResult = students
                .Select(st => new
                {
                    TanuloNev = st.Name,
                    TanuloAtlag = st.Average,

                    Kategoria = st.Average >= 4.6 ? "Kiváló" :
                                st.Average >= 3.6 ? "Jó" :
                                st.Average >= 2.6 ? "Közepes" :
                                st.Average >= 1.6 ? "Elégséges" : "Elégtelen"
                });

            foreach (var item in studentResult)
            {
                Console.WriteLine(
                    $"{item.TanuloNev,-18} - " +
                    $"{item.TanuloAtlag,-4:F2} - " +
                    $"{item.Kategoria}"
                    );    
            }
        }
    }
}
