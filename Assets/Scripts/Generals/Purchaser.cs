/*using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour//, IStoreListener
{
    public static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    public static Purchaser Instance;
    public string AndroidKey;
    public List<ProductIAP> productIAP;
    //xu ly restore cho cai thang MAC/IOS lon
    public GameObject buttonRestore;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
#if (UNITY_ANDROID)
        buttonRestore.SetActive(false);
#endif
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        // builder.Configure<IGooglePlayConfiguration>().SetPublicKey(AndroidKey);
        //KHOI TAO CAC TEN MAT HANG TREN CAC STORE
        foreach (var item in productIAP)
        {
            builder.AddProduct(item.ID, item.productType, new IDs(){
                {item.IdIOS, AppleAppStore.Name.ToString()},//dinh nghia them cho ro rang cac store, cung khong can thiet + IOS
                {item.IdAndroid, GooglePlay.Name.ToString()},
                {item.IdFacebook, FacebookStore.Name.ToString()},
                {item.ID, WindowsStore.Name.ToString()},
                {item.ID, AmazonApps.Name.ToString()},
                {item.ID, TizenStore.Name.ToString()},
                {item.IdAndroid, SamsungApps.Name.ToString()},
                {item.ID, XiaomiMiPay.Name.ToString()},
                {item.ID, MoolahAppStore.Name.ToString()},
                {item.IdMac, MacAppStore.Name.ToString()}
            });
        }
        // UnityPurchasing.Initialize(this, builder);
        //Modules.textDebug.text += "\ninit start";
    }

    public bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                RestoreIAP();
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            RestoreIAP();
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        //Modules.textDebug.text += "\ninit done";
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
        RestorePurchases();
    }

    public void RestoreIAP()
    {
        if (CheckRestoreDoubleCoins())
            AddDoubleCoin();
        if (CheckRestoreStarterPack())
            AddStarterPack();
        //buttonRestore.SetActive(false);
    }

    bool CheckRestoreDoubleCoins()
    {
        bool result = false;
        if (Modules.buyDoubleCoins != 2 && Purchased(productIAP[6].ID)) result = true;
        return result;
    }

    bool CheckRestoreStarterPack()
    {
        bool result = false;
        if (Modules.buyStarterPack != 2 && Purchased(productIAP[7].ID)) result = true;
        return result;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Modules.textDebug.text += "\ninit failed";
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        foreach (var item in productIAP)
        {
            if (String.Equals(args.purchasedProduct.definition.id, item.ID, StringComparison.Ordinal))
            {
                switch (item.Type)
                {
                    case ModificationType.StarterPack:
                        AddStarterPack();
                        break;
                    case ModificationType.DoubleCoin:
                        AddDoubleCoin();
                        break;
                    case ModificationType.Coin:
                        AddCoin(item.Count);
                        break;
                    case ModificationType.Key:
                        AddKey(item.Count);
                        break;
                }
            }
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    public void AutoBuy(ProductType type, int quantity)
    {
        foreach (var item in productIAP)
        {
            if (item.productType == type && item.Count >= quantity)
            {
                BuyProductID(item.ID);
                break;
            }
        }
    }

    //Xu ly mua double coin
    void AddDoubleCoin()
    {
        print("Xử lý cộng Double Coin");
        Modules.buyDoubleCoins = 2;
        Modules.SaveBuyDoubleCoin();
        if (Modules.containShopItem.activeSelf)
            Modules.containShopItem.transform.Find("MainCamera").GetComponent<PageShopItems>().UpdateItemSupport();
    }

    //Xu ly mua starter pack
    void AddStarterPack()
    {
        print("Xử lý thêm Starter Pack");
        Modules.buyStarterPack = 2;
        Modules.SaveBuyStarterPack();
        //thuc hien thuong cac item theo yeu cau
        Modules.totalCoin += 100000;
        Modules.SaveCoin();
        Modules.totalKey += 25;
        Modules.SaveKey();
        Modules.totalSkis += 25;
        if (Modules.totalSkis > Modules.maxHoverboard)
            Modules.totalSkis = Modules.maxHoverboard;
        Modules.SaveSkis();
        Modules.totalScoreBooster += 7;
        if (Modules.totalScoreBooster > Modules.maxScorebooster)
            Modules.totalScoreBooster = Modules.maxScorebooster;
        Modules.SaveScoreBooster();
        //mo khoa Biggy
        string codeHeroReward = "003";
        if (!Modules.listHeroUnlock.Contains(codeHeroReward))
        {
            Modules.listHeroUnlock.Add(codeHeroReward);
            Modules.SaveListHeroUnlock();
        }
        if (Modules.containShopItem.activeSelf)
        {
            PageShopItems pageShop = Modules.containShopItem.transform.Find("MainCamera").GetComponent<PageShopItems>();
            pageShop.UpdateItemSupport();
            pageShop.UpdateBuyStarterPack();
        }
        else if (Modules.containAchievement.activeSelf)
        {
            PageAchievement pageAchieve = Modules.containAchievement.transform.Find("MainCamera").GetComponent<PageAchievement>();
            pageAchieve.UpdateItemSupport();
            pageAchieve.UpdateBuyStarterPack();
        }
    }

    //Xu ly them coin
    void AddCoin(int quantity)
    {
        print("Xử lý cộng " + quantity + " Coins");
        Modules.totalCoin += quantity;
        Modules.SaveCoin();
        if (Modules.containShopItem.activeSelf)
            Camera.main.GetComponent<PageShopItems>().UpdateCoins();
    }

    //Xu ly them key
    void AddKey(int quantity)
    {
        print("Xử lý cộng " + quantity + " Keys");
        Modules.totalKey += quantity;
        Modules.SaveKey();
        if (Modules.containShopItem.activeSelf)
            Camera.main.GetComponent<PageShopItems>().UpdateKeys();
        if (Modules.containMainGame.activeSelf)
            Camera.main.GetComponent<PageMainGame>().UpdateKeys();
    }

    public bool Purchased(string ID)
    {
        if (m_StoreController != null)
            return m_StoreController.products.WithID(ID).hasReceipt;
        else
            return false;
    }
}

[System.Serializable]
public class ProductIAP
{
    public string Name;
    public string ID;
    public string IdAndroid;
    public string IdIOS;
    public string IdFacebook;
    public string IdMac;
    public ProductType productType;
    [Header("Information")]
    public int indexTitle;

    [Header("Modification")]
    public ModificationType Type;
    public int Count;
    public Sprite Image;
    public Sprite iconSale;
}

public enum ModificationType
{
    Coin,
    Key,
    DoubleCoin,
    StarterPack
}*/