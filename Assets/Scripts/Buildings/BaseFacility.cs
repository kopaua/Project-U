using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class BaseFacility : AFacility
    {

        public override void InitData(FacilityData facilityData, GameObject construction)
        {
            base.InitData(facilityData, construction);
            _construction = construction;
            AddConstruction();
            AddFunctional();
        }

        private void OnMouseDown()
        {
            _signalBus.Fire(
                new OpenPanelSignal()
                {
                    Panel = ePanel.FacilityPanel,
                    Data = _facilityData
                });
        }

        private void AddFunctional()
        {
            gameObject.AddComponent<FacilityStaff>();
        }

        private void AddConstruction()
        {
            gameObject.name = "Facility/" + _facilityData.BuildType;
            transform.position = _construction.transform.position;
            _construction.transform.SetParent(transform);
        }
    }
}
