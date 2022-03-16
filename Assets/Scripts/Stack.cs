using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static GameObject RedStack;
    public static GameObject BlueStack;
    public static GameObject GreenStack;
    public static GameObject YellowStack;

    public static void CreateStacks(Player player)
    {
        StackHolder.Stacked = true;

        RedStack = Instantiate(DrawButton.SStackPrefab);
        BlueStack = Instantiate(DrawButton.SStackPrefab);
        GreenStack = Instantiate(DrawButton.SStackPrefab);
        YellowStack = Instantiate(DrawButton.SStackPrefab);

        RedStack.transform.SetParent(Game.SHandObject.transform);
        BlueStack.transform.SetParent(Game.SHandObject.transform);
        GreenStack.transform.SetParent(Game.SHandObject.transform);
        YellowStack.transform.SetParent(Game.SHandObject.transform);

        RedStack.GetComponent<StackButton>().Color = Color.red;
        BlueStack.GetComponent<StackButton>().Color = Color.blue;
        GreenStack.GetComponent<StackButton>().Color = Color.green;
        YellowStack.GetComponent<StackButton>().Color = Color.yellow;

        foreach (Card card in player.Hand)
        {
            Destroy(card.GameObject);
            AddToStack(card);
        }
    }

    public static void AddToStack(Card card)
    {
        switch (card.ColorID)
        {
            case ColorID.red:
                RedStack.GetComponent<StackButton>().StackedCards.Add(card);
                break;
            case ColorID.green:
                GreenStack.GetComponent<StackButton>().StackedCards.Add(card);
                break;
            case ColorID.blue:
                BlueStack.GetComponent<StackButton>().StackedCards.Add(card);
                break;
            case ColorID.yellow:
                YellowStack.GetComponent<StackButton>().StackedCards.Add(card);
                break;
        }
    }
}