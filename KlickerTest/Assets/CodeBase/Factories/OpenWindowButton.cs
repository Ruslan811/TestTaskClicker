using CodeBase.Services;
using CodeBase.Services.UI;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.UI;


namespace CodeBase.Elements
{
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WindowId _windowId;
        private IWindowService _windowService;

        public void Init() =>
          _windowService = AllServices.Container.Single<IWindowService>();

        private void Awake() =>
          _button.onClick.AddListener(Open);

        private void Open()
        {
            Init();
            _windowService.Open(_windowId);
        }
    }
}
