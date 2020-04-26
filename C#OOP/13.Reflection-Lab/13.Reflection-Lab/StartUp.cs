
using System;
using System.Reflection;

namespace _13.Reflection_Lab
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //рефлекшан да анализираме собствения си код
            /*разликата между typeof() и GetType() e че първото работи диретно
             върху класа а второто работи върху истанция на класа.
             
             Рефлектиране на класове и членове
             най-лесния начин да достъпим някви дани е чрез TYPE
             
             
             
             Създаване директно 
             
             
             
             
             */

            //var type= typeof(Cat); //с името на класа
            // var catType = new Cat().GetType(); // директно инстанцирано 
            // var catTypeByName = Type.GetType("_13.Reflection_Lab.Cat");//
            // var properties = typeof(Cat).GetProperties();

            // foreach (var prop in properties)
            // {
            //     Console.WriteLine(prop.Name);
            // }

            //var type = typeof(Cat);
            //var cat = (Cat)Activator.CreateInstance(type,  "Ivan" ,5);
            //Console.WriteLine(cat.Name);
            //Console.WriteLine(cat.Age);


            var animalType = Console.ReadLine();

            var  animal =Activator.CreateInstance(animalType)



        }
    }
}
