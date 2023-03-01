using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aloitusvalikko : MonoBehaviour
{
    public Text ennätysPisteet;
    void Start()
    {
        ennätysPisteet.text = LataaPisteet().ToString();
    }

    public void Pelaa()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Lopeta()
    {
        Application.Quit();
    }

        public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Leaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public int LataaPisteet()
    {
        return PlayerPrefs.GetInt("Pisteet");
    }

}
