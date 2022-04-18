using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftPlayer : MonoBehaviour
{
    public static int leftPlayerScore;

    Vector2 pos;

    [SerializeField] GameObject ball;
    Vector3 ballLocation;

    float rectangleHeight;

    float targetYDir;

    private void Start()
    {
        transform.localPosition = new Vector3(transform.position.x, 0, 0);
    }

    private void Update()
    {
        pos = transform.position;

        if (Globals.gameMode == GameMode.Computer)
        {
            StartCoroutine(TargetCalculator());

            StartCoroutine(MoveToPosition());
        }
        else if (Globals.gameMode == GameMode.Local)
        {
            targetYDir = Input.GetAxis("WASD Vertical");

            pos.y = Mathf.Clamp(pos.y, -5.2f + rectangleHeight, 5.2f - rectangleHeight);
            pos.y += targetYDir * Time.deltaTime * 15;
            transform.position = pos;
        }
    }

    IEnumerator TargetCalculator()
    {
        if (pos.y > ball.transform.position.y)
        {
            targetYDir = -1;
        }
        else if (pos.y < ball.transform.position.y)
        {
            targetYDir = 1;
        }
        else
        {
            targetYDir = 0;
        }
        
        yield return new WaitForSeconds(Random.Range(4, 5));
    }

    IEnumerator MoveToPosition()
    {
        pos.y = Mathf.Clamp(pos.y, -5.2f + rectangleHeight, 5.2f - rectangleHeight);
        pos.y += targetYDir * Time.deltaTime * 15;
        transform.position = pos;

        yield return new WaitForSeconds(Random.Range(4, 5));
    }
}
