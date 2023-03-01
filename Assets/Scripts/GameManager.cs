using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Luodaan staattinen GameManager luokan muuttuja instanssi.
    public static GameManager instanssi;
    public int pisteet;
    public int highscore = 0;
    // Eka level:n arvo on 1
    public int level = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        // Tekee tästä luokasta viitteen muuttujaan instanssi.
        instanssi = this;
        // Tätä luokkaa ei tuhota.
        DontDestroyOnLoad(this.gameObject);

        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Jos level arvo kasvaa viiteen, niin tallennetaan pisteet arvo tietueeseen Pisteet.
        if(level == 11) {
            // Tallentaa, jos pisteet on pienemmät, kuin edelliset
            // if(pisteet < PlayerPrefs.GetInt("Pisteet"))
            // {
                // pisteet = BallController.instanssi.putts;
                PlayerPrefs.SetInt("Pisteet", pisteet);
            // }


        }
        if (highscore < pisteet)
        {
            PlayerPrefs.SetInt("Highscore", pisteet);
        }

    }
}
