using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuItem : MonoBehaviour
{

    public event Action<eBuildType> Selected;

    [SerializeField] private Button _selectedButton;
    [SerializeField] private TextMeshProUGUI _description;

    private eBuildType _buildType;

    // Start is called before the first frame update
    void Awake()
    {
        _selectedButton.onClick.AddListener(ClickItem);
    }

    public void InitItem(eBuildType buildType)
    {
        _buildType = buildType;
        _description.text = _buildType.ToString();
    }

    private void ClickItem()
    {
        Selected?.Invoke(_buildType);
    }
}
