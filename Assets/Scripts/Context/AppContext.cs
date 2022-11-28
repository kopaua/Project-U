using UnityEngine;
using Zenject;

public class AppContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle().NonLazy();
        InstallSignals();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);
      //  Container.DeclareSignal<MouseDown>();
    }
}
