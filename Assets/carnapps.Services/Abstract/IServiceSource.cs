namespace carnapps.Services.Abstract
{
    using carnapps.Context.Abstract;
    
    public interface IServiceSource
    {
        IService CreateService(IContext context);
    }
}