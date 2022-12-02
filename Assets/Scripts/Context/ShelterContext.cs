using Assets.Scripts.Buildings;
using Assets.Scripts.Characters;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Context
{
    public class ShelterContext : MonoInstaller
    {
        [Inject] private PrebuildConstruction PrebuildConstructionPrefab = null;
        [Inject] private AFacility FacilityPrefab = null;
        [Inject] private CharacterEntity CharacterEntity = null;

        [SerializeField] private Transform _buildings;
        [SerializeField] private Transform _characters;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShelterCharacters>().AsSingle();
            BindSignals();
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
            Container.BindFactory<CharacterEntity, CharacterEntity.Factory>().
                  FromComponentInNewPrefab(CharacterEntity).
                  UnderTransform(_characters);
        }

        private void BindSignals()
        {
            Container.DeclareSignal<SetCharacterToFacility>();
        }
    }
}
