using iterator_composite_lab.Interfaces;
using iterator_composite_lab.Iterators;
using System.Collections.Generic;

namespace iterator_composite_lab.Components
{
    public class Category : IComponent
    {
        public List<IComponent> Children = new List<IComponent>();
        string title;
        public Category(string title)
        {
            this.title = title;
        }
        public void Add(IComponent component)
        {
            this.Children.Add(component);
        }

        public IIterator GetIterator()
        {
            return new CategoryIterator(this);
        }

        public string GetValue()
        {
            return title;
        }

        public void Remove(IComponent component)
        {
            this.Children.Remove(component);
        }
    }
}
