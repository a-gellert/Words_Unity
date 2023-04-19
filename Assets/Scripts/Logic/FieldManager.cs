using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static readonly int INIT_SIZE = 5;
    public static readonly int FIELD_EDGE_SIZE = 1000;
    public static int realSize = 5;
    private float _cef;

    [SerializeField]
    private GameObject _letterPrefab;



    public void InitField()
    {
        _cef = (float)INIT_SIZE / (float)realSize;
        float offset = FIELD_EDGE_SIZE / INIT_SIZE * _cef;
        Elementer.Instance.ClearElements();
        for (int i = 0; i < realSize; i++)
        {
            for (int j = 0; j < realSize; j++)
            {
                var obj = GameObject.Instantiate(_letterPrefab);
                obj.transform.SetParent(this.transform);
                obj.transform.localScale = new Vector3(_cef, _cef, _cef);
                obj.transform.localPosition = new Vector3(j * offset - FIELD_EDGE_SIZE / 2 + FIELD_EDGE_SIZE / (realSize * 2), i * offset - FIELD_EDGE_SIZE / 2 + FIELD_EDGE_SIZE / (realSize * 2), 0);
                obj.GetComponent<LetterManager>().SetValues();
                Elementer.Instance.SetElement(obj);
            }
        }
        Elementer.Instance.SetCoef(realSize);
    }

    public void RemoveEnteredLetters()
    {
        Letters.Symbols.ForEach(x =>
        {
            x.IsRemoved = true;
            x.IsChoosen = false;
        });
        ClearIndexes();
    }

    private void ClearIndexes()
    {
        Letters.Symbols = new List<Symbol>();
    }
}
