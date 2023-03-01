using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    // Alustetaan AudioSourse m_MyAudioSource muuttuja
    AudioSource m_MyAudioSource;

    // Luodaan staattinen BallController luokan muuttuja instanssi
    public static BallController instanssi;
    // https://www.youtube.com/watch?v=1rwchBV61ys

    // Luodaa float maxPower muuttuja. Tämä muuttuja määrittää maksi voiman pallonlyöntiin
    public float maxPower;
    // Tämä säätää kääntymisen nopeuden
    public float changeAngelSpeed;
    // Tämä säätää lyöntisuunnan viivan pituuden
    public float lineLength;

    // Luodaan muuttuja joka ottaa vastaan sliderin
    public Slider powerSlider;

    // Tämä muuttuja pitää yllä lyöntejä ja näyttää ne
    public TextMeshProUGUI puttCountLabel;
    

    // Luodaan private line muuttuja LineRenderer objectille
    private LineRenderer line;

    // Luodaan private ball muuttuja Rigidbody objectille
    private Rigidbody ball;

    // Tämä pitää yllä kulmaa
    private float angle;

    // Tämä pitää yllä voimaa, joka perustuu aikaan
    private float powerUpTime;

    // Tämä ottaa vastaan voiman, joka syntyy powerUpTime / 1
    private float power;

    // Tämä pitää ylhäällä lyöntejä
    public int putts;

    void Start()
    {
        // Haetaan AudioSource m_MyAudioSource muuttujaan
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    
    void Awake()
    {
        // Hakee Rigidbodyn muuttujaan ball
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        // Hakee LineRenderer:n muuttujaan line
        line = GetComponent<LineRenderer>();
        
        instanssi = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Jos pallo on paikoillaan, sitä voi lyödä.
        // Ohjaaminen onnistuu A Ja D tai vaihtoehtoisesti vasen- ja oikeanuoli.
        // Space lyö palloa.
        if (ball.velocity.magnitude < 0.01f) {
            // Näytä viiva
            line.enabled = true;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Ottaa yhteyttä funktioon ChangeAngle(arovlla -1);,
                // tämä vaihtaa suuntaa.
                ChangeAngle(-1);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // Ottaa yhteyttä funktioon ChangeAngle(arovlla 1);,
                // tämä vaihtaa suuntaa.
                ChangeAngle(1);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Ottaa yhteyttä funktioon Putt();
                Putt();
                // Soittaa lyöntiäänen.
                m_MyAudioSource.Play();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                // Ottaa yhteyttä funktioon PowerUp();
                PowerUp(); 
            }
            // Ottaa yhteyttä UpdateLinePosition(); funktioon. Tämä hallitsee viivan paikan.
            UpdateLinePositions(); 
        }
        else
        {
            // Jos pallo liikkuu, niin piilotetaan viiva
            line.enabled = false;
        }

    }

    // Kulman säätäjä funktio.
    public void ChangeAngle(int direction)
    {
        angle += changeAngelSpeed * Time.deltaTime * direction;
    }

    // Viivan paikan päivittäjä
    private void UpdateLinePositions() {
        // Viivan aloituspiste. Muodostuu pallon paikasta
        line.SetPosition(0, transform.position);
        // Viivan lopetuspiste. Muodostuu pallon paikasta + kulmasta * pallosta eteenpäin kaselista * viivanpituus.
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * lineLength);
    }
    // Lyönnin toteuttaja 
    public void Putt()
    {
        // Pallon lyönti.
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower * power, ForceMode.Impulse);
        // Nollataan muuttujat.
        power = 0;
        powerSlider.value = 0;
        powerUpTime = 0;
        // Lisätään yksi lyönti.
        putts++;
        if(GameManager.instanssi != null) {
            // Lisätään GameManager luokan pisteet muuttujaan yksi lyönti lisää.
            GameManager.instanssi.pisteet++;
        }
        // Lisätään lyönti näytettävään tekstikenttään.
        puttCountLabel.text = putts.ToString();
        // Soitetaan lyöntiääni.
        m_MyAudioSource.Play();
    }

    // Lyönnin kasvattaja funktio.
    public void PowerUp()
    {
        // Kasvatetaan powerUpTime muuttujaa Time.deltaTime ajalla.
        powerUpTime += Time.deltaTime;
        // Lisätään power muuttujaan arvo powerUpTime jakamalla ja ottamalla siitä arvo 0-1.
        power = Mathf.PingPong(powerUpTime, 1);
        // Kasvattaa Slideria power muuttujalla
        powerSlider.value = power;
    }

    // Törmäyksen tutkija funktio. Ei käytössä!!
    void OnCollisionEnter(Collision collision)
    {
        // Jos törmättävä objeckti sisältää tag:n Maali, niin mennään if:n sisään
        if (collision.gameObject.tag == "Maali")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Pääsit maaliin!!");
        }
    }
}
