using UnityEngine;
using Zenject;

public class AppContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        Container.Bind<PlayerInput>().AsSingle();
        InstallSignals();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<MouseDown>();
        Container.DeclareSignal<MouseUp>();

    }

    public override void Start()
    {
        base.Start();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
