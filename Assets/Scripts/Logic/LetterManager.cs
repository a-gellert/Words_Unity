using UnityEngine;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{

    [SerializeField]
    private TMPro.TMP_Text _symbolTXT;
    [SerializeField]
    private TMPro.TMP_Text _modifierTXT;
    [SerializeField]
    private TMPro.TMP_Text _bonusTXT;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Symbol _symbol;
    [SerializeField]
    private Transform _data;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [SerializeField]
    private Animator _animator;

    private Color _currentColor;

    public void SetValues(bool refresh, char symbol)
    {

        if (refresh)
        {
            _symbol.SymbolValue = symbol;
        }
        _symbol.IsChoosen = false;
        _symbol.IsRemoved = false;
        _symbolTXT.text = _symbol.SymbolValue.ToString();
        _animator.SetBool("IsPick", false);
        _symbol.Modifier = GetModifier(_symbol.SymbolValue);
        _currentColor = _image.color;
        _modifierTXT.text = _symbol.Modifier.ToString();

        _symbol.Bonus = GetBonus();
        if (_symbol.Bonus == 1)
        {
            _bonusTXT.gameObject.SetActive(false);
        }
        else
        {
            _bonusTXT.gameObject.SetActive(true);
            _bonusTXT.text = _symbol.Bonus.ToString();
        }
    }

    public bool PickLetter(int index)
    {
        if (_symbol.IsChoosen)
        {
            _symbol.IsChoosen = false;
            _image.color = _currentColor;
            RecountIndexes();
            _animator.SetBool("IsPick", false);

            return false;
        }
        _image.color = Palette.CellRed;
        _symbol.IdInWord = index;
        _symbol.IsChoosen = true;
        Letters.Symbols.Add(_symbol);
        _animator.SetBool("IsPick", true);
        return true;
    }

    private int GetModifier(char symbol)
    {
        if (Frequency.OneModif.Contains(symbol))
        {
            _image.color = Palette.CellAqua;
            return 1;
        }
        if (Frequency.TwoModif.Contains(symbol))
        {
            _image.color = Palette.CellBlue;
            return 2;
        }
        if (Frequency.ThreeModif.Contains(symbol))
        {
            _image.color = Palette.CellGreen;
            return 3;
        }
        if (Frequency.FourModif.Contains(symbol))
        {
            _image.color = Palette.CellYellow;
            return 4;
        }
        if (Frequency.FiveModif.Contains(symbol))
        {
            _image.color = Palette.CellPink;
            return 5;
        }
        return 1;
    }
    private int GetBonus()
    {
        // if (Random.Range(0, 11) > 9)
        // {
        //     return Random.Range(2, 4);
        // }
        return 1;
    }

    private void RecountIndexes()
    {
        Letters.Symbols.RemoveAt(_symbol.IdInWord);
        for (int i = 0; i < Letters.Symbols.Count; i++)
        {
            Letters.Symbols[i].IdInWord = i;
        }
    }

    public void RefreshLetter(bool state)
    {
        char ch = (char)Random.Range(65, 91);
        SetValues(state, ch);
    }
    public void SymbolRemoved(bool state)
    {

        _symbol.IsRemoved = state;
    }
    public void SymbolChosen(bool state)
    {

        _symbol.IsChoosen = state;
    }
    public bool GetStateRemoved()
    {
        return _symbol.IsRemoved;
    }

    public void ShowParticle()
    {
        _particleSystem.Play();
    }
}
