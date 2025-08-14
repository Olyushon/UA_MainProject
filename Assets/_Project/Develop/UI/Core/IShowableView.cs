using UI.CommonViews;

namespace UI.Core
{
    public interface IShowableView : IView
    {
        void Hide();

        void Show();
    }
}
