using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultPanel : MonoBehaviour {

	public GameObject panel;
	public Text textResult;
	public Text textScore;
	public Button btnSure;

	void Start () {
		GameManager.Instance.DetemineResultEvent += DetemineResult;

		btnSure.onClick.AddListener (OnClickSure);
	}
	
	void OnDestroy()
	{
		GameManager.Instance.DetemineResultEvent -= DetemineResult;

		btnSure.onClick.RemoveListener (OnClickSure);
	}



	void OnClickSure()
	{
		panel.SetActive (false);
		GameManager.Instance.gameState = GameState.Stake;
	}

	void DetemineResult(DetermineResult result,int score)
	{
		panel.SetActive (true);
		switch (result) {
		case DetermineResult.Banker:
			textResult.text="庄";
				break;
		case DetermineResult.Push:
			textResult.text="和";
			break;
		case DetermineResult.Punter:
			textResult.text="闲";
			break;
		default:
			break;
		}
		textScore.text = score.ToString();

	}
}
