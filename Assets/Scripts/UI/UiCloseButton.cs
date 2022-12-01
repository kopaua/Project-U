using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UiCloseButton : MonoBehaviour
    {
        private BasePanel _panel;

        // Use this for initialization
        void Awake()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(ClosePanel);
            _panel = transform.GetComponentInParent<BasePanel>();
        }

        private void ClosePanel()
        {
            _panel.ClosePanel();
        }
    }
}