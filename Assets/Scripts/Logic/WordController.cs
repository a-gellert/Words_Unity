using UnityEngine;

public class WordController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text _wordTXT;
    public static bool IsRight { get; set; } = false;

    public string Word { get; private set; }


    public void AddLetter(char letter)
    {
        Word += letter.ToString();
        _wordTXT.text = Word;
        CheckWord();
    }

    public void RemoveLetterAt(int index)
    {
        Word = Word.Remove(index, 1);
        _wordTXT.text = Word;
        CheckWord();
    }
    public int GetLengthOfWord()
    {
        if (Word == null)
        {
            return 0;
        }
        return Word.Length;

    }
    public void ClearWord()
    {
        Word = "";
        _wordTXT.text = Word;
    }
    private void CheckWord()
    {
        int count = GetLengthOfWord();
        if (count > 0)
        {
            if (Dictionary.WordsList.BinarySearch(Word) > 0)
            {
                _wordTXT.color = Palette.Green;
                IsRight = true;
                return;
            }
        }
        IsRight = false;
        _wordTXT.color = Palette.Red;
    }
}
