using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

	public static PlayerCtr instance;

	public DetermineResult playerDetermine;
	private int money=1000;
	public int Money{
		get{
			return money;
		}
		set{
			money=value;
			if (OnPlayerMoneyChangedEvent!=null) {
				OnPlayerMoneyChangedEvent(money);
			}
		}

	}
	public delegate void OnPlayerMoneyChangedHandler(int money);
	public OnPlayerMoneyChangedHandler OnPlayerMoneyChangedEvent;

	public int StakeNum=100;

	void Awake()
	{
		instance = this;

	}


	public void ResetMony()
	{
		Money = 1000;
	}
}
