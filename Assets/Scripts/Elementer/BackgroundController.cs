using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    Transform _firstSky;
    [SerializeField]
    Transform _secondSky;
    [SerializeField]
    Transform _cloud1;
    [SerializeField]
    Transform _cloud2;
    [SerializeField]
    Transform _cloud3;
    [SerializeField]
    Transform _cloud4;
    public float velocity;

    private void Start()
    {

    }
    void FixedUpdate()
    {
        _firstSky.Translate(velocity * Time.deltaTime, 0, 0);
        _secondSky.Translate(velocity * Time.deltaTime, 0, 0, Space.World);

        _cloud1.Translate(-velocity * _cloud1.transform.localScale.x * Time.deltaTime, 0, 0);
        _cloud2.Translate(-velocity * _cloud2.transform.localScale.x * Time.deltaTime, 0, 0);
        _cloud3.Translate(-velocity * _cloud3.transform.localScale.x * Time.deltaTime, 0, 0);
        _cloud4.Translate(-velocity * _cloud4.transform.localScale.x * Time.deltaTime, 0, 0);
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
        if (_cloud1.transform.position.x <= -6)
        {
            _cloud1.transform.position = new Vector3(6, Random.Range(0f, 4f), 10);
            _cloud1.transform.localScale = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.5f, 1f), 1);
        }
        if (_cloud2.transform.position.x <= -6)
        {
            _cloud2.transform.position = new Vector3(6, Random.Range(0f, 4f), 10);
            _cloud2.transform.localScale = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.5f, 1f), 1);
        }
        if (_cloud3.transform.position.x <= -6)
        {
            _cloud3.transform.position = new Vector3(6, Random.Range(0f, 4f), 10);
            _cloud3.transform.localScale = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.5f, 1f), 1);
        }
        if (_cloud4.transform.position.x <= -6)
        {
            _cloud4.transform.position = new Vector3(6, Random.Range(0f, 4f), 10);
            _cloud4.transform.localScale = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.5f, 1f), 1);
        }
    }
}
