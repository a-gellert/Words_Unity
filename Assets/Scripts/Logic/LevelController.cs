using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    private Level _level;

    [SerializeField]
    private TMPro.TMP_Text _numberOfLevel;
    [SerializeField]
    private Image _image;

    void Start()
    {
        _level = GetComponent<Level>();
        _numberOfLevel.text = (_level.Id + 1).ToString();
        SetStateOfLevel();
    }
    public void SetStateOfLevel()
    {

        if (_level.IsAllowed && !_level.IsPassed)
        {
            _image.color = Palette.BlueForMix;
        }
        else if (_level.IsPassed)
        {
            _image.color = Palette.CellGreen;
        }
    }



}
