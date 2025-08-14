using DG.Tweening;
using UI.CommonViews;

namespace UI.Core
{
    public interface IShowableView : IView
    {
        Tween Hide();

        Tween Show();
    }
}
