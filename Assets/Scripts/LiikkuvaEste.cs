using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikkuvaEste : MonoBehaviour
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
        transform.Translate (Vector3.right * speed * Time.deltaTime); 
  
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "OikeaSeinä") {
            Debug.Log("Vasemmalle");
            speed = 0.1f;
        }
        if (collision.gameObject.tag == "VasenSeinä") {
            Debug.Log("Oikealle");
            speed = -0.1f;
        }
    }
    
}
