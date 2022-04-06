namespace carnapps.Context.Abstract
{
    public interface IContext
    {
        void Publish<T>(T obj) where T : class;
        T Get<T>() where T : class;
    }
}