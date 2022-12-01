using Assets.Scripts.Buildings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Context
{
    public class ShelterContext : MonoInstaller
    {
        [Inject] private PrebuildConstruction PrebuildConstructionPrefab = null;
        [Inject] private AFacility FacilityPrefab = null;

        [SerializeField] private Transform _buildings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildManager>().AsSingle();
            BindFactory();
        }

        private void BindFactory()
        {
            Container.BindFactory<PrebuildConstruction, PrebuildConstruction.Factory>().
                 FromComponentInNewPrefab(PrebuildConstructionPrefab).
                 UnderTransform(_buildings);
            Container.BindFactory<AFacility, AFacility.Factory>().
                  FromComponentInNewPrefab(FacilityPrefab).
                  UnderTransform(_buildings);
        }
    }
}
