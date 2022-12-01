using Assets.Scripts.Grid;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Buildings
{
    public class PrebuildConstruction : AFacility
    {
        [Inject] private PlayerInput _playerInput;
        [Inject] private BuildManager _buildManager;
        [Inject] private AFacility.Factory _facilityFactory;

        [SerializeField] private GameObject _canvas;
        [SerializeField] private Button _buttonYes;
        [SerializeField] private Button _buttonNo;
        [SerializeField] private Color _errorColor;

        private bool _isPlaced;
        private MeshRenderer _meshRenderer;
        private Color _baseColor;
        private Cell _cell;

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
            {
                RaycastHit raycastHit = _playerInput.RaycastFromCamera();
              
                if (raycastHit.transform == null) return;

                if (raycastHit.transform != null && raycastHit.transform.TryGetComponent<Cell>(out _cell))
                {
                    if (!_cell.HasConstruction)
                    {
                        transform.position = _cell.transform.position;
                        _meshRenderer.material.SetColor("_Color", _baseColor);
                        return;
                    }
                }
                _cell = null;
                transform.position = raycastHit.point;
                _meshRenderer.material.SetColor("_Color", _errorColor);
            }
        }
      
        public override void InitData(FacilityData facilityData, GameObject construction)
        {
            base.InitData(facilityData, construction);
            _construction = Instantiate(construction, transform);
            _meshRenderer = _construction.GetComponent<MeshRenderer>();
            _baseColor = _meshRenderer.material.color;
        }

        public void Dispouse()
        {
            Destroy(gameObject);
        }

        private void Confirm()
        {
            _canvas.SetActive(false);                           
            _baseColor.a = 1;
            _meshRenderer.material.SetColor("_Color", _baseColor);
            _facilityData.CellData = _cell.GetCellData;          
            AFacility facility = _facilityFactory.Create();
            facility.InitData(_facilityData, _construction);
            _cell.SetConstruction(true);
            _buildManager.BuildConfirmed();
        }

        private void Placed()
        {
            if (_cell == null || _cell.HasConstruction)
            {
                Dispouse();
                return;
            }
            if (_isPlaced) return;

            _playerInput.OnMouseUp -= Placed;
            _isPlaced = true;
            _canvas.SetActive(true);
        }

        public class Factory : PlaceholderFactory<PrebuildConstruction>
        {
        }
    }
}
