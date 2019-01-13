using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public int timeLeft = 60;
    public Text countdownText;
    public Text Wintext;
    public Text Counttext;


	// Use this for initialization
	void Start () {
        StartCoroutine("LoseTime");
		
	}
	
	// Update is called once per frame
	void Update () {
        countdownText.text = ("Time left:" + timeLeft);
        if (Counttext.text== "Count: 16".ToString()){
            StopCoroutine("LoseTime");

        }
        if (timeLeft <=0){
            StopCoroutine("LoseTime");
            countdownText.text = "Times up";
            Wintext.text = "You lose!";
            countdownText.enabled = false;
            
        }
		
	}
    private void OnTriggerEnter(Collider other){
        if (Wintext.text == "You lose!"){
            if (other.gameObject.CompareTag("pickup"))
            {
                other.gameObject.SetActive(true);
            }

        }
    }
    IEnumerator LoseTime(){
        while(true){
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
