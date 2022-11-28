using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildMenuItem : MonoBehaviour, IPointerDownHandler
{

    public event Action<eBuildType> Selected;

    [SerializeField] private TextMeshProUGUI _description;

    private eBuildType _buildType;    

    public void InitItem(eBuildType buildType)
    {
        _buildType = buildType;
        _description.text = _buildType.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickItem();
    }

    private void ClickItem()
    {
        Selected?.Invoke(_buildType);
    }    
}
