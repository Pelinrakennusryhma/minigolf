using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakaisinMenuun : MonoBehaviour
{
    public void Takaisin()
    {
        SceneManager.LoadScene("Valikko");
    }
}
