/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
//using Facebook.MiniJSON;
#endif

public class MessageInviteFB : MonoBehaviour {

    //xu ly ngon ngu
    public Text textTitle, textNote, textButton;

    public void StartShowMessage()
    {
        //xu ly ngon ngu
        int iLang = Modules.indexLanguage;
        textTitle.font = AllLanguages.listFontLangA[iLang];
        textTitle.text = AllLanguages.menuInvite[iLang];
        textNote.font = AllLanguages.listFontLangB[iLang];
        textNote.text = AllLanguages.menuNoteInvite[iLang];
        textButton.font = AllLanguages.listFontLangA[iLang];
        textButton.text = AllLanguages.menuButtonInvite[iLang];
    }

    public void ButtonCloseClick()
    {
        transform.gameObject.GetComponent<Animator>().SetTrigger("TriClose");
        Modules.PlayAudioClipFree(Modules.audioButton);
    }

    *//*public void ButtonInviteClick()
    {
#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
        //Facebook.Unity.FB.Mobile.AppInvite(
        //   new System.Uri(Modules.linkShortFB),
        //   new System.Uri(Modules.linkIconGame),
        //   RewardInviteFB
        //   );
        Facebook.Unity.FB.AppRequest(
            AllLanguages.menuMessageInvite[Modules.indexLanguage],
            null, null, null, 100, string.Empty, AllLanguages.menuTitleInvite[Modules.indexLanguage], RewardInviteFB);
        ButtonCloseClick();
#endif
    }*//*

#if !(UNITY_WINRT || UNITY_WINRT_8_1 || UNITY_WINRT_10_0)
  *//*  private void RewardInviteFB(Facebook.Unity.IAppRequestResult result)
    {
        //Modules.textDebug.text += "\n" + result;
        //thuong moi khi moi ban be
        var responseObject = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
        string data = "";
        responseObject.TryGetValue("to", out data);
        if (data != null && data != "")
        {
            string[] idFriends = data.Split(',');
            if (idFriends.Length > 0)
            {
                int totalCoinBonus = Modules.coinBonusInvite * idFriends.Length;
                if (totalCoinBonus > Modules.coinMaxInvite) totalCoinBonus = Modules.coinMaxInvite;
                Modules.totalCoin += totalCoinBonus;
                Modules.SaveCoin();
                Modules.coinMaxInvite -= totalCoinBonus;
                Modules.SaveCheckInviteFB();
            }
        }
    }*//*
#endif
}
*/