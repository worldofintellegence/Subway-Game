using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMeshJetpack : MonoBehaviour {

    public List<SetupMeshJetpack> listJetpack;
    private string oldCode = "";
    void OnEnable()
    {
        string codeNow = Modules.codeJetpackUse;
        if (Modules.codeJetpackTrying != "") codeNow = Modules.codeJetpackTrying;
        if (codeNow == oldCode) return;
        foreach (SetupMeshJetpack smj in listJetpack)
        {
            if (smj.id == codeNow)
            {
                oldCode = codeNow;
                transform.parent.GetComponent<MeshFilter>().mesh = smj.mesh;
                transform.parent.GetComponent<MeshRenderer>().material = smj.material;
                break;
            }
        }
    }
}
[System.Serializable]//de show ra phan input cua unity editor
public class SetupMeshJetpack
{
    public string id;
    public Mesh mesh;
    public Material material;

    public SetupMeshJetpack(string idInput, Mesh meshInput, Material materialInput)
    {
        this.id = idInput;
        this.mesh = meshInput;
        this.material = materialInput;
    }
}