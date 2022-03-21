using UnityEngine;
using UnityEngine.UI;

public class CardAppearance : MonoBehaviour
{
    public Card CardValues;
    public Text TopTXT;
    public Text BottomTXT;

    void Update()
    {
        gameObject.GetComponent<Image>().color = CardValues.Color;
        TopTXT.text = BottomTXT.text = CardValues.Value.ToString();
    }
}
