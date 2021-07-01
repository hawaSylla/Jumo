using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestroy : MonoBehaviour
{
    public GameObject platformDesPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDesPoint = GameObject.Find("PlatDesPoint");    
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < platformDesPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
