using CodeBase.AssetManagement;
using CodeBase.Elements;
using CodeBase.Services;
using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.ClickerLogic
{
    public class MoneyClicker : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private MoneyBar _moneyBar;

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _moneyText;

        [SerializeField] private GameObject _window;

        private IPersistentProgressService _progressService;
        private IAssetProvider _assets;
        private Money _money;

        private void Awake()
        {
            InitProgress();
            _button.onClick.AddListener(AddMoney);
            RefreshLevelText();
            RefreshMoneyText();
        }

        private void InitProgress()
        {
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
            _assets = AllServices.Container.Single<IAssetProvider>();
            _money = _progressService.Progress.Money;
        }

        private void AddMoney()
        {
            _assets.Instantiate(AssetAddress.AddMoneyPopUpPath, _spawnPoint.position, _window.transform);
            _money.Value += _money.AddAmount;

            RefreshMoneyText();

            if (_money.Value >= _money.AmountForLevelUp)
                LevelUp();

            _moneyBar.SetValue(_money.Value, _money.AmountForLevelUp);
        }

        private void LevelUp()
        {
            _money.Value -= _money.AmountForLevelUp;
            _money.AddAmount *= 2;
            _money.AmountForLevelUp *= 2;
            _money.Level++;
            RefreshLevelText();
        }

        private void RefreshLevelText() =>
            _levelText.text = _money.Level.ToString();

        private void RefreshMoneyText() =>
            _moneyText.text = _money.Value.ToString();
    }
}
