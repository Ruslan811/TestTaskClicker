using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace CodeBase.Windows
{
    public class ClickerWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void Construct(IPersistentProgressService progressService) => 
            base.Construct(progressService);

        protected override void Initialize() => 
            RefreshMoneyText();

        private void RefreshMoneyText() =>
          _moneyText.text = Progress.Money.Value.ToString();
    }
}