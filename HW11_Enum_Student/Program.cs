using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_Enum_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            //public Student(string fullName, Sex sex, string group, double avgMark, 
            //double IncomePerFamMem, FamilyCategory FamilyCategory, Sex Sex, StudyType StudyType)
            Student s1 = new Student("Stalin Stas", Sex.male, "it-01", 10.5, 25000, FamilyCategory.full, StudyType.fullTime);
            Student s2 = new Student("Kury Maria", Sex.female, "it-02", 9.5, 35000, FamilyCategory.notFull, StudyType.partTime);
            Student s3 = new Student("Maslov Lenin", Sex.male, "it-03", 12, 35000, FamilyCategory.full, StudyType.fullTime);
            Student s4 = new Student("Castro Fidel", Sex.male, "it-04", 13, 15000, FamilyCategory.notFull, StudyType.fullTime);
            Student s5 = new Student("Jobs Steve", Sex.male, "it-02", 8.5, 40000, FamilyCategory.full, StudyType.fullTime);
            Student s6 = new Student("Nazarbaeva Dariga", Sex.female, "it-02", 11.5, 50000, FamilyCategory.full, StudyType.partTime);
            Student s7 = new Student("Putina Lena", Sex.female, "it-05", 7, 55000, FamilyCategory.full, StudyType.fullTime);
            Student s8 = new Student("Gorbachev Ivan", Sex.male, "it-04", 11.5, 50000, FamilyCategory.notFull, StudyType.partTime);
            Student s9 = new Student("Musabaev Talgat", Sex.male, "it-06", 9, 20000, FamilyCategory.full, StudyType.fullTime);
            Student s10 = new Student("Ghandi Indira", Sex.female, "it-01", 8.5, 16000, FamilyCategory.full, StudyType.fullTime);

            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);
            //Общежитие в первую очередь предоставляется тем, у кого доход на члена семьи меньше двух минимальных зарплат, 
            //затем остальным в порядке уменьшения среднего балла. Отобразить данный список.

            var studentsByIncome = students.Where(s => s.IncomePerFamMem < (15000 * 2)).OrderBy(s => s.IncomePerFamMem);
            var studentsByAvgMark = students.Where(s => s.IncomePerFamMem >= (15000 * 2)).OrderByDescending(s => s.AvgMark);

            Console.WriteLine("Список студентов у кого доход на члена семьи меньше двух минимальных зарплат: ");
            foreach (var student in studentsByIncome)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("Список студентов в порядке уменьшения среднего балла: ");
            foreach (var student in studentsByAvgMark)
            {
                Console.WriteLine(student.ToString());
            }
            //Вывести список очередности предоставления мест в общежитии. 
            //При этом первые 3 мест выделить зеленым цветом, вторые 3 оранжевым, остальные красным.
            //var studentsByOrder = students.OrderByDescending(s => s.AvgMark).OrderBy(s => s.IncomePerFamMem);
            Console.WriteLine("Список студентов в порядке очередности: ");
            List<Student> Orderedstudents = new List<Student>();

            foreach (var student in studentsByIncome)
            {
                Orderedstudents.Add(student);
            }
            foreach (var student in studentsByAvgMark)
            {
                Orderedstudents.Add(student);
            }
            for (int i = 0; i < Orderedstudents.Count; i++)
            {
                if (i < 3)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (i >= 3 && i < 6)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Orderedstudents[i].ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
            //3.Вывести список студентов, у которых не полная семья.
            Console.WriteLine("Cписок студентов, у которых не полная семья: ");
            var stNotFullFamily = students.Where(s => s.FamilyCategory == FamilyCategory.notFull);
            foreach (var st in stNotFullFamily)
            {
                Console.WriteLine(st.ToString());
            }
            //4.Вывести 5 студентов, отличников с самым высоким баллом.
            var stHighMark = students.OrderByDescending(s => s.AvgMark).ToList();
            Console.WriteLine();
            Console.WriteLine("Cписок 5 студентов, отличников с самым высоким баллом: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stHighMark[i].ToString());
            }
            //5.Вывести 5 студентов, отличников с самым низким баллом.
            var stLowMark = students.OrderBy(s => s.AvgMark).ToList();
            Console.WriteLine();
            Console.WriteLine("Cписок 5 студентов, с самым низким баллом: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stLowMark[i].ToString());
            }
            //6.Вывести 3 студентов, с самым низким доходом семьи, а та у которых неполноценная семья
            Console.WriteLine();
            Console.WriteLine("Cписок 3 студентов, с самым низким доходом семьи, а та у которых неполноценная семья: ");
            var stLowIncome = students.Where(s=>s.FamilyCategory==FamilyCategory.notFull).OrderBy(s=>s.IncomePerFamMem).ToList();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(stLowIncome[i].ToString());
            }

        }
    }
}
