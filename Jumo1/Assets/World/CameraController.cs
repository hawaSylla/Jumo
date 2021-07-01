using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Bow thePlayer;
    private Vector3 lastPlayerPos;
    private float distanceToMove;

    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Bow>();
        lastPlayerPos = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        distanceToMove = thePlayer.transform.position.y - lastPlayerPos.y;

        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);

        lastPlayerPos = thePlayer.transform.position;
    }
}
