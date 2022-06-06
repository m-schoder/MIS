namespace MIS.Frontend.App.Factories.Interfaces
{
    public interface IViewModelFactory
    {
        TViewModel Get<TViewModel>();
    }
}