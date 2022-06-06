using eShop.UseCases.CustomerPortal.PluginInterfaces.StateStore;

namespace eShop.StateStore.DI;

public class StateStoreBase : IStateStore
{
    private Action _listeners;

    public void AddStateChangeListener(Action listener)
    => _listeners += listener;

    public void RemoveStateChangeListener(Action listener)
    => _listeners -= listener;

    public void BroadCastState()
    {
        if (_listeners != null)
            _listeners.Invoke();
    }
}
