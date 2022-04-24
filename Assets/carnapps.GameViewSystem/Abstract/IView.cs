namespace carnapps.GameViewSystem.Abstract
{
    public interface IView<in T> : IViewBase where T: IViewModel
    {
        void Initialize(T viewModel);
    }
}