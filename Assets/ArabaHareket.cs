using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaHareket : MonoBehaviour
{


    bool oyunBitti = false;
    int puan = 0;

    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunBitti == false)
        GetComponent<Rigidbody>().AddForce(Vector3.left * 160, ForceMode.Force);
        else if(oyunBitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0,0,120,ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -120, ForceMode.Force);
        }

        if(GetComponent<Rigidbody>().position.x <= -910)
        {
            oyunBitti = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 3f);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.collider.tag == "Engel")
        {
            Invoke("restart", 3f);
            oyunBitti = true;
        }   
        if (collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }



    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunBitti = false;
    }


}
