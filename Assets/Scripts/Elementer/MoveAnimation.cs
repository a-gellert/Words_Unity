using System.Collections;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    IEnumerator MoveCoroutine(float destination)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / destination)
        {
            transform.position = Vector3.Lerp(_startPosition, _endPosition, curve.Evaluate(i));

            yield return null;
        }

        transform.position = _endPosition;
    }
    public void StartMove(Vector3 endPosition)
    {
        _startPosition = transform.position;
        _endPosition = endPosition;
        StartCoroutine(MoveCoroutine(0.5f));
    }
}
