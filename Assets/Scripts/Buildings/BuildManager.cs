using System.Collections.Generic;
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
        [Inject] private AFacility.Factory _facilityFactory;

        private PrebuildConstruction preBuild;
        private List<AFacility> facilities = new List<AFacility>();

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
       
        public void BuildConfirmed(FacilityData facilityData, GameObject construction)
        {
            AFacility facility = _facilityFactory.Create();
            facilityData.FacilityID = facility.GetInstanceID();
            facility.InitData(facilityData, construction);
            facilities.Add(facility);
            preBuild.Dispouse();
            preBuild = null;           
        }
    }
}
