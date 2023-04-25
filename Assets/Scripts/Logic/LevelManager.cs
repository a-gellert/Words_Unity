using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelController> _levels = new List<LevelController>();
    public List<bool> levelsState = new List<bool>();
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Level temp;
        foreach (var item in _levels)
        {
            temp = item.GetComponent<Level>();
            levelsState.Add(temp.IsPassed);
        }
        if (StateManager.Instance.LevelsState != null)
        {
            levelsState = StateManager.Instance.LevelsState;
        }
    }
    public void SetState()
    {
        for (int i = 0; i < levelsState.Count; i++)
        {
            if (levelsState[i])
            {
                LevelCompleted(i);
            }
        }
    }
    public List<bool> GetState()
    {
        levelsState = new List<bool>();
        foreach (var item in _levels)
        {
            levelsState.Add(item.GetComponent<Level>().IsPassed);
        }
        return levelsState;
    }
    public void LevelCompleted(int id)
    {
        _levels[id].SetStateOfLevel(true, true);
        if (_levels.Count > id + 1)
        {
            if (!_levels[id + 1].GetPassed())
            {
                _levels[id + 1].SetStateOfLevel(true);
            }
        }
    }
}
