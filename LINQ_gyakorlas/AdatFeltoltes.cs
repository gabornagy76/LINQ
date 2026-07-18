using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LINQ_gyakorlas
{
    internal class AdatFeltoltes
    {

        public static List<Student> GetStudents()
        {

            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Kovács Anna",
                    Age = 16,
                    ClassName = "10.A",
                    Average = 4.85
                },

                new Student
                {
                    Id = 2,
                    Name = "Nagy Péter",
                    Age = 17,
                    ClassName = "11.B",
                    Average = 3.29
                },

                new Student
                {
                    Id = 3,
                    Name = "Szabó Éva",
                    Age = 16,
                    ClassName = "10.A",
                    Average = 4.85
                },

                new Student
                {
                    Id = 4,
                    Name = "Tóth Gábor",
                    Age = 18,
                    ClassName = "12.C",
                    Average = 2.9
                },
                new Student
                {
                    Id = 5,
                    Name = "Kiss Dániel",
                    Age = 17,
                    ClassName = "11.B",
                    Average = 3.93
                },
                new Student
                {
                    Id = 6,
                    Name = "Varga Júlia",
                    Age = 18,
                    ClassName = "12.C",
                    Average = 3.2
                },
                new Student
                {
                    Id = 7,
                    Name = "Kovács Árpád",
                    Age = 15,
                    ClassName = "9.A",
                    Average = 4.63
                },
                new Student
                {
                    Id = 8,
                    Name = "Nagy Bence",
                    Age = 16,
                    ClassName = "10.B",
                    Average = 3.89
                },
                new Student
                {
                    Id = 9,
                    Name = "Szabó Csilla",
                    Age = 15,
                    ClassName = "9.A",
                    Average = 3.9
                },
                new Student
                {
                    Id = 10,
                    Name = "Tóth Dávid",
                    Age = 17,
                    ClassName = "11.C",
                    Average = 2.88
                },
                new Student
                {
                    Id = 11,
                    Name = "Varga Eszter",
                    Age = 16,
                    ClassName = "10.B",
                    Average = 4.27
                },
                new Student
                {
                    Id = 12,
                    Name = "Kiss Ferenc",
                    Age = 18,
                    ClassName = "12.A",
                    Average = 3.44
                },
                new Student
                {
                    Id = 13,
                    Name = "Molnár Gréta",
                    Age = 17,
                    ClassName = "11.C",
                    Average = 4.22
                },
                new Student
                {
                    Id = 14,
                    Name = "Balogh Hunor",
                    Age = 15,
                    ClassName = "9.B",
                    Average = 2.44
                },
                new Student
                {
                    Id = 15,
                    Name = "Farkas Izabella",
                    Age = 18,
                    ClassName = "12.A",
                    Average = 4.43
                }

            };

            return students;

        }

    }
}
