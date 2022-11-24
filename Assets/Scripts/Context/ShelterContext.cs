using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShelterContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BuildManager>().AsSingle();        
    }
}
