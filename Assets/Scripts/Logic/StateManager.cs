using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private WordController _wordController;
    [SerializeField]
    private FieldManager _fieldManager;

    private Level _currentLevel;

    public int CurrentScore { get; private set; }
    public int ScoreToWin { get; private set; }
    public int NumberOfWords { get; private set; }
    public int Lives { get; private set; } = 5;
    public int Coins { get; private set; } = 0;
    public int Experience { get; private set; } = 0;
    public string LongestWord { get; private set; } = "";

    public static StateManager Instance;


    void Awake()
    {
        Instance = this;
    }

    public void EnterWord()
    {
        if (WordController.IsRight)
        {
            _fieldManager.RemoveEnteredLetters();
            Elementer.Instance.RemoveElements();
            if (_wordController.Word.Length > LongestWord.Length)
            {
                LongestWord = _wordController.Word;
            }
            _wordController.ClearWord();
            CurrentScore += Picker.CurrentScore;
            NumberOfWords--;
            Picker.Refresh();
            CheckWinLose();
            WordController.IsRight = false;
        }
    }

    public void ClearWord()
    {
        _wordController.ClearWord();
        Elementer.Instance.ClearSelected();
        Picker.Refresh();
        Letters.Symbols = new List<Symbol>();
    }
    public void SetCurrentLevel(Level level)
    {
        _currentLevel = level;
        LongestWord = "";
        RestartLevel();
    }
    public void RestartLevel()
    {
        NumberOfWords = _currentLevel.MaxWords;
        ScoreToWin = _currentLevel.ScoreToWin;
        CurrentScore = 0;
        FieldManager.realSize = _currentLevel.Size;
        _wordController.ClearWord();
        Elementer.Instance.DeleteElements();
        _fieldManager.InitField();
    }
    private void CheckWinLose()
    {
        if (CurrentScore >= ScoreToWin)
        {
            GameUI.Instance.WinShow();
            LevelManager.Instance.LevelCompleted(_currentLevel.Id);
        }
        else if (NumberOfWords == 0)
        {
            GameUI.Instance.LoseShow();
            if (Lives >= 0)
            {
                Lives--;
            }
        }
    }
}