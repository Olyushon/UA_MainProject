using System;
using Infrastructure.DI;

namespace UI.Core
{
    public interface IPresenter : IInitializable, IDisposable
    {
    }
}