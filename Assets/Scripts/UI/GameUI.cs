using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public static GameUI Instance;

    [SerializeField]
    private Canvas _gameCanvas;
    [SerializeField]
    private Image _pausePanel;
    [SerializeField]
    private Image _WinLosePanel;
    [SerializeField]
    private Image _WinPanel;
    [SerializeField]
    private Image _LosePanel;
    [SerializeField]
    private Image _soundStateImg;
    [SerializeField]
    private Image _musicStateImg;


    [SerializeField]
    TMPro.TMP_Text _scoreTXT;
    [SerializeField]
    TMPro.TMP_Text _longestWordTXT;
    [SerializeField]
    TMPro.TMP_Text _wordsTXT;

    void Awake()
    {

        Instance = this;
    }
    void Start()
    {
        RefreshImages();
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnExit();
            }
        }
    }

    public void Show(bool state)
    {
        _gameCanvas.gameObject.SetActive(state);
        _pausePanel.gameObject.SetActive(false);
        _scoreTXT.text = $"{StateManager.Instance.CurrentScore.ToString()}/{StateManager.Instance.ScoreToWin.ToString()}";
        _wordsTXT.text = StateManager.Instance.NumberOfWords.ToString();
        Picker.IsOff = !state;
    }

    public void OnEnter()
    {
        StateManager.Instance.EnterWord();
        _scoreTXT.text = $"{StateManager.Instance.CurrentScore.ToString()}/{StateManager.Instance.ScoreToWin.ToString()}";
        _wordsTXT.text = StateManager.Instance.NumberOfWords.ToString();
    }
    public void OnDelete()
    {
        StateManager.Instance.ClearWord();
    }
    public void OnPauseMenu()
    {
        _pausePanel.gameObject.SetActive(true);
        Picker.IsOff = true;

    }
    public void OnResume()
    {
        _pausePanel.gameObject.SetActive(false);
        _WinLosePanel.gameObject.SetActive(false);
        Picker.IsOff = false;
    }
    public void OnRestart()
    {

        if (StateManager.Instance.Lives > 0)
        {
            StateManager.Instance.SubstractLives();
            StateManager.Instance.RestartLevel();
            _pausePanel.gameObject.SetActive(false);
            _WinLosePanel.gameObject.SetActive(false);
            _scoreTXT.text = $"{StateManager.Instance.CurrentScore.ToString()}/{StateManager.Instance.ScoreToWin.ToString()}";
            _wordsTXT.text = StateManager.Instance.NumberOfWords.ToString();
            Picker.IsOff = false;
        }
        else
        {
            OnExit();
        }

    }
    public void OnExit()
    {
        Picker.IsOff = false;
        _gameCanvas.gameObject.SetActive(false);
        _WinLosePanel.gameObject.SetActive(false);
        LevelUI.Instance.Show(true);
    }

    public void WinShow()
    {
        Picker.IsOff = true;
        _WinLosePanel.gameObject.SetActive(true);
        _LosePanel.gameObject.SetActive(false);
        _WinPanel.gameObject.SetActive(true);
        _longestWordTXT.text = StateManager.Instance.LongestWord;
    }
    public void LoseShow()
    {
        Picker.IsOff = true;
        _WinLosePanel.gameObject.SetActive(true);
        _LosePanel.gameObject.SetActive(true);
        _WinPanel.gameObject.SetActive(false);
    }


    public void OnSound()
    {
        SoundManager.Instance.OnSound();
        RefreshImages();
    }
    public void OnMusic()
    {
        SoundManager.Instance.OnMusic();
        RefreshImages();
    }

    private void RefreshImages()
    {
        if (SoundManager.Instance.MusicIsOn)
        {
            _musicStateImg.color = Palette.CellGreen;
        }
        else
        {
            _musicStateImg.color = Palette.CellRed;
        }
        if (SoundManager.Instance.SoundIsOn)
        {
            _soundStateImg.color = Palette.CellGreen;
        }
        else
        {
            _soundStateImg.color = Palette.CellRed;
        }
    }
}
