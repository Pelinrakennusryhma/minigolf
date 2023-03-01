using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maali : MonoBehaviour
{
    // Pitää yllä muuttujaa leveliä johon merkataan seuraavaa kentän nimi.
    public string leveli;

    // Törmäyksen tutkiva funktio
    void OnCollisionEnter(Collision collision)
    {
        // Jos Pelaaja tag osuu...
        if (collision.gameObject.tag == "Pelaaja")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Pääsit maaliin!!");
            if(GameManager.instanssi != null) {
                // Kasvattaa luokan GameManager muuttuja level arvoa yhdellä.
                GameManager.instanssi.level++;    
            }
            
            // Lataa seuraavan kentän.
            SceneManager.LoadScene(leveli);
        }
    }
}
