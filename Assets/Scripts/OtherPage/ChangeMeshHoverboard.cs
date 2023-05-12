using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMeshHoverboard : MonoBehaviour {

    public List<SetupMeshHoverboard> listHoverboard;
    private string oldCode = "";
    void OnEnable()
    {
        string codeNow = Modules.codeSkisUse;
        if (Modules.codeSkisTrying != "") codeNow = Modules.codeSkisTrying;
        if (codeNow == oldCode) return;
        foreach (SetupMeshHoverboard smh in listHoverboard)
        {
            if (smh.id == codeNow)
            {
                oldCode = codeNow;
                transform.parent.GetComponent<MeshFilter>().mesh = smh.mesh;
                transform.parent.GetComponent<MeshRenderer>().material = smh.material;
                break;
            }
        }
    }
}
[System.Serializable]//de show ra phan input cua unity editor
public class SetupMeshHoverboard
{
    public string id;
    public Mesh mesh;
    public Material material;

    public SetupMeshHoverboard(string idInput, Mesh meshInput, Material materialInput)
    {
        this.id = idInput;
        this.mesh = meshInput;
        this.material = materialInput;
    }
}