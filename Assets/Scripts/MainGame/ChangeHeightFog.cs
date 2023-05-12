using UnityEngine;
using System.Collections;

public class ChangeHeightFog : MonoBehaviour {

    public float maxHeight = 50f;
    public Vector2 fogOrigin = new Vector2(70, 130);
    public Vector2 fogMinValue = new Vector2(0, 30);
    public Color colorOrigin = Color.white;

    void FixedUpdate()
    {
        if (Modules.mainCharacter == null || Modules.statusGame != StatusGame.flyScene) return;
        float percentX = Modules.mainCharacter.transform.position.y / maxHeight;
        float distanA = fogOrigin.x - Modules.distanceFogTempleX;
        float distanB = fogOrigin.y - Modules.distanceFogTempleY;
        if (distanA < 0) distanA = 0;
        if (distanB < 0) distanB = 0;
        float percentA = distanA - percentX * distanA;
        float percentB = distanB - percentX * distanB;
        float percentC = 1 - percentX;
        if (percentA <= fogMinValue.x)
            percentA = fogMinValue.x;
        if (percentB <= fogMinValue.y)
            percentB = fogMinValue.y;
        if (percentC < 0) percentC = 0;
        RenderSettings.fogStartDistance = percentA;
        RenderSettings.fogEndDistance = percentB;
        //if (Modules.useTemple)
            Modules.matBGChangeMap.color = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, percentX);
    }

    public void ResetValue(bool resetColorTemple = false)
    {
        float distanA = fogOrigin.x - Modules.distanceFogTempleX;
        float distanB = fogOrigin.y - Modules.distanceFogTempleY;
        if (distanA < 0) distanA = fogMinValue.x;
        if (distanB < 0) distanB = fogMinValue.y;
        RenderSettings.fogStartDistance = distanA;
        RenderSettings.fogEndDistance = distanB;
        if (Modules.statusGame == StatusGame.flyScene && resetColorTemple)
            Modules.matBGChangeMap.color = new Color(Modules.colorBGChangeMap.r, Modules.colorBGChangeMap.g, Modules.colorBGChangeMap.b, 0);
    }
}
