using iterator_composite_lab.Interfaces;

namespace iterator_composite_lab.Iterators
{
    public class QuestionIterator : IIterator
    {
        public bool HasNext()
        {
            return false;
        }

        public IComponent Next()
        {
            return null;
        }
    }
}
