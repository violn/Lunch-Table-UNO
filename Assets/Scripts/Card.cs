using UnityEngine;

public class Card
{
    public ColorID ColorID { get; }
    public Color Color { get; }
    public int Value { get; }
    public string Name { set; get; }
    public GameObject GameObject { set; get; }
    // TODO Add card names for ToString
    // TODO Add ways to hold multiple effects for custom cards

    public Card(Color color, int value, ColorID id)
    {
        Color = color;
        Value = value;
        ColorID = id;
    }

    public override string ToString()
    {
        string color = ColorID switch
        {
            ColorID.red => "Red",
            ColorID.green => "Green",
            ColorID.blue => "Blue",
            ColorID.yellow => "Yellow",
            _ => "Wild"
        };

        return $"{color} {Value}";
    }

    public static bool operator ==(Card left, Card right)
    {
        return left.Value == right.Value && left.Color == right.Color;
    }

    public static bool operator !=(Card left, Card right)
    {
        return left.Value != right.Value || left.Color != right.Color;
    }

    public override bool Equals(object obj)
    {
        Card card = obj as Card;
        return card.Value == Value || card.Color == Color;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
