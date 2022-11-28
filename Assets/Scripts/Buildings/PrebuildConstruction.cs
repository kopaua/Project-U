using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PrebuildConstruction : MonoBehaviour
{
    [Inject] private PlayerInput _playerInput;
    [Inject] private BuildManager _buildManager;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;   

    private eBuildType _eBuildType;
    private bool _isPlaced;

    private void OnEnable()
    {
        _playerInput.OnMouseUp += Placed;
        _buttonYes.onClick.AddListener(Confirm);
        _buttonNo.onClick.AddListener(Dispouse);
        _canvas.SetActive(false);
    }

    private void OnDisable()
    {
        _playerInput.OnMouseUp -= Placed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isPlaced)
            transform.position = _playerInput.RaycastFromCamera();
    }

    public void Init(eBuildType eBuildType, GameObject prefab)
    {
        _eBuildType = eBuildType;
        Instantiate(prefab, transform);
    }

    public void Dispouse()
    {
        Destroy(gameObject);
    }

    private void Confirm()
    {
        Debug.Log("Confirm");
        _canvas.SetActive(false);
        _buildManager.BuildConfirmed();
    }   

    private void Placed()
    {
        if (_isPlaced) return;

        _playerInput.OnMouseUp -= Placed;
        _isPlaced = true;
        _canvas.SetActive(true);
    }

    public class Factory : PlaceholderFactory<PrebuildConstruction>
    {
    }
}   
