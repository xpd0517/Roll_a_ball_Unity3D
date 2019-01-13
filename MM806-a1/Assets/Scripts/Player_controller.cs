using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour {
    public float speed;
    public float jumpforce;
    public SphereCollider col;
    public Text Countdown;
    public Text Counttext;
    public Text Wintext;
    public Text Timer;
    public GameObject Explosion;
    private Rigidbody rb;
    public GameObject timer;
    private int count;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        Counttext.text = "Count: " + count.ToString();
        Wintext.text = "";


    }

    void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);
        rb.AddForce (movement* speed);
        Vector3 new_move = rb.velocity;


        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup")&&(Wintext.text !="You lose!")){

            other.gameObject.SetActive(false);
            count += 1;
            Counttext.text = "Count: " + count.ToString();
            Instantiate(Explosion, transform.position, transform.rotation);


        }
        if (count==2){
            timer.GetComponent<Countdown>().enabled=true;

        }
        if (count>=16){
            Wintext.text = "Congrats! You win!";
           


        }

    }
}
