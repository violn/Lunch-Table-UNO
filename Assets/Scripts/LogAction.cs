using UnityEngine;
using UnityEngine.UI;

public class LogAction : MonoBehaviour
{
    static GameObject s_logger;

    void Awake()
    {
        s_logger = gameObject;
    }

    public static void LogPlay(Player player, Card card)
    {
        s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text.Insert(0, $"{player.Name} played a {card}.\n");
    }

    public static void LogDraw(Player player)
    {
        s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text.Insert(0, $"{player.Name} drew a card.\n");
    }

    public static void LogDraw(Card card)
    {
        s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text.Insert(0, $"You drew a {card}.\n");
    }

    public static void LogReshuffle()
    {
        s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text.Insert(0, $"The draw deck has been reshuffled.\n");
    }

    public static void LogWinner(Player player)
    {
        s_logger.GetComponent<Text>().text = s_logger.GetComponent<Text>().text.Insert(0, $"{player.Name} is the winner.\n");
    }
}
