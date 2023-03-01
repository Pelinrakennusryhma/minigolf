using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YlöspäinLiikkuvaEste : MonoBehaviour
{

    public GameObject este;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.forward * speed * Time.deltaTime); 
  
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Katto") {
            Debug.Log("Alas");
            speed = -0.1f;
        }
        if (collision.gameObject.tag == "Lattia") {
            Debug.Log("Ylös");
            speed = 0.1f;
        }
    }
}
