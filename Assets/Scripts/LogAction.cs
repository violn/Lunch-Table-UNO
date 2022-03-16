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
        s_logger.GetComponent<Text>().text += $"{player.Name} played a {card}.\n";
    }

    public static void LogDraw(Player player)
    {
        s_logger.GetComponent<Text>().text += $"{player.Name} drew a card.\n";
    }

    public static void LogDraw(Card card)
    {
        s_logger.GetComponent<Text>().text += $"You drew a {card}.\n";
    }
}
