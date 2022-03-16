using UnityEngine;

public class DrawButton : MonoBehaviour
{
    public static GameObject SStackPrefab;
    public GameObject StackPrefab;

    void Awake()
    {
        SStackPrefab = StackPrefab;
    }

    public void DrawOnClick()
    {
        GameObject card = Instantiate(Game.SCardButtonPrefab);
        card.GetComponent<CardAppearance>().CardValues = Game.DrawDeck.Pop();
        LogAction.LogDraw(card.GetComponent<CardAppearance>().CardValues);
        AddCard(Game.PlayerQueue1.Peek(), card.GetComponent<CardAppearance>().CardValues, Game.SHandObject, card);
    }

    public static void AddCard(Player player, Card card, GameObject playerObject, GameObject cardObject, bool skipTurn = false)
    {
        player.Hand.Add(card);
        cardObject.GetComponent<CardAppearance>().CardValues = card;
        player.Skipped = skipTurn;

        if (StackHolder.Stacked)
        {
            Stack.AddToStack(card);
            return;
        }

        if (player.Hand.Count > 7)
        {
            Stack.CreateStacks(player);
            return;
        }

        cardObject.transform.SetParent(playerObject.transform);
        card.GameObject = cardObject;
    }

    public static void AddCard(Player player, Card card, bool skipTurn = false)
    {
        player.Hand.Add(card);
        player.Skipped = skipTurn;
    }
}
