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
        SetStateOfLevel();
    }
    private void SetStateOfLevel()
    {
        _numberOfLevel.text = _level.Id.ToString();
        if (_level.IsAllowed)
        {
            _image.color = Palette.BlueForMix;
        }
    }



}
