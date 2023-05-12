using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListCharacterUse : MonoBehaviour {

    public List<GameObject> listHeroUse = new List<GameObject>();
    public List<GameObject> listSkisUse = new List<GameObject>();
    public List<GameObject> listJetpackUse = new List<GameObject>();
    public List<GameObject> listBoatUse = new List<GameObject>();
    public List<IconHoverBuy> listIcon = new List<IconHoverBuy>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Modules.listHeroUse = listHeroUse;
        Modules.listSkisUse = listSkisUse;
        Modules.listJetpackUse = listJetpackUse;
        Modules.listBoatUse = listBoatUse;
        Modules.listIcon = listIcon;
    }
}
