using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle;
    public void Play()
    {
        _particle.Play();
        Destroy(gameObject, 1);
    }
    public void SetColor(Color color)
    {
        var main = _particle.main;
        main.startColor = color;
    }
}
