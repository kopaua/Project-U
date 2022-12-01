using Assets.Scripts.Grid;
using UnityEngine;
using Zenject;
using System;

namespace Assets.Scripts.Buildings
{
    [Serializable]
    public struct FacilityData
    {
        public eBuildType BuildType;
        public Cell.CellData CellData;
        public int CharacterID;
    }

    public abstract class AFacility : MonoBehaviour
    {

        [Inject] protected SignalBus _signalBus;

        protected GameObject _construction;
        protected FacilityData _facilityData;

        public virtual void InitData(FacilityData facilityData, GameObject construction)
        {
            _facilityData = facilityData;
        }

        public class Factory : PlaceholderFactory<AFacility>
        {
        }
    }
}