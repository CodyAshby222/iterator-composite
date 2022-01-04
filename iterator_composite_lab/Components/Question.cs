using iterator_composite_lab.Interfaces;
using iterator_composite_lab.Iterators;
using System;
using System.Collections.Generic;

namespace iterator_composite_lab.Components
{
    public class Question : IComponent
    {
        string question;
        List<string> answers;
        string correctAnswer;
        public Question(string question, List<string> answers, string correctAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }
        
        public void Add(IComponent component)
        {
            throw new NotImplementedException();
        }

        public IIterator GetIterator()
        {
            return new QuestionIterator();
        }

        public string GetValue()
        {
            Console.WriteLine("\n\tQUESTION: " + this.question + "\n");
            foreach (string answer in this.answers)
            {
                Console.WriteLine("\t\t" + answer);
            }
            
            return correctAnswer;
        }

        public void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }

    }
}
