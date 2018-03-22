using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int randomSeed = 0;
    public Shoe shoe;
    public GameObject newHandButton;
    public Hand punterHand;
    public Hand bankerHand;
    public float dealDelay = 1.0f;



    private System.Random _random;
	private GameState _gameState=GameState.None; //= GameState.NewHand;

	public GameState gameState{
		get {
			return _gameState;
		}
		set{
			if (value!=_gameState) {
				_gameState=value;
				if (OnGameStateChangeEvent!=null) {
					OnGameStateChangeEvent(_gameState);
				}
			}

		}

	}
	public delegate void OnGameStateChangeHandler(GameState state);
	public OnGameStateChangeHandler OnGameStateChangeEvent;

	public delegate void DetemineResultHandler (DetermineResult result,int score);

	public  DetemineResultHandler  DetemineResultEvent;

    public System.Random Random
    {
        get
        {
            return _random;
        }
    }

    public void PunterResponds(bool hit)
    {
        punterHand.buttons.gameObject.SetActive(false);
        bankerHand.buttons.gameObject.SetActive(true);
        if (hit)
        {
            shoe.Deal(punterHand);
        }
        gameState = GameState.AskingIfBankerHits;
        if (bankerHand.player is AiPlayer)
        {
            BankerResponds((bankerHand.player as AiPlayer).HitOrStay(punterHand, true));
        }
    }

    public void BankerResponds(bool hit)
    {
        bankerHand.buttons.gameObject.SetActive(false);
        if (hit)
        {
            shoe.Deal(bankerHand);
        }
        gameState = GameState.DeterminingWinner;
        DetermineWinner();
    }

    public void StartNewHand()
    {

        gameState = GameState.NewHand;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogAssertion("Two GameManagers present!");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (randomSeed == 0)
        {
            if (UnityEngine.Random.Range(0, 1) == 0)
            {
                randomSeed = UnityEngine.Random.Range(int.MinValue, 0);
            }
            else
            {
                randomSeed = UnityEngine.Random.Range(1, int.MaxValue);
            }
        }

        _random = new System.Random(randomSeed);
        UnityEngine.Random.InitState(randomSeed);

        punterHand.player = new HumanPlayer();
        punterHand.player.hand = punterHand;
        bankerHand.player = new HumanPlayer();
        bankerHand.player.hand = bankerHand;
    }

	private void Start()
	{
		OnGameStateChangeEvent += OnGameStateChange;
	}

	private void OnDestroy()
	{
		OnGameStateChangeEvent -= OnGameStateChange;
	}

	private void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
		case GameState.None:
			break;
		case GameState.Stake:
			punterHand.DiscardCards();
			bankerHand.DiscardCards();
			newHandButton.gameObject.SetActive(true);
			break;
            case GameState.NewHand:
                newHandButton.gameObject.SetActive(false);
                _gameState = GameState.DealingCards;
                StartCoroutine(DealStartingHands());
                break;

            case GameState.CheckingImmediateWinners:
				DetermineWinner();
				break;
                if (punterHand.Value == 8 || punterHand.Value == 9 ||
                    bankerHand.Value == 8 || bankerHand.Value == 9)
                {
                    DetermineWinner();
                }
                else
                {
                    _gameState = GameState.AskingIfPunterHits;
					if (punterHand.player is AiPlayer)
                    {
                        PunterResponds((punterHand.player as AiPlayer).HitOrStay(bankerHand, false));
                    }
                    else
                    {
                        punterHand.buttons.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }

    private IEnumerator DealStartingHands()
    {
		punterHand.buttons.gameObject.SetActive (false);
		bankerHand.buttons.gameObject.SetActive (false);
		shoe.Deal (punterHand);
		yield return new WaitForSeconds (dealDelay);
		shoe.Deal (bankerHand);
		yield return new WaitForSeconds (dealDelay);
		shoe.Deal (punterHand);
		yield return new WaitForSeconds (dealDelay);
		shoe.Deal (bankerHand);
		yield return new WaitForSeconds (dealDelay);
		gameState = GameState.CheckingImmediateWinners;

	}		
	
	private void DetermineWinner()
    {
        gameState = GameState.HandOver;
        
		DetermineResult result;
		int money = 0;
        if (bankerHand.Value < punterHand.Value)
        {
            Debug.Log("Punter wins!");
			result=DetermineResult.Punter;
			money=PlayerCtr.instance.StakeNum;
        }
        else if (bankerHand.Value == punterHand.Value)
        {
            Debug.Log("Push!");
			result=DetermineResult.Push;
			money=PlayerCtr.instance.StakeNum*8;
        }
        else
        {
            Debug.Log("Banker wins!");
			result=DetermineResult.Banker;
			money=PlayerCtr.instance.StakeNum;

        }
		if (DetemineResultEvent!=null) {
			DetemineResultEvent(result,money);
			
		}
    }
}


public enum DetermineResult:byte
{
	Punter,
	Banker,
	Push,
}

