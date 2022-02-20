using UnityEngine;

public class CardButton : MonoBehaviour
{
    public void CardOnClick()
    {
        Card card = gameObject.GetComponent<CardAppearance>().CardValues;
        if (!Game.PlayerQueue1.Peek().CPU && Game.TopCard.GetComponent<CardAppearance>().CardValues.Equals(card))
        {
            Game.TopCard.GetComponent<CardAppearance>().CardValues = card;
            Game.DiscardPile.Add(card);

            if (StackHolder.Open)
            {
                StackHolder.StackOpened.GetComponent<StackButton>().StackedCards.Remove(card);
            }

            Game.PlayerQueue1.Peek().Hand.Remove(card);
            gameObject.SetActive(false);
            LogAction.LogPlay(Game.PlayerQueue1.Peek(), card);
            StackHolder.UnDisplayStack();
            Game.GoNextTurn();
        }
    }
}
