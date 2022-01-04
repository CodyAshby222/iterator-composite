using iterator_composite_lab.Components;
using iterator_composite_lab.Interfaces;
using System;

namespace iterator_composite_lab.Iterators
{
    public class CategoryIterator : IIterator
    {
        Category category;
        int i;
        IIterator currentIteration;

        public CategoryIterator(Category category)
        {
            this.category = category;
            this.currentIteration = this.category.Children[0].GetIterator();
        }
        public bool HasNext()
        {
            return this.i < this.category.Children.Count;
        }

        public IComponent Next()
        {
            if (this.currentIteration.HasNext())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(category.GetValue());
                Console.ResetColor();
                IComponent question = this.currentIteration.Next();

                if (!this.currentIteration.HasNext())
                {
                    
                    this.i++;
                    if (HasNext())
                    {
                        this.currentIteration = this.category.Children[this.i].GetIterator();
                    }
                }
                return question;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(category.GetValue());
                Console.ResetColor();
                IComponent question = this.category.Children[this.i++];
                if (HasNext())
                {
                    this.currentIteration = this.category.Children[this.i].GetIterator();
                }
                return question;
            }
        }
    }
}
