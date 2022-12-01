using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

namespace Assets.Scripts.UI
{
    public class UiManager : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        private List<BasePanel> _panels = new List<BasePanel>();

        private void Start()
        {
            _signalBus.Subscribe<OpenPanelSignal>(OnOpenPanel);
        }

        public void RegistrationPanel(BasePanel panel)
        {
            _panels.Add(panel);
            panel.ClosePanel();
        }

        public void OnOpenPanel(OpenPanelSignal signal)
        {         
            _panels.First(x => x.PanelType == signal.Panel).OpenPanel(signal.Data);
        }
    }    
}