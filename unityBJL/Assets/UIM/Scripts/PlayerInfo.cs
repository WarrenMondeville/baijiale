using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInfo : MonoBehaviour {


	public Text money;
	void Start () {
		PlayerCtr.instance.OnPlayerMoneyChangedEvent+=OnPlayerMoneyChanged;
	}
	void OnDestory()
	{
		PlayerCtr.instance.OnPlayerMoneyChangedEvent-=OnPlayerMoneyChanged;
	}
	
	void OnPlayerMoneyChanged (int money) {
		this.money.text = money.ToString ();
	}
}
