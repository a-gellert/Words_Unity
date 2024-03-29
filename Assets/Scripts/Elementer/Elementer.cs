using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class Elementer : MonoBehaviour
{
    public static Elementer Instance;
    [SerializeField]
    GameObject _particle;
    private Vector3 _roof;
    private List<GameObject> _particles = new List<GameObject>();
    private List<GameObject> _elements = new List<GameObject>();
    private List<GameObject> _tempElements = new List<GameObject>();
    private List<GameObject> _removedElements = new List<GameObject>();
    private float _coefficient;
    private int _size;
    void Awake()
    {
        Instance = this;
    }
    public void ClearElements()
    {
        _elements = new List<GameObject>();
    }
    public void SetElement(GameObject element)
    {
        _elements.Add(element);
    }
    public void DeleteElements()
    {
        if (_elements != null && _elements.Count > 0)
        {

            _elements.ForEach(x => GameObject.Destroy(x));
            ClearElements();
        }
    }
    public void RemoveElements()
    {
        _particles = new List<GameObject>();
        _tempElements = new List<GameObject>(_elements);
        _roof = _elements.Last().transform.position;
        GetCoef();
        for (int i = 0; i < _size; i++)
        {
            int multi = 0;
            int countRemoved = 0;
            _removedElements = new List<GameObject>();
            for (int j = 0; j < _size; j++)
            {
                if (_elements[i + _size * j].GetComponentInChildren<Symbol>().IsRemoved)
                {
                    var obj = Instantiate(_particle, _elements[i + _size * j].transform.position, Quaternion.identity);
                    obj.GetComponent<ParticleController>().SetColor(_elements[i + _size * j].GetComponent<LetterManager>().GetColor());
                    _particles.Add(obj);
                    _elements[i + _size * j].GetComponent<LetterManager>().RefreshLetter(true);
                    _elements[i + _size * j].GetComponent<LetterManager>().SymbolRemoved(false);
                    _tempElements[i + _size * (_size - 1 - countRemoved)] = _elements[i + _size * j];
                    if ((i + _size * (j + 1)) < _size * _size)
                    {
                        multi++;
                    }
                    countRemoved++;

                }
                else if (!_elements[i + _size * j].GetComponentInChildren<Symbol>().IsRemoved)
                {
                    CalculateMoving(_elements[i + _size * j], multi);
                    _tempElements[i + _size * (j - multi)] = _elements[i + _size * j];

                }
            }
            if (countRemoved < 1)
            {
                continue;
            }
            int z = 0;
            for (int u = _size - countRemoved; u < _size; u++)
            {
                z++;
                _tempElements[i + _size * u].transform.position = new Vector3(_tempElements[i + _size * u].transform.position.x, _roof.y + _coefficient * z, _tempElements[i + _size * u].transform.position.z);
                _removedElements.Add(_tempElements[i + _size * u]);
            }

            FillRemoved(countRemoved);
        }
        foreach (var item in _particles)
        {
            item.GetComponent<ParticleController>().Play();
        }
        _elements = new List<GameObject>(_tempElements);
    }

    private void CalculateMoving(GameObject element, int multi)
    {
        if (multi == 0)
        {
            return;
        }
        var destination = _coefficient * multi;
        Vector3 target = new Vector3(element.transform.position.x, element.transform.position.y - destination, element.transform.position.z);
        Move(element, target);
    }

    private void Move(GameObject obj, Vector3 position)
    {
        obj.GetComponent<MoveAnimation>().StartMove(position);
    }

    private void FillRemoved(int multi)
    {
        foreach (var item in _removedElements)
        {
            CalculateMoving(item, multi);
        }
    }
    public void ClearSelected()
    {
        foreach (var item in _elements)
        {
            item.GetComponent<LetterManager>().SymbolChosen(false);
            item.GetComponent<LetterManager>().RefreshLetter(false);

        }
    }
    public void SetSize(int size)
    {
        _size = size;

    }
    private void GetCoef()
    {
        _coefficient = _elements[_size].transform.position.y - _elements[1].transform.position.y;
    }

}