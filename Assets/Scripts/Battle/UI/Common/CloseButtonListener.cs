using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI.Common
{
    public class CloseButtonListener : MonoBehaviour
    { 
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Close);
        }

        private void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}
