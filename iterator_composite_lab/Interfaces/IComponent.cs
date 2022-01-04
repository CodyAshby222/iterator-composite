namespace iterator_composite_lab.Interfaces
{
    public interface IComponent
    {
        public IIterator GetIterator();
        public void Add(IComponent component);
        public void Remove(IComponent component);
        public string GetValue();
    }
}
