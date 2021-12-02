using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour
{
    public Text TextTimer;
    public float Waktu = 60;
    public bool GameAktif = true;
    public GameObject LoseCanvas;

    void SetTime()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    // Update is called once per frame
    private void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;

            }
        }

        if(GameAktif && Waktu == 0)
        {
            Debug.Log("Game Kalah");
            LoseCanvas.SetActive(true);
            GameAktif = false;
        }
        
        SetTime();
    }
}
