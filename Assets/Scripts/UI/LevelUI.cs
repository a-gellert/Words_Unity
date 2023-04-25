using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static LevelUI Instance;


    [SerializeField]
    private Canvas _levelCanvas;
    [SerializeField]
    private TMPro.TMP_Text _livesTXT;
    [SerializeField]
    private TMPro.TMP_Text _coinsTXT;
    [SerializeField]
    private Image _soundStateImg;
    [SerializeField]
    private Image _musicStateImg;
    [SerializeField]
    private Image _pausePanel;
    void Awake()
    {

        Instance = this;
    }
    void Start()
    {
        RefreshImages();
    }
    public void Show(bool state)
    {
        _levelCanvas.gameObject.SetActive(state);
        _livesTXT.text = StateManager.Instance.Lives.ToString();
        _coinsTXT.text = StateManager.Instance.Coins.ToString();
    }
    public void OnLevel()
    {
        if (StateManager.Instance.Lives > 0)
        {
            _levelCanvas.gameObject.SetActive(false);
            GameUI.Instance.Show(true);
        }

    }
    public void OnPause()
    {
        _pausePanel.gameObject.SetActive(true);
        Picker.IsOff = true;
    }
    public void OnResume()
    {
        _pausePanel.gameObject.SetActive(false);
        Picker.IsOff = false;
    }
    public void OnExit()
    {
        Application.Quit();
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
