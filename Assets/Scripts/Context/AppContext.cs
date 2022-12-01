using Assets.Scripts.Characters;
using Zenject;

namespace Assets.Scripts.Context
{
    public class AppContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharactersHolder>().AsSingle().NonLazy();
            InstallSignals();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OpenPanelSignal>();
            //  Container.DeclareSignal<MouseDown>();
        }
    }
}
