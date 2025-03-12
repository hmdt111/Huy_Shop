namespace Do_An.Pattern
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    public interface ICollection<T>
    {
        IIterator<T> CreateIterator();
    }
}
