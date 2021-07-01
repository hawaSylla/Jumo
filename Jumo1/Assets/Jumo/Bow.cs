using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public static Bow instance;

    //public int health = 3;

    //public int flyScore = 0;

    public float launchForce;

    public Rigidbody2D rb;
    public Transform jPosition;
    public GameObject point;
    GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private bool canJump;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numOfPoints];
        for(int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(point, jPosition.position, Quaternion.identity);
        }

    }


    //player controls

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPos = transform.position;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = mousePosition - bowPos;

        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }

            //checking if player is still in gamespace
            if(rb.position.x <= -5 || rb.position.x >= 5)
            {
            FindObjectOfType<GameManager>().GameOver();
            }

        //if(health <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    public void Jump()
    {

        if (canJump == true)
        {
            rb.velocity = transform.right * launchForce;
            rb.constraints = RigidbodyConstraints2D.None;

        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)jPosition.position + (direction.normalized * launchForce * t) * .5f * Physics2D.gravity * (t * t);
            return position;
    }


    //sticky functions

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag != "Enemies")
        {

            SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.Land);

            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            canJump = true;
        }

        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag != "Player")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            canJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag != "Player")
        {
            canJump = true;
        }
    }

}
