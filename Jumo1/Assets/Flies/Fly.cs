using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public int score = 1;
    public GameObject effect;
    //public float speed;
    private UIController ui;

    void Awake()
    {
    }

    private void Start()
    {
        ui = FindObjectOfType<UIController>();
        score = 1;
    }

    private void Update()
    {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if(ui != null)
            {
                ui.ScoreAddPoint(score);
                SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.Collect);
            }
            //other.GetComponent<Bow>().flyScore += score;
            Instantiate(effect, transform.position, Quaternion.identity);
            //Debug.Log("Score:" + other.GetComponent<Bow>().flyScore);
            Destroy(gameObject);
        }
    }
}
