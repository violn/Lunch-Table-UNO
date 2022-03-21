using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayers : MonoBehaviour
{
    void Start()
    {
        foreach (var player in Game.PlayerQueue1)
        {
            gameObject.GetComponent<Text>().text += player.Name;
        }
    }
}
