namespace Do_An.Pattern
{
    public interface IMediator
    {
        void Notify(object sender, string ev, object data = null);
    }
}
