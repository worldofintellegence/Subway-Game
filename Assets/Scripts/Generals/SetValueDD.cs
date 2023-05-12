using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValueDD : MonoBehaviour {

    public Text textValue;
	public void SetValue(int valueSet, bool negative = true)
    {
        textValue.text = (negative == true ? "-" : "+") + valueSet.ToString();
    }
}
