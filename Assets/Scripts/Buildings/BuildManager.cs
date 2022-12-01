using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Buildings
{
    public class BuildManager
    {
        [Inject] private PlayerInput _playerInput;
        [Inject] private PrebuildConstruction.Factory _preConstructionFactory;        
        [Inject] private ConstructionInstaller.Construction[] _construction;

        private PrebuildConstruction preBuild;

        public void BuildingSelected(eBuildType buildType)
        {
            if (buildType == eBuildType.NONE) return;

            if (preBuild != null)
                preBuild.Dispouse();

            preBuild = _preConstructionFactory.Create();
            GameObject prefab = _construction.First(x => x.buildType == buildType).Prefab;
          
            preBuild.InitData(new FacilityData()
            {
                BuildType = buildType,               
            },
            prefab);
        }
       
        public void BuildConfirmed()
        {
            preBuild.Dispouse();
            preBuild = null;           
        }
    }
}
