using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edsScript : MonoBehaviour
{
    public GameObject giftCloneTemplate;
    float turningSpeed = 90;
    float speed;
    float WalkingSpeed = 1;
    float RunningMultiplier = 1;
    Animator edsAnimator;
    // Start is called before the first frame update
    void Start()
    {
        edsAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        edsAnimator.SetBool("ISwalking", false);
        speed = 0;

        if (Input.GetKey(KeyCode.W))
        {
            speed = WalkingSpeed;
            transform.position += transform.forward * Time.deltaTime;
            edsAnimator.SetBool("ISwalking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed = -WalkingSpeed;
            transform.position -= transform.forward * Time.deltaTime;
            edsAnimator.SetBool("ISwalking", true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= RunningMultiplier;
            edsAnimator.SetBool("ISrunning", true);
        }

        else
        {
            edsAnimator.SetBool("ISrunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Roll left
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Pitch up
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(giftCloneTemplate, transform.position, transform.rotation);
        }
        transform.position += speed * transform.forward * Time.deltaTime;
    }
}
