using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace BGSTask
{
    public class FeedbackCoin : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI amountText;

        public void SetupCoin(string amountText)
        {
            this.amountText.text = amountText;
            StartCoroutine(ReturnToPool());
            DoAnimation();
        }

        void DoAnimation()
        {
            transform.localScale = new Vector3(0,0,0);
            transform.DOMoveY(transform.position.y + 1, 1).SetEase(Ease.OutCubic);
            transform.DOScale(new Vector3(0.65f, 0.65f, 0.65f), 0.4f).SetEase(Ease.InBack).OnComplete( () => transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InExpo));
        }

        IEnumerator ReturnToPool()
        {
            yield return new WaitForSeconds(1.5f);
            FeedbackTextManager.Instance.AddToPool(this.gameObject);
        }
    }
}
