using System;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListener(Action listener);
        void RemoveStateChangeListener(Action listener);
        void BroadCastState();
    }
}
