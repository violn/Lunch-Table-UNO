using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Game : MonoBehaviour
{
    static readonly Random s_ran = new Random();
    static List<Card> s_shuffleDeck = new List<Card>();
    public static Queue<Player> PlayerQueue1 = new Queue<Player>();
    public static Queue<Player> PlayerQueue2 = new Queue<Player>();
    public static Stack<Card> DrawDeck = new Stack<Card>();
    public static List<Card> DiscardPile = new List<Card>();
    public static GameObject TopCard;
    public static GameObject SCardButtonPrefab;
    public static GameObject SHandObject;
    public static GameObject SWinScreenObject;
    public static bool GameEnded = false;
    public GameObject CardButtonPrefab;
    public GameObject DiscardObject;
    public GameObject CardPrefab;
    public GameObject HandObject;
    public GameObject WinScreenObject;

    void Awake()
    {
        s_shuffleDeck.Clear();
        PlayerQueue1.Clear();
        PlayerQueue2.Clear();
        DrawDeck.Clear();
        DiscardPile.Clear();
        GameEnded = false;
        PlayerQueue1.Enqueue(new Player("Player"));
        PlayerQueue1.Enqueue(new Player("CPU", true));
        StackHolder.HolderObject.SetActive(false);
        SCardButtonPrefab = CardButtonPrefab;
        SHandObject = HandObject;
        SWinScreenObject = WinScreenObject;
    }

    void Start()
    {
        LogAction.Clear();
        for (int color = 0; color < 4; color++)
        {
            for (int value = 1; value <= 9; value++)
            {
                s_shuffleDeck.Add(
                    new Card(
                    color switch
                    {
                        0 => Color.red,
                        1 => Color.green,
                        2 => Color.blue,
                        3 => Color.yellow,
                        _ => throw new NotImplementedException(),
                    },
                value,
                (ColorID)color));
            }
        }

        CreateDrawDeck();
        s_shuffleDeck.Clear();

        foreach (Player player in PlayerQueue1)
        {
            if (!player.CPU)
            {
                while (player.Hand.Count < 7)
                {
                    Card card = DrawDeck.Pop();
                    GameObject cardObject = Instantiate(CardButtonPrefab);
                    card.GameObject = cardObject;
                    player.Hand.Add(card);
                    cardObject.GetComponent<CardAppearance>().CardValues = card;
                    cardObject.transform.SetParent(HandObject.transform);
                    LogAction.LogDraw(card);
                }
            }

            else
            {
                while (player.Hand.Count < 7)
                {
                    Card card = DrawDeck.Pop();
                    player.Hand.Add(card);
                }
            }
        }

        TopCard = Instantiate(CardPrefab);
        TopCard.GetComponent<CardAppearance>().CardValues = DrawDeck.Pop();
        TopCard.transform.SetParent(DiscardObject.transform);
    }

    void Update()
    {
        if (!GameEnded)
        {
            PlayCPU();
        }
    }

    static void PlayCPU()
    {
        if (PlayerQueue1.Peek().CPU)
        {
            foreach (var card in PlayerQueue1.Peek().Hand.Where(card => card == TopCard.GetComponent<CardAppearance>().CardValues))
            {
                TopCard.GetComponent<CardAppearance>().CardValues = card;
                DiscardPile.Add(TopCard.GetComponent<CardAppearance>().CardValues);
                PlayerQueue1.Peek().Hand.Remove(card);
                LogAction.LogPlay(PlayerQueue1.Peek(), card);
                DeclareWinner(PlayerQueue1.Peek());

                if (!GameEnded)
                {
                    GoNextTurn();
                }

                return;
            }

            Card drawnCard = DrawDeck.Pop();
            LogAction.LogDraw(PlayerQueue1.Peek());
            ReShuffle();


            if (drawnCard != TopCard.GetComponent<CardAppearance>().CardValues)
            {
                PlayerQueue1.Peek().Hand.Add(drawnCard);
            }

            else
            {
                TopCard.GetComponent<CardAppearance>().CardValues = drawnCard;
                DiscardPile.Add(TopCard.GetComponent<CardAppearance>().CardValues);
                LogAction.LogPlay(PlayerQueue1.Peek(), drawnCard);
            }

            GoNextTurn();
        }
    }

    static void CreateDrawDeck()
    {
        while (s_shuffleDeck.Count > 0)
        {
            int index = s_ran.Next(s_shuffleDeck.Count);
            DrawDeck.Push(s_shuffleDeck[index]);
            s_shuffleDeck.RemoveAt(index);
        }
    }

    public static void GoNextTurn()
    {
        PlayerQueue2.Enqueue(PlayerQueue1.Dequeue());

        if (PlayerQueue1.Count == 0)
        {
            for (int i = 0; i < PlayerQueue2.Count; i++)
            {
                PlayerQueue1.Enqueue(PlayerQueue2.Dequeue());
            }
        }
    }

    public static void ReShuffle()
    {
        if (DrawDeck.Count == 0)
        {
            s_shuffleDeck = DiscardPile;
            CreateDrawDeck();
            LogAction.LogReshuffle();
        }
    }

    public static void DeclareWinner(Player player)
    {
        if (player.Hand.Count == 0)
        {
            s_shuffleDeck.Clear();
            PlayerQueue1.Clear();
            PlayerQueue2.Clear();
            DrawDeck.Clear();
            DiscardPile.Clear();
            GameEnded = true;
            SWinScreenObject.SetActive(true);
            LogAction.LogWinner(player);
        }
    }
}
