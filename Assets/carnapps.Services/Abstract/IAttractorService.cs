namespace carnapps.Services.Abstract
{
    public interface IAttractorService : IService
    {
        void Attract(IAttractable target);
    }
}