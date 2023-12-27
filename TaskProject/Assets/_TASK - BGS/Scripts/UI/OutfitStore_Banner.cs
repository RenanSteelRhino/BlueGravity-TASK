using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BGSTask
{
    public class OutfitStore_Banner : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] Button buyButton;
        [SerializeField] TextMeshProUGUI priceText;
        [SerializeField] TextMeshProUGUI descriptionText;
        [SerializeField] TextMeshProUGUI titleText;

        //Load the values into the banner
        public void SetupBanner(Sprite sprite, string price, string desc, string title)
        {
            icon.sprite = sprite;
            priceText.text = price;
            descriptionText.text = desc;
            titleText.text = title;
        }

        public void SetupBanner(SpriteBundle bundle)
        {
            icon.sprite = bundle.southSprite;
            priceText.text = bundle.price.ToString();
            descriptionText.text = bundle.description;
            titleText.text = bundle.title;
        }

        public Button GetButton()
        {
            return buyButton;
        }
    }
}
