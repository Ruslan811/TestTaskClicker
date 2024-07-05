using CodeBase.Services;
using CodeBase.Services.PersistentProgress;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.PopUps {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyAddPopUp : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private IPersistentProgressService _progressService;

        private void OnEnable()
        {
            TextInit();

            DOTween.Sequence()
                .Append(transform.DOLocalMoveY(25, 2))
                .Append(_text.DOFade(0, 2))
                .AppendCallback(EndAnimation);
        }

        private void TextInit()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
            _text.text = "+" + _progressService.Progress.Money.AddAmount.ToString();
        }

        private void EndAnimation() => 
            Destroy(gameObject);
    }
}