using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int hp = 3;
    private int pos = 1;
    private float inputDelay = 0;

    public Text hpDisplay;

    //Player jump
    public bool jump = false;
    private Rigidbody myPhy;
    public float jForce;
    public float baseJForce = 350;
    public float milkTime;

    //Character Animations
    public Animator myAnim;
    public Transform meshTransform;

    // Start is called before the first frame update
    void Start()
    {
        myPhy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        HP();

        if (milkTime < Time.time)
        {
            jForce = baseJForce;
        }

        meshTransform.position = transform.position + new Vector3(0, -1, 0.5f);
        meshTransform.rotation = transform.rotation;
        myAnim.SetBool("Jump", jump);
    }

    public void Milk()
    {
        jForce = 450;
        milkTime = Time.time + 10;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jump == false)
        {
            myPhy.AddForce(Vector3.up * jForce);
            jump = true;            
        }
    }

    void HP()
    {
        if (hp <= 0)
            GameObject.FindGameObjectWithTag("GameController").GetComponent<spawnPlatform>().EndGame();

        hpDisplay.text = "HP: " + hp.ToString();
    }

    void Movement()
    {
        if (inputDelay < Time.time)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (pos < 2)
                {
                    pos++;
                    inputDelay = Time.time + 0.5f;
                }
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (pos > 0)
                {
                    pos--;
                    inputDelay = Time.time + 0.5f;
                }
            }
        }

        switch (pos)
        {
            case 0:
                transform.position = new Vector3(-3, transform.position.y, 0);
                break;
            case 1:
                transform.position = new Vector3(0, transform.position.y, 0);
                break;
            case 2:
                transform.position = new Vector3(3, transform.position.y, 0);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
    }
}
