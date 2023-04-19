using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public TextAsset Words;
    public static List<string> WordsList { get; private set; } = new List<string>();
    void Awake()
    {
        GetWords();
    }

    private void GetWords()
    {
        string text = Words.text;
        WordsList = text.Split(',').ToList();
        WordsList.Sort();
    }

}
