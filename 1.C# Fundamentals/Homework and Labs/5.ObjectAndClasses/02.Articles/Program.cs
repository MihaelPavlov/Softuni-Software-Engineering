using System;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] read = Console.ReadLine()
                .Split(", ")
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            
            
            Article article = new Article();
            
            article.Edit(read[1]);
            article.ChangeAuthor(read[2]);
            article.Rename(read[0]);


            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0]=="ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
              

            }
            Console.WriteLine(article.ToString());
            
            
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
           Content= newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename (string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

