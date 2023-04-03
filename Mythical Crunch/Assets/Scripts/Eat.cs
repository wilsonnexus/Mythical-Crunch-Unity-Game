using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Eat : MonoBehaviour
{
    public string Tag;
    public float Increase;

    public Text Letters;
    int Score = 0;

    private float nextActionTime = 0.0f;
    public float period = 20f;


    void Update()
    {
        if (Time.time > nextActionTime && transform.localScale.x > 1)
        {
            nextActionTime = Time.time + period;
            // execute block of code here
            transform.localScale -= new Vector3(Increase/3, Increase/3, Increase/3);
            //transform.localScale += new Vector3(-0.01F * Time.deltaTime * transform.localScale.x, -0.01F * Time.deltaTime * transform.localScale.x, -0.01F * Time.deltaTime * transform.localScale.x);
            if (Score != 0)
            {
                Score -= 1;
                Letters.text = "SCORE: " + Score;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == Tag)
        {
            transform.localScale += new Vector3(10*Increase, 10*Increase, 10*Increase);
            Destroy(other.gameObject);

            Score += 20;
            Letters.text = "SCORE: " + Score;
        }
    }
}
