using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int damage = 1;
    public float speed;
    public GameObject effect;
    private Shake shake;

    private UIController ui;

    private void Start()
    {
        ui = FindObjectOfType<UIController>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shake.CamShake();
            if (ui != null)
            {
                ui.Damage(damage);
                SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.Hurt);
                Debug.Log("Player Damaged");
            }
            //other.GetComponent<Bow>().health -= damage;
            Instantiate(effect, transform.position, Quaternion.identity);
            //Debug.Log("Lives:" + other.GetComponent<Bow>().health);
            Destroy(gameObject);
        }
    }
}
