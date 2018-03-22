using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour
{
    private static AssetBundle CardSprites;

    public bool faceUp = true;
    public Suit suit = Suit.Spades;
    public Rank rank = Rank.Ace;
    public Back back = Back.Red;
	public uTools.TweenPosition tweenPos;
	public uTools.TweenRotation tweenRot;

    private Image _image;
	private Hand hand;

    private void Awake()
    {
        _image = GetComponent<Image>();
        if (CardSprites == null)
        {
            CardSprites = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles/cards"));
            Debug.Assert(CardSprites != null, "Couldn't load cards!");
        }
    }

	public void DealPoker(Hand hand)
	{
		this.hand = hand;
		tweenPos.to = hand.cardsGroup.transform.position;//.GetComponent<RectTransform> ().anchoredPosition;
		tweenPos.enabled = true;
	}

	public void SetCardParent()
	{
		this.transform.SetParent (hand.cardsGroup.transform);
	}

	public void FaceUp()
	{
		string path;
		path = string.Format("assets/UIM/cards/card{0}{1}.png", suit.GetAssetName(), rank.GetAssetName());
		var cardSprite = CardSprites.LoadAsset<Sprite>(path);
		Debug.AssertFormat(cardSprite != null, "Unable to load card: {0}", path);
		_image.sprite = cardSprite;

	}



    private void Updateback()
    {
        string path;
        if (faceUp)
        {
			path = string.Format("assets/UIM/cards/card{0}{1}.png", suit.GetAssetName(), rank.GetAssetName());
        }
        else
        {
			path = string.Format("assets/UIM/cards/cardBack{0}.png", back.GetAssetName());
        }

        var cardSprite = CardSprites.LoadAsset<Sprite>(path);
        Debug.AssertFormat(cardSprite != null, "Unable to load card: {0}", path);
        _image.sprite = cardSprite;
    }
}
