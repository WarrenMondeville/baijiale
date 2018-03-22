using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum GameState
{
	None,
	Stake,
    NewHand,
    DealingCards,
    CheckingImmediateWinners,
    AskingIfPunterHits,
    AskingIfBankerHits,
    DeterminingWinner,
    HandOver,
}
