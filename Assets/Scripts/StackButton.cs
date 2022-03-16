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
        StackHolder.DisplayStack(gameObject);
    }
}