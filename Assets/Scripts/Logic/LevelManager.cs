using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelController> _levels = new List<LevelController>();
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        foreach (var item in _levels)
        {
            Level.Levels.Add(item.GetComponent<Level>());
        }
    }
    public void LevelCompleted(int id)
    {
        Level.Levels[id].IsPassed = true;
        _levels[id].SetStateOfLevel();
        if (Level.Levels.Count > id + 1)
        {
            Level.Levels[id + 1].IsAllowed = true;
            _levels[id + 1].SetStateOfLevel();
        }
    }
}
