using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    private float startTime;
    private bool start = false;
    private bool startedTimer = false;
    private bool finished = false;

    IEnumerator WaitCountdown()
    {
        yield return new WaitForSeconds(3f);
        start = true;
    }

    void Start()
    {
        StartCoroutine(WaitCountdown());
    }

    void Update()
    {
        if (start)
        {
            if (!startedTimer)
            {
                startTime = Time.time;
                startedTimer = true;
            }
            else
            {
                if (finished)
                {
                    return;
                }

                float t = Time.time - startTime;

                string minute = ((int)t / 60).ToString();
                string second = (t % 60).ToString("f2");

                timerText.text = minute + ":" + second;
            }
        }
    }

    public void Finish()
    {
        finished = true;
    }
}
