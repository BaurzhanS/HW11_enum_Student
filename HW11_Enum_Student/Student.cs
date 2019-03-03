using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_Enum_Student
{
    public enum FamilyCategory { full,notFull}
    public enum Sex { male, female }
    public enum StudyType { fullTime, partTime }

    public class Student
    {
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public string Group { get; set; }
        public double AvgMark { get; set; }
        public double IncomePerFamMem { get; set; }
        public FamilyCategory FamilyCategory { get; set; }
        public StudyType StudyType { get; set; }

        public Student() { }
        public Student(string fullName, Sex sex, string group, double avgMark, 
            double IncomePerFamMem, FamilyCategory FamilyCategory, StudyType StudyType)
        {
            this.FullName = fullName;
            this.Sex = sex;
            this.Group = group;
            this.AvgMark = avgMark;
            this.IncomePerFamMem = IncomePerFamMem;
            this.FamilyCategory = FamilyCategory;
            this.StudyType = StudyType;
        }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", FullName, Sex, Group, AvgMark, IncomePerFamMem,
                FamilyCategory, StudyType);
        }
    }

    //public class Hostel
    //{
    //    List<Student> students = new List<Student>();
    //}
}
