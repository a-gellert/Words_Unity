using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance;


    [SerializeField]
    private Canvas _menuCanvas;
    void Awake()
    {
        Instance = this;

    }
    public void Show(bool state)
    {
        _menuCanvas.gameObject.SetActive(state);
    }
    public void OnPlay()
    {
        _menuCanvas.gameObject.SetActive(false);
        LevelUI.Instance.Show(true);
        LevelManager.Instance.SetState();
    }
}
