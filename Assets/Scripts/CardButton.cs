using UnityEngine;

public class CardButton : MonoBehaviour
{
    public void CardOnClick()
    {
        Card card = gameObject.GetComponent<CardAppearance>().CardValues;
        if (!Game.PlayerQueue1.Peek().CPU && Game.TopCard.GetComponent<CardAppearance>().CardValues == card)
        {
            Game.TopCard.GetComponent<CardAppearance>().CardValues = card;
            Game.PlayerQueue1.Peek().Hand.Remove(card);

            Game.DiscardPile.Add(card);

            if (StackHolder.Stacked)
            {
                StackHolder.StackOpened.GetComponent<StackButton>().StackedCards.Remove(card);
            }

            StackHolder.UnDisplayStack(Game.PlayerQueue1.Peek().Hand.Count <= 7 && StackHolder.Stacked);
            Destroy(gameObject);
            LogAction.LogPlay(Game.PlayerQueue1.Peek(), card);
            Game.GoNextTurn();
        }
    }
}
