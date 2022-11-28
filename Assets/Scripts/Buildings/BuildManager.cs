using System.Linq;
using UnityEngine;
using Zenject;

public class BuildManager
{
    [Inject] private PlayerInput _playerInput;
    [Inject] private PrebuildConstruction.Factory _constructionFactory;
    [Inject] private ConstructionInstaller.Construction[] _construction;

    private PrebuildConstruction preBuild;

    public void BuildingSelected(eBuildType buildType)
    {
        if (buildType == eBuildType.NONE) return;

        if (preBuild != null)
            preBuild.Dispouse();

        preBuild = _constructionFactory.Create();
        GameObject prefab = _construction.First(x => x.buildType == buildType).Prefab;
        preBuild.Init(buildType, prefab);
    }  

    public void BuildConfirmed()
    {
        preBuild = null;
    }
}
