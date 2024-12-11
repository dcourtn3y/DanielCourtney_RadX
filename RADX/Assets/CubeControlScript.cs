using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CubeControlScript : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 5;
    float explosionRadius = 5;
    float explosionStrength = 1000;

    public int score = 0;
    public int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * jumpForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * jumpForce * Time.deltaTime);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Victim")
        {
            AddScore(1);
        }
        VictimScript victimScript = collision.gameObject.GetComponent<VictimScript>();

        Collider[] allVictims = Physics.OverlapSphere(transform.position + Vector3.down, explosionRadius);

        foreach (Collider collider in allVictims) {
            VictimScript newVictim = collider.gameObject.AddComponent<VictimScript>();
        

            if (newVictim != null)
            {
                newVictim.Bump(explosionStrength, transform.position + Vector3.down, explosionRadius);
            }
        }
        //if (collision.gameObject.name == "Victim")
        //{
        //    Rigidbody victimRB = collision.gameObject.GetComponent<Rigidbody>();
        //    if (victimRB != null)
        //    {
        //        victimRB.AddExplosionForce(10000, transform.position + Vector3.down, 5);
        //    }
        //}
    }
   // print(collision.gameObject.name);
}
