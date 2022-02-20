using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackButton : MonoBehaviour
{
    public List<Card> StackedCards = new List<Card>();
    public Color Color;

    void Update()
    {
        gameObject.GetComponent<Image>().color = Color;
    }

    public void StackClick()
    {
        StackHolder.DisplayStack(StackedCards, gameObject);
    }

    public static void CreateStacks(Player player)
    {
        GameObject redStack = Instantiate(DrawButton.SStackPrefab);
        GameObject blueStack = Instantiate(DrawButton.SStackPrefab);
        GameObject greenStack = Instantiate(DrawButton.SStackPrefab);
        GameObject yellowStack = Instantiate(DrawButton.SStackPrefab);

        redStack.transform.SetParent(Game.SHandObject.transform);
        blueStack.transform.SetParent(Game.SHandObject.transform);
        greenStack.transform.SetParent(Game.SHandObject.transform);
        yellowStack.transform.SetParent(Game.SHandObject.transform);

        redStack.GetComponent<StackButton>().Color = Color.red;
        blueStack.GetComponent<StackButton>().Color = Color.blue;
        greenStack.GetComponent<StackButton>().Color = Color.green;
        yellowStack.GetComponent<StackButton>().Color = Color.yellow;

        foreach (Card card in player.Hand)
        {
            card.GameObject.SetActive(false);
            switch (card.ColorID)
            {
                case ColorID.red:
                    redStack.GetComponent<StackButton>().StackedCards.Add(card);
                    break;
                case ColorID.green:
                    greenStack.GetComponent<StackButton>().StackedCards.Add(card);
                    break;
                case ColorID.blue:
                    blueStack.GetComponent<StackButton>().StackedCards.Add(card);
                    break;
                case ColorID.yellow:
                    yellowStack.GetComponent<StackButton>().StackedCards.Add(card);
                    break;
            }
        }
    }
}