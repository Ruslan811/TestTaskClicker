using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Windows
{
    public class RewardedAdItem : MonoBehaviour
    {
        [SerializeField] private int _price;
        [SerializeField] private int _upgradeAmount;

        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private GameObject[] AdActiveObjects;
        [SerializeField] private GameObject[] AdInactiveObjects;

        private IPersistentProgressService _progressService;

        public void Construct(IPersistentProgressService progresService) =>
            _progressService = progresService;

        public void Initialize()
        {
            RefreshText();
            _buyButton.onClick.AddListener(BuyUpgrade);
        }

        private void Awake()
        {
            RefreshText();
            _buyButton.onClick.AddListener(BuyUpgrade);
        }

        private void BuyUpgrade()
        {
            if (_price > 0 && _upgradeAmount > 0)
            {
                if (_progressService.Progress.Money.Value >= _price)
                {
                    _progressService.Progress.Money.Value -= _price;
                    _progressService.Progress.Money.AddAmount += _upgradeAmount;
                    RefreshAvailableAd();
                }
            }
        }

        private void RefreshText() =>
            _text.text = _price.ToString();

        private void RefreshAvailableAd()
        {
            CheckActiveObjects(false, AdActiveObjects);

            CheckActiveObjects(true, AdInactiveObjects);
        }

        private void CheckActiveObjects(bool isActive, GameObject[] objects)
        {
            foreach (GameObject adActiveObject in objects)
                adActiveObject.SetActive(isActive);
        }
    }
}