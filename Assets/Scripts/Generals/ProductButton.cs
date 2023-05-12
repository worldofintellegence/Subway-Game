using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductButton : MonoBehaviour {
    public string Name; //Ten trung voi ten co trong Name list product IAP
    string productID;
    public Text title, total, description, price, textButton;
    public Image image, iconSale;

    void OnEnable()
    {
        int iLang = Modules.indexLanguage;
        if (title != null) title.font = AllLanguages.listFontLangA[iLang];
        if (total != null) total.font = AllLanguages.listFontLangB[iLang];
        if (description != null) description.font = AllLanguages.listFontLangB[iLang];
        if (textButton != null) textButton.font = AllLanguages.listFontLangA[iLang];
       //ReloadCost();
    }

  /*  public bool UpdateData(string productName)
    {
        bool sucsses = false;
        if (Purchaser.Instance == null) return false;
        foreach (var item in Purchaser.Instance.productIAP)
        {
            if (item.Name == productName)
            {
                Name = productName;
                if (textButton != null) textButton.text = AllLanguages.shopButtonBuy[Modules.indexLanguage];
                if (title != null) title.text = AllLanguages.shopPackage[item.indexTitle][Modules.indexLanguage];
                if (total != null) total.text = AllLanguages.shopUseRight[Modules.indexLanguage];
                if (description != null)
                {
                    if (item.Type == ModificationType.Coin)
                    {
                        description.text = AllLanguages.shopStartPurchase[Modules.indexLanguage] + " " + item.Count + " " + AllLanguages.shopEndCoinPurchase[Modules.indexLanguage];
                    }
                    else if (item.Type == ModificationType.Key)
                    {
                        description.text = AllLanguages.shopStartPurchase[Modules.indexLanguage] + " " + item.Count + " " + AllLanguages.shopEndKeysPurchase[Modules.indexLanguage];
                    }
                    else if (item.Type == ModificationType.DoubleCoin)
                    {
                        description.text = AllLanguages.shopDoubleCoin[Modules.indexLanguage];
                    }
                    else if (item.Type == ModificationType.StarterPack)
                    {
                        description.text = AllLanguages.shopStarterPack[Modules.indexLanguage];
                    }
                }
                if (Purchaser.Instance.IsInitialized())
                {
                    if (price != null)
                    {
                        price.text = "????";
                        string priceStr = Purchaser.m_StoreController.products.WithID(item.ID).metadata.localizedPriceString.ToString();
                        if (priceStr != "")
                        {
                            price.text = priceStr;
                            sucsses = true;
                        }  
                    }
                }
                if (image != null && item.Image != null) image.sprite = item.Image;
                if (iconSale != null)
                {
                    if (item.iconSale != null)
                    {
                        iconSale.sprite = item.iconSale;
                        iconSale.color = new Color(1, 1, 1, 1);
                    }
                    else iconSale.color = new Color(1, 1, 1, 0);
                }
                productID = item.ID;
                break;
            }
        }
        return sucsses;
    }*/

   /* void ReloadCost()
    {
        if (!UpdateData(Name))
            Invoke("ReloadCost", 1);
    }
*/
   /* public void OnClick() {
        if (productID != "")
        {
            Purchaser.Instance.BuyProductID(productID);
            Modules.PlayAudioClipFree(Modules.audioBuyCoin);
        }
    }*/
}
