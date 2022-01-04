using iterator_composite_lab.Components;
using iterator_composite_lab.Interfaces;
using System;
using System.Collections.Generic;

namespace iterator_composite_lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            QuizView(QuizGenerator());
        }

        public static IIterator QuizGenerator()
        {
            IComponent mainQuiz = new Category("");

            IComponent warnerCategory = new Category("CATEGORY: Warner Bros.");
            IComponent disneyCategory = new Category("CATEGORY: Walt Disney");

            IComponent harryPotterCategory = new Category("Harry Potter Movies");
            IComponent marvelCategory = new Category("Marvel Movies");
            IComponent starWarsCategory = new Category("Star Wars Movies");
            IComponent dcCategory = new Category("DC Movies");

            IComponent harryQuestionOne = new Question("What were the names of Harry Potter's two best friends?", new List<string> { "1) Ron & Hermione", "2) Neville & Lavender", "3) Seamus & Parvati", "4) Dean & Luna" }, "1");
            IComponent harryQuestionTwo = new Question("Which wizarding school does Harry attend?", new List<string> { "1) Beauxbatons", "2) Durmstrang", "3) Castelobruxo", "4) Hogwarts" }, "4");
            IComponent marvelQuestionOne = new Question("How many Infinity Stones are there?", new List<string> { "1) Five", "2) Six", "3) Three", "4) Eight" }, "2");
            IComponent marvelQuestionTwo = new Question("What's Tony Stark's hero name?", new List<string> { "1) Black Panther", "2) The Hulk" , "3) Iron Man", "4) Spider-Man" }, "3");
            IComponent starWarsQuestionOne = new Question("Which order brought about the death of the Jedi", new List<string> { "1) Order 55", "2) Order 66", "3) Order 77", "4) Order 88" }, "2");
            IComponent starWarsQuestionTwo = new Question("What is Kylo Ren's real name?", new List<string> { "1) Ben Solo", "2) Tom Solo", "3) Rick Solo", "4) Frank Solo" }, "1");
            IComponent dcQuestionOne = new Question("What is Batman's real name?", new List<string> { "1) Bob Wayne", "2) Bruce Banner", "3) Bruce Wayne", "4) Bob Banner" }, "3");
            IComponent dcQuestionTwo = new Question("Batman protects which city?", new List<string> { "1) Keystone City", "2) Gotham City", "3) Kryptonopolis", "4) Midway City" }, "2");

            mainQuiz.Add(warnerCategory);
            mainQuiz.Add(disneyCategory);

            disneyCategory.Add(marvelCategory);
            disneyCategory.Add(starWarsCategory);
            warnerCategory.Add(harryPotterCategory);
            warnerCategory.Add(dcCategory);

            marvelCategory.Add(marvelQuestionOne);
            marvelCategory.Add(marvelQuestionTwo);
            harryPotterCategory.Add(harryQuestionOne);
            harryPotterCategory.Add(harryQuestionTwo);
            starWarsCategory.Add(starWarsQuestionOne);
            starWarsCategory.Add(starWarsQuestionTwo);
            dcCategory.Add(dcQuestionOne);
            dcCategory.Add(dcQuestionTwo);

            return mainQuiz.GetIterator();
        }

        public static void QuizView(IIterator quizIterator)
        {
            QuizIntro();
            int score = 0;
            int totalQuestions = 0;

            while (quizIterator.HasNext())
            {
                IComponent category = quizIterator.Next();
                string correctAnswer = category.GetValue();
                string inputAnswer = Console.ReadLine();
                totalQuestions++;
                if (correctAnswer == inputAnswer)
                {
                    score++;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nCorrect!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nIncorrect.");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Score: " + score.ToString() + "/" + totalQuestions.ToString());
                Console.ResetColor();
            }

            QuizOutro(score, totalQuestions);
        }

        public static void QuizIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWELCOME TO THE MOVIE QUIZ!\n");
            Console.WriteLine("Instructions:   You are given a category to which each has movie series with questions regarding those movie series.");
            Console.WriteLine("\t\tBe sure to enter 1-4 to guess correct answer. Any other input will automatically be incorrect.");
            Console.WriteLine("\t\tGOOD LUCK!\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public static void QuizOutro(int score, int totalQuestions)
        {
            double percentage = (double)score / totalQuestions;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\nFINAL SCORE: " + score.ToString() + "/" + totalQuestions.ToString() + "\n");
            Console.WriteLine("PERCENTAGE: " + string.Format("{0:0.0%}", percentage) + "\n");
            Console.WriteLine("Thank you for playing!\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ResetColor();
        }    
    }
}
