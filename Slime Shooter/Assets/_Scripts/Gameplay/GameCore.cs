using System.Collections;
using UnityEngine;
using TMPro;

public class GameCore : MonoBehaviour
{
    public int maxType = 0;
    public int balloonQtd;

    [SerializeField] private GameObject[] slimes;

    [SerializeField] private SpawnTargets spawnTargets;
    [SerializeField] private TextMeshProUGUI waveText;
    private int waveIndex = 0;
    private int spawnQtd;
    private bool canCall;
    private bool spawnBalloons;
    private float spawnDelay = 4.0f;

    private void Start()
    {
        slimes[0].SetActive(true);
        canCall = true;
    }

    private void Update()
    {
        if(canCall)
        {
            canCall = false;
            waveIndex++;
            StartCoroutine(CallNextWave());
        }

        if(spawnBalloons)
        {
            if (waveIndex < 13)
            {
                if (balloonQtd <= 0)
                {
                    spawnBalloons = false;
                    canCall = true;
                }
                if (spawnQtd > 0)
                {
                    spawnDelay -= Time.deltaTime;
                    if (spawnDelay <= 0)
                    {
                        spawnQtd--;
                        spawnDelay = 1.5f;
                        spawnTargets.Spawn();
                    }
                }
            }
            else
            {
                spawnDelay -= Time.deltaTime;
                if (spawnDelay <= 0)
                {
                    spawnQtd--;
                    spawnDelay = 2.0f;
                    spawnTargets.Spawn();
                }
            }
        }
    }

    private void NextWave()
    {
        switch (waveIndex)
        {
            case 1:
                spawnQtd = 3;
                break;

            case 2:
                spawnQtd = 5;
                break;

            case 3:
                slimes[1].SetActive(true);
                maxType++;
                spawnQtd = 5;
                break;

            case 4:
                spawnQtd = 5;
                break;

            case 5:
                slimes[2].SetActive(true);
                maxType++;
                spawnQtd = 6;
                break;
            case 6:                
                spawnQtd = 6;
                break;

            case 7:
                spawnQtd = 6;
                break;

            case 8:
                slimes[3].SetActive(true);
                maxType++;
                spawnQtd = 7;
                break;

            case 9:                
                spawnQtd = 7;
                break;

            case 10:                
                spawnQtd = 7;
                break;

            case 11:
                slimes[4].SetActive(true);
                maxType++;
                spawnQtd = 7;
                break;

            case 12:
                spawnQtd = 8;
                break;

            case 13:
                spawnQtd = 8;
                break;
        }
        balloonQtd = spawnQtd;
        spawnBalloons = true;
        spawnQtd--;
        spawnDelay = 2.0f;
        spawnTargets.Spawn();
    }

    private IEnumerator CallNextWave()
    {
        yield return new WaitForSeconds(2.0f);
        waveText.gameObject.SetActive(true);
        if (waveIndex < 13)
        {
            waveText.text = "WAVE " + waveIndex.ToString();
        }
        else
        {
            waveText.text = "INFINITE WAVE";
        }
        yield return new WaitForSeconds(2.0f);

        if (waveIndex < 13)
        {
            waveText.text = "GET READY!";
        }
        else
        {
            waveText.text = "GOOD LUCK!";
        }
        yield return new WaitForSeconds(2.0f);

        waveText.gameObject.SetActive(false);
        NextWave();
    }
}