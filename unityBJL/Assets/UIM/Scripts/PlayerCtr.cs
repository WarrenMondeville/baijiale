using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour {

	public static PlayerCtr instance;

	
	private int money=10000;
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

	public int StakeNum;
    public DetermineResult playerDetermine;

    public List<GameObject> chips = new List<GameObject>();

    public void ResetData()
    {
        StakeNum = 0;
        playerDetermine = DetermineResult.None;
        foreach (var item in chips)
        {
            Destroy(item);
        }
        chips.Clear();
    }

    void Awake()
	{
		instance = this;
        ResetData();

    }


	public void ResetMony()
	{
		Money = 10000;
	}
    public void CancelStake()
    {

        Money += StakeNum;
        ResetData();
    }
}
