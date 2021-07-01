using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGen : MonoBehaviour
{
    public GameObject wall;
    public Transform genPoint;
    public float distanceBtw;
    private float wallHeight;
    // Start is called before the first frame update
    void Start()
    {
        wallHeight = wall.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < genPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + wallHeight + distanceBtw, transform.position.z);

            Instantiate(wall,transform.position,transform.rotation);
        }
    }
}
