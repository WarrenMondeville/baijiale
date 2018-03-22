using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleTools : MonoBehaviour {
	public Toggle toggle;
	public GameObject On,Off;
	private bool togglevalue;
	void Awake()
	{
		toggle.onValueChanged.AddListener (OnToggleValueChanged);

	}

	public bool ToggleValue{ 
		get{return togglevalue;}
		set{
			On.SetActive (value);
			Off.SetActive (!value);
		}
	}
	void OnToggleValueChanged(bool value)
	{
		ToggleValue = value;

	}


}
