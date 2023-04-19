
using UnityEngine;

public class Picker : MonoBehaviour
{

    [SerializeField]
    WordController _wordController;

    public static bool IsOff { get; set; } = false;
    public static int CountOfLetter { get; set; } = 0;
    public static int CurrentScore { get; private set; } = 0;

    void Update()
    {
        if (IsOff)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Symbol")
            {
                CountOfLetter = _wordController.GetLengthOfWord();
                var symbol = hit.collider.gameObject.GetComponent<Symbol>();
                if (symbol.GetComponentInParent<LetterManager>().PickLetter(CountOfLetter))
                {
                    _wordController.AddLetter(symbol.SymbolValue);
                    CurrentScore += symbol.Modifier;
                }
                else
                {
                    _wordController.RemoveLetterAt(symbol.IdInWord);
                    CurrentScore -= symbol.Modifier;
                }
            }
            if (hit.collider != null && hit.collider.tag == "Level" && hit.collider.gameObject.GetComponent<Level>().IsAllowed)
            {
                StateManager.Instance.SetCurrentLevel(hit.collider.GetComponent<Level>());
                LevelUI.Instance.OnLevel();
            }
        }
    }

    public static void Refresh()
    {
        CurrentScore = 0;
    }
}
