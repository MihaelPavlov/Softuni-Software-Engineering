using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab._05.Studetns
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Students> student = new List<Students>();
            List<string> input = Console.ReadLine().Split(" ").ToList();

            while (input[0] !="end")
            {
                // Първо си отелям инпута в отделни променливи 
                string firstName = input[0];
                string lastNmae = input[1];
                string age = input[2];
                string city = input[3];
                //правя си нов клас в който да добавям тези променливи 
                Students newStudent = new Students();

                newStudent.FirstName = firstName;
                newStudent.LastName = lastNmae;
                newStudent.Age = age;
                newStudent.City = city;
                //и тук добавям класа в листа 
                student.Add(newStudent);


                input = Console.ReadLine().Split(" ").ToList();

             }
            string cityForOutput = Console.ReadLine();

            //for (int i = 0; i < student.Count; i++)
            //{
            //    if (student[i].City == cityForOutput)
            //    {

            //    }
            //}

            student = student.Where(x => x.City == cityForOutput).ToList();
            foreach (var stud in student)
            {
                Console.WriteLine(stud.ToString());
            }

        }
    }
    class Students
    {
        //public Students( )
        //{
        //    FirstName = FirstName;
        //}


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return  $"{FirstName} {LastName} is {Age} years old";
        }
    }
}
