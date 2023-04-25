
using UnityEngine.UI;
using UnityEngine;
using System;

public class LiveManager : MonoBehaviour
{
    [SerializeField]
    private Image _timerImg;
    [SerializeField]
    private TMPro.TMP_Text _time;

    private string _startTime;

    private void Start()
    {
        _startTime = DateTime.UtcNow.ToString();
        Debug.Log(_startTime);


        var d = DateTime.UtcNow.Subtract(DateTime.Parse("25.04.2023 11:10:27")).TotalSeconds;
        Debug.Log(d);
    }
}
