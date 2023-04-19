using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    Transform _firstSky;
    [SerializeField]
    Transform _secondSky;
    public float velocity;
    private Vector3 _target;
    void Start()
    {
        _target = new Vector3(19, 0, 10);
    }

    void FixedUpdate()
    {
        _firstSky.Translate(velocity * Time.deltaTime, 0, 0);
        _secondSky.Translate(velocity * Time.deltaTime, 0, 0, Space.World);
    }
    void Update()
    {
        if (_firstSky.transform.position.x >= 19)
        {
            _firstSky.transform.position = new Vector3(-19, 0, 10);
        }
        if (_secondSky.transform.position.x >= 19)
        {
            _secondSky.transform.position = new Vector3(-19, 0, 10);
        }
    }
}
