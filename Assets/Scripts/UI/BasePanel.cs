using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] private ePanel _panelType;

        public ePanel PanelType => _panelType;
        
        private void Awake()
        {
            if (_panelType == ePanel.None)
            {
                throw new System.Exception("Base panel with type : NONE");
            }
            transform.GetComponentInParent<UiManager>().RegistrationPanel(this);           
        }

        public virtual void OpenPanel(object data)
        {
            gameObject.SetActive(true);
        }

        public virtual void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}