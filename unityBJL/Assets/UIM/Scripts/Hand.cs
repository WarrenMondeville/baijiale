using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public HorizontalLayoutGroup buttons;
    public HorizontalLayoutGroup cardsGroup;
    public Text handValue;
    public Player player;
	public int Value;
	private Vector3 rectPos;
	void Awake()
	{
		rectPos=GetComponent<RectTransform>().anchoredPosition3D;
	}


	public void AddCard(Card card)
	{
		cards.Add (card);
	 	Value=	cards.Select(c => (int)c.rank).Where(r => r <= 9).Sum() % 10;
		handValue.text = Value.ToString();
	}

	public Vector3 GetCardPos()
	{
		return rectPos + cards.Count * new Vector3 (66,0,0);
	}

    public void DiscardCards()
    {
        foreach (var card in cards)
        {
            card.gameObject.SetActive(false);
            Destroy(card.gameObject);
        }
        cards.Clear();
		handValue.text = "";
    }

}
