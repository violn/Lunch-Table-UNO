using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    public List<Card> Hand { get; }
    public string Name { get; }
    public bool CPU = false;
    public bool Skipped = false;

    public Player(string name, bool cpu = false, List<Card> hand = null)
    {
        Name = name;
        Hand = hand ?? (new List<Card>());
        CPU = cpu;
    }

    public override string ToString()
    {
        return Name;
    }
}
