using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSeuraa : MonoBehaviour
{
    public Transform player;
    public float x, y, z;

    private void Start()
    {
        transform.position = player.transform.position + new Vector3(x, y, z);

    }

    // Update is called once per frame
    void Update () {
        
        //transform.position = player.transform.position + new Vector3(x, y, z);
        
        Vector3 targetPos = player.transform.position + new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 10.0f* Time.deltaTime);

    }
}
