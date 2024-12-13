using System;

namespace ShipLibrary
{
    public class Student : IInit, ICloneable
    {
        public string Name { get; set; }
        public int[] Grades { get; set; } 

        public Student()
        {
            Name = "Неизвестно";
            Grades = new int[5];
        }

        public Student(string name, int[] grades)
        {
            Name = name;
            Grades = grades;
        }

        public virtual void Init()
        {
            Name = "Стандартный студент";
            Grades = new int[] { 4, 4, 4, 4, 4 };
        }

        public void RandomInit()
        {
            Random rnd = new Random();
            string[] names = { "Иван", "Петр", "Анна", "Мария", "Александр" };
            
            Name = names[rnd.Next(names.Length)];
            Grades = new int[5];
            for (int i = 0; i < Grades.Length; i++)
            {
                Grades[i] = rnd.Next(2, 6);
            }
        }

        public Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }

        public Student DeepCopy()
        {
            Student copy = (Student)this.MemberwiseClone();
            copy.Grades = new int[this.Grades.Length];
            Array.Copy(this.Grades, copy.Grades, this.Grades.Length);
            return copy;
        }

        public object Clone()
        {
            return DeepCopy();
        }

        public void Show()
        {
            Console.WriteLine($"Студент: {Name}");
            Console.Write("Оценки: ");
            foreach (int grade in Grades)
            {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Студент: {Name}, Оценки: {string.Join(", ", Grades)}";
        }
    }
}
