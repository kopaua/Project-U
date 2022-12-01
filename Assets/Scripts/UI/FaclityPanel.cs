using Assets.Scripts.Buildings;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class FaclityPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI _name;
        
        private FacilityData _facilityData;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OpenPanel(object data)
        {
            base.OpenPanel(data);
            _facilityData = (FacilityData)data;
            _name.text = _facilityData.BuildType.ToString();
        }
    }
}