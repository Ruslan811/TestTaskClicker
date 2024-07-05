using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace CodeBase.Windows
{
    public class ShopWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI SkullText;
        public RewardedAdItem AdItem;

        public void Construct(IPersistentProgressService progressService)
        {
            base.Construct(progressService);
            AdItem.Construct(progressService);
        }

        protected override void Initialize()
        {
            AdItem.Initialize();
            RefreshSkullText();
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            RefreshSkullText();
        }

        private void RefreshSkullText() =>
          SkullText.text = Progress.Money.Value.ToString();
    }
}