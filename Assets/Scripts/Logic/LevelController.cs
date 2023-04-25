using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    private Level _level;

    [SerializeField]
    private TMPro.TMP_Text _numberOfLevel;
    [SerializeField]
    private Image _image;

    void Awake()
    {
        _level = GetComponent<Level>();
        _numberOfLevel.text = (_level.Id + 1).ToString();
    }
    public bool GetPassed()
    {
        return _level.IsPassed;
    }
    public void SetStateOfLevel(bool isAllowed = false, bool isPassed = false)
    {

        _level.IsAllowed = isAllowed;
        _level.IsPassed = isPassed;
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
