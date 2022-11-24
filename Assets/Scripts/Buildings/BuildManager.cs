using System;
using UnityEngine;
using Zenject;

public class BuildManager : ITickable, IInitializable, IDisposable
{
    [Inject] private SignalBus _signalBus;

    public void Initialize()
    {
        _signalBus.Subscribe<MouseDown>(PLayerClick);
        _signalBus.Subscribe<MouseUp>(Cancel);
    }
    public void Dispose()
    {
        _signalBus.Unsubscribe<MouseDown>(PLayerClick);
        _signalBus.Unsubscribe<MouseUp>(Cancel);
    }

    public void Tick()
    {
        
    }

  
    private void PLayerClick()
    {
        Debug.Log("PLayerClick");
    }

    private void Cancel()
    {

    }

  
}
