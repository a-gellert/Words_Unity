using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public static LevelUI Instance;


    [SerializeField]
    private Canvas _levelCanvas;
    void Awake()
    {
        Instance = this;
    }

    public void Show(bool state)
    {
        _levelCanvas.gameObject.SetActive(state);
    }
    public void OnLevel()
    {
        _levelCanvas.gameObject.SetActive(false);
        GameUI.Instance.Show(true);
    }
    public void OnExit()
    {
        _levelCanvas.gameObject.SetActive(false);
        MainMenuUI.Instance.Show(true);
    }
}
