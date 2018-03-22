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

	public void DealPoker (Hand hand)
	{
		this.hand = hand;
		var tpos=this.gameObject.AddComponent<CustomTweenPosition> ();
		tpos.from = GetComponent<RectTransform> ().anchoredPosition3D;
		tpos.to=hand.GetCardPos();//GetComponent<RectTransform> ().anchoredPosition3D;
		tpos.duration = 0.6f;
		tpos.easeType = EaseType.easeInCirc;
		tpos.onFinished.Add(new EventDelegate(DealRotate));
		//GetComponent<CustomTweenRotation> ().enabled = true;
	}

	void DealRotate()
	{
		var trot=this.gameObject.AddComponent<CustomTweenRotation>();
		trot.from = new Vector3 (0, -180, 0);
		trot.to = new Vector3 (0,-90,0);
		trot.duration = 0.2f;
		trot.easeType = EaseType.easeOutCirc;
		trot.onFinished.Add(new EventDelegate(FaceUp));
		trot.onFinished.Add (new EventDelegate(DealRotate2));
	}

	void DealRotate2()
	{
		var trot=this.gameObject.AddComponent<CustomTweenRotation1>();
		trot.from = new Vector3 (0, -90, 0);
		trot.to = new Vector3 (0,0,0);
		trot.duration = 0.2f;
		trot.easeType = EaseType.easeOutCirc;
		trot.onFinished.Add (new EventDelegate(SetCardParent));

	}

	void SetCardParent()
	{
		this.transform.SetParent (hand.cardsGroup.transform);
		Debug.Assert(hand.cards.Count < 3, "Attempted to deal to hand with 3 cards!");
		hand.AddCard(this);

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
