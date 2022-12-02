using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PanelCaller : MonoBehaviour
    {

        [Inject] private SignalBus _signalBus;

        [SerializeField] private ePanel _panel;

        private Button _button;

        // Use this for initialization
        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(CallPanel);
        }

        private void CallPanel()
        {
            _signalBus.Fire(new OpenPanelSignal { Panel = _panel });
        }
    }
}