using Assets.Scripts.Buildings;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class BuildMenuPanel : BasePanel
    {
        [Inject] private BuildManager _buildManager;        

        [SerializeField] private BuildMenuItem _buildItemPrefab;
        [SerializeField] private GameObject _content;


        // Start is called before the first frame update
        void Start()
        {
            CreateContent();
            _buildItemPrefab.gameObject.SetActive(false);
        }

        private void CreateContent()
        {
            int count = Enum.GetValues(typeof(eBuildType)).Length;
            for (int i = 1; i < count; i++)
            {
                BuildMenuItem clone = Instantiate(_buildItemPrefab, _content.transform);
                clone.InitItem((eBuildType)i);
                clone.Selected += BuildItemSelected;
            }
        }

        private void BuildItemSelected(eBuildType buildType)
        {           
            _buildManager.BuildingSelected(buildType);
            ClosePanel();
        }       
    }
}
