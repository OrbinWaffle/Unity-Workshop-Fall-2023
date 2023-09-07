using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class TagManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject gameOverScreen;
    bool isPlaying = true;
    float timeStarted;
    [SerializeField] NavMeshAgent NPC;
    float orgSpeed;
    float orgAcc;
    void Start()
    {
        timeStarted = Time.time;
        orgSpeed = NPC.speed;
        orgAcc = NPC.acceleration;
    }

    void Update()
    {
        if(isPlaying)
        {
            float elapsed = Time.time - timeStarted;
            int minutes = Mathf.FloorToInt(elapsed / 60F);
            int seconds = Mathf.FloorToInt(elapsed) % 60;
            int miliseconds = Mathf.FloorToInt(elapsed * 1000) % 1000;

            string formattedTime = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, miliseconds);
            timeText.text = formattedTime;

            NPC.speed = orgSpeed + elapsed/10;
            NPC.acceleration = orgAcc + elapsed/100;
        }
    }
    public void GameOver()
    {
        isPlaying = false;
        gameOverScreen.SetActive(true);
        FindObjectOfType<InputController>().canMove = false;
        FindObjectOfType<NPCController>().freeze = true;
        NPC.SetDestination(NPC.transform.position);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
