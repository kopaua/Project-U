using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildMenuPanel : MonoBehaviour
{
    [Inject] private BuildManager _buildManager;

    [SerializeField] private Button _buildButton;
    [SerializeField] private BuildMenuItem _buildItemPrefab;
    [SerializeField] private GameObject _buildPanel;
    [SerializeField] private GameObject _content;

    private void Awake()
    {
        CreateContent();
        _buildItemPrefab.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateContent(false);
        _buildButton.onClick.AddListener(() => ActivateContent(true));
    }

    private void ActivateContent(bool value)
    {
        _buildButton.gameObject.SetActive(!value);
        _buildPanel.SetActive(value);
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
        ActivateContent(false);
        _buildManager.BuildingSelected(buildType);
    }
}
