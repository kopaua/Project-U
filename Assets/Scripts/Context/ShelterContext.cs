using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShelterContext : MonoInstaller
{
    [Inject]
    private PrebuildConstruction PrebuildConstructionPrefab = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BuildManager>().AsSingle();
        Container.BindFactory<PrebuildConstruction, PrebuildConstruction.Factory>().
              FromComponentInNewPrefab(PrebuildConstructionPrefab);
    }
}
