using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameChecker : MonoBehaviour
{
    private int playersInZone;

    [SerializeField] private TMP_Text startcountText;

    [SerializeField] private float timeToStart = 3f;
    private float startCounter;

    void Update()
    {
        if (playersInZone > 1 && playersInZone == GameManager.Instance.activePlayers.Count)
        {
            
            if (!startcountText.gameObject.activeInHierarchy)
            {
                AudioManager.Instance.PlaySFX(0);
            }
            

            startcountText.gameObject.SetActive(true);

            startCounter -= Time.deltaTime;

            startcountText.text = Mathf.CeilToInt(startCounter).ToString();

            if (startCounter <= 0)
            {
                GameManager.Instance.StartFirstRound();
            }
        }
        else
        {
            startcountText.gameObject.SetActive(false);
            startCounter = timeToStart;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playersInZone++;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playersInZone--;

        }
    }
}

