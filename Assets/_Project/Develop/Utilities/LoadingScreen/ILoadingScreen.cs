namespace Utilities.LoadingScreen
{
    public interface ILoadingScreen
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}