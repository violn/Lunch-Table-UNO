using System.Collections.Generic;
using UnityEngine;

public class StackHolder : MonoBehaviour
{
    public static GameObject HolderObject;
    public static GameObject StackOpened;
    static List<Card> DisplayedCards = new List<Card>();
    public static bool Open = false;

    private void Awake()
    {
        HolderObject = gameObject;
    }

    public static void DisplayStack(List<Card> stackedCards, GameObject stack)
    {
        DisplayedCards = stackedCards;
        StackOpened = stack;
        HolderObject.SetActive(true);

        foreach (Card card in DisplayedCards)
        {
            card.GameObject.transform.SetParent(HolderObject.transform);
            card.GameObject.SetActive(true);
        }
    }

    public static void UnDisplayStack()
    {
        foreach (Card card in DisplayedCards)
        {
            card.GameObject.SetActive(false);
        }

        DisplayedCards.Clear();
        HolderObject.SetActive(false);
    }
}
