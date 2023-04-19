using UnityEngine;

public class Symbol : MonoBehaviour
{
    public char SymbolValue { get; set; }
    public int Modifier { get; set; }
    public int Bonus { get; set; }
    public bool IsChoosen { get; set; }
    public bool IsRemoved { get; set; }
    public int IdInWord { get; set; }
}
