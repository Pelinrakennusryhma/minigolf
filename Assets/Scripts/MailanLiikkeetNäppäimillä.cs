using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailanLiikkeetNäppäimillä : MonoBehaviour
{
    // EI KÄYTÖSSÄ TÄLLÄHETKELLÄ!
    // EI KÄYTÖSSÄ TÄLLÄHETKELLÄ!
    // EI KÄYTÖSSÄ TÄLLÄHETKELLÄ!
    // EI KÄYTÖSSÄ TÄLLÄHETKELLÄ!
    // EI KÄYTÖSSÄ TÄLLÄHETKELLÄ!
    
    Rigidbody rb;
    Vector3 move;
    public float Vauhti = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Otetaan horizontal muuttujaan näppäinten A ja D / nuoli vasen ja nuoli oikea arvo
        move.x = Input.GetAxis("Horizontal");
        // Otetaan horizontal muuttujaan näppäinten A ja D / nuoli vasen ja nuoli oikea arvo
        move.z = Input.GetAxis("Vertical");
        move.y = 0;
    }

    private void FixedUpdate() {

            rb.MovePosition(rb.position + move * Vauhti * Time.fixedDeltaTime);
        
    }
}
