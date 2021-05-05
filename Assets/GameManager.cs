using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject ballPrefab;
	public float timer = 30;

	private float spawnRate;

	public Text timerText;

	bool timeLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
    	timer -= Time.deltaTime;
        spawnRate = Random.Range(0.25f, 2f);
        if (timer <= 0) {
        	timeLeft = false;
        	timerText.text = "Time's Up!";
        } else {
    	    timerText.text = timer.ToString("0");
        }
    }

    IEnumerator SpawnBalls() {
    	while (timeLeft) {
    		yield return new WaitForSeconds(spawnRate);
    		Instantiate(ballPrefab, new Vector3(Random.Range(-16, 8), 10, Random.Range(-10, 10)), Quaternion.identity);
    	}
    }

}
