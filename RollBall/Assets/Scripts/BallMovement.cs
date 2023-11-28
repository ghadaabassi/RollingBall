using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour
{   
    public Rigidbody rg;
    private float speed = 400.0f;
    public int score;
    public TMP_Text txt;
    AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mvh = Input.GetAxis("Horizontal");
        float mvv = Input.GetAxis("Vertical");
        Vector3 mvr=new Vector3(mvh,0 ,mvv);
        rg.AddForce(mvr * speed * Time.deltaTime);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yellow")
        {
            Destroy(other.gameObject);
            score += 1;
            txt.text = "Score : " + score;
            audiosrc.Play();
      }
  

        if (other.gameObject.tag == "purple")
        {
            Destroy(other.gameObject);
            score -= 1;
            txt.text = "Score : " + score;
            audiosrc.Play();
        }

    }
}
