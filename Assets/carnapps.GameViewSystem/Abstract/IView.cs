using Cysharp.Threading.Tasks;

namespace carnapps.GameViewSystem.Abstract
{
    public interface IView<in T> : IViewBase where T : IViewModel
    {
        UniTask Initialize(T viewModel);
    }
}