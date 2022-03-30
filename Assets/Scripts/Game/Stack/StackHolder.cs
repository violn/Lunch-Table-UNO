using System.Collections.Generic;
using UnityEngine;

public class StackHolder : MonoBehaviour
{
    public static List<Card> DisplayedCards = new List<Card>();
    public static GameObject HolderObject;
    public static GameObject StackOpened;
    public static bool Open = false;
    public static bool Stacked = false;

    private void Awake()
    {
        HolderObject = gameObject;
    }

    public static void DisplayStack(GameObject stack)
    {
        DisplayedCards = stack.GetComponent<StackButton>().StackedCards;
        StackOpened = stack;
        HolderObject.SetActive(true);

        foreach (Card card in DisplayedCards)
        {
            GameObject cardObject = Instantiate(Game.SCardButtonPrefab);
            card.GameObject = cardObject;
            cardObject.GetComponent<CardAppearance>().CardValues = card;
            card.GameObject.transform.SetParent(HolderObject.transform);
            card.GameObject.SetActive(true);
        }
    }

    public static void UnDisplayStack(bool closeStack = false)
    {
        foreach (Card card in DisplayedCards)
        {
            Destroy(card.GameObject);
        }

        HolderObject.SetActive(false);

        if (closeStack)
        {
            Destroy(Stack.GreenStack);
            Destroy(Stack.RedStack);
            Destroy(Stack.BlueStack);
            Destroy(Stack.YellowStack);

            foreach (Card card in Game.PlayerQueue1.Peek().Hand)
            {
                card.GameObject = Instantiate(Game.SCardButtonPrefab);
                card.GameObject.GetComponent<CardAppearance>().CardValues = card;
                card.GameObject.transform.SetParent(Game.SHandObject.transform);
            }

            Open = false;
            Stacked = false;
            DisplayedCards.Clear();
        }
    }
}
