using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private MoveAnimation _move;
    private void Start()
    {
        Launch();
    }
    public void Launch()
    {
        _move.StartMove(_target.position);
    }
}
