using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerTeksti;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countUp;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Kokonaisluku, "0");
        timeFormats.Add(TimerFormats.Kymmenesosa, "0.0");
        timeFormats.Add(TimerFormats.Sadasosa, "0.00");
        timeFormats.Add(TimerFormats.Tuhannesosa, "0.000");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;

        if (hasLimit && ((countUp && currentTime <= timerLimit) || (!countUp && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerTeksti.color = Color.red;
            enabled = false;
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerTeksti.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
}

public enum TimerFormats
{
    Kokonaisluku,
    Kymmenesosa,
    Sadasosa,
    Tuhannesosa
}
