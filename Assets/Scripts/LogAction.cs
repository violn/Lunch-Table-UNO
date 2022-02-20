using UnityEngine;
using UnityEngine.UI;

public class LogAction : MonoBehaviour
{
    static GameObject Logger;

    void Start()
    {
        Logger = gameObject;
    }

    public static void LogPlay(Player player, Card card)
    {
        Logger.GetComponent<Text>().text += $"{player.Name} played a {card}.\n";
    }

    public static void LogDraw(Player player)
    {
        Logger.GetComponent<Text>().text += $"{player.Name} drew a card.\n";
    }

    public static void LogDraw(Card card)
    {
        Logger.GetComponent<Text>().text += $"You drew a {card}.\n";
    }
}
