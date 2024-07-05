using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Elements
{
    public class ProgressSaverButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
            _button.onClick.AddListener(SaveProgress);
        }

        private void SaveProgress() => 
            _saveLoadService.SaveProgress();
    }
}