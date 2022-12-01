using UnityEngine;
using Zenject;
using System;
using Assets.Scripts.Buildings;

[CreateAssetMenu(fileName = "ConstructionInstaller", menuName = "Installers/ConstructionInstaller")]
public class ConstructionInstaller : ScriptableObjectInstaller<ConstructionInstaller>
{

    [SerializeField] public PrebuildConstruction PrebuildPrefab;
    [SerializeField] public AFacility FacilityPrefab;
    [SerializeField] public Construction[] Constructions;

    [Serializable]
    public class Construction
    {
        public eBuildType buildType;        
        public GameObject Prefab;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(PrebuildPrefab);
        Container.BindInstance(FacilityPrefab);
        Container.BindInstance(Constructions);
    }    
}