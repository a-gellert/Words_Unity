using System.Collections.Generic;
using UnityEngine;

public class AlphabetController
{
    private float _originPercent;
    private int _countOfVowels;

    public void SetAlphabet(int size)
    {
        Alphabet.Alphalist = new List<char>();
        _originPercent = Random.Range(30f, 37f);

        _countOfVowels = Mathf.FloorToInt(size * size / 100f * _originPercent);
        for (int i = 0; i < (size * size); i++)
        {
            if (i < _countOfVowels)
            {
                Alphabet.Alphalist.Add(GetVowel());
            }
            else
            {
                Alphabet.Alphalist.Add(GetConsonant());
            }

        }
        for (int i = Alphabet.Alphalist.Count - 1; i >= 0; i--)
        {
            int j = Random.Range(0, i);
            var temp = Alphabet.Alphalist[j];
            Alphabet.Alphalist[j] = Alphabet.Alphalist[i];
            Alphabet.Alphalist[i] = temp;
        }
    }

    public static char GetVowel()
    {
        return Alphabet.Vowels[Random.Range(0, Alphabet.Vowels.Count)];
    }
    public static char GetConsonant()
    {
        return Alphabet.Consonantals[Random.Range(0, Alphabet.Consonantals.Count)];
    }
}
