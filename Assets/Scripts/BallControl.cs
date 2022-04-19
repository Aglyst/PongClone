using System;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] int ballSpeed = 7;
    int initialLaunchDirection = 0;
    float angle;

    public event Action OnHit;
    public event Action OnLeftScore;
    public event Action OnRightScore;

    public Vector2 Direction { get { return GetComponent<Rigidbody2D>().velocity; } }


    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(BallMover() * ballSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (transform.position == Vector3.zero)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(BallMover() * ballSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Left Collider")
        {
            OnRightScore();
            initialLaunchDirection = 1;
        }
        else if (collision.gameObject.name == "Right Collider")
        {
            OnLeftScore();                                          // TODO: Possibly Null-Check Action Calls
            initialLaunchDirection = 0;
        }

        transform.position = Vector3.zero;
    }

    private Vector2 BallMover()
    {
        angle = 0;

        if (initialLaunchDirection == 1)
        {
            angle = UnityEngine.Random.Range((5 * Mathf.PI)/3, (7 * Mathf.PI)/3);
        }
        else if (initialLaunchDirection == 0)
        {
            angle = UnityEngine.Random.Range((2 * Mathf.PI)/3, (4 * Mathf.PI)/3);
        }
        else
        {
            Debug.Log("Trig Error | BallControl.cs");
        }

        #region Old If Statement
        /*
        int choice = Random.Range(0, 2);

        if (choice == 0 && initialLaunchDirection == 0)
        {
            angle = Random.Range(0, Mathf.PI / 3);
        }
        else if (choice == 1 && initialLaunchDirection == 0)
        {
            angle = Random.Range((5 * Mathf.PI) / 3, 2 * Mathf.PI);
        }
        else if (choice == 0 && initialLaunchDirection == 1)
        {
            angle = Random.Range((2 * Mathf.PI) / 3, Mathf.PI);
        }
        else if (choice == 1 && initialLaunchDirection == 1)
        {
            angle = Random.Range(Mathf.PI, (4 * Mathf.PI) / 3);
        }
        else
        {
            Debug.Log("Error");
        }
        */
        #endregion

        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
