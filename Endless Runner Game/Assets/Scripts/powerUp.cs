using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public bool chai;
    public spawnPlatform speedScript;

    public Transform child;

    private float speed;
    public float speedScalar;

    public GameObject Shield;

    // Start is called before the first frame update
    void Start()
    {
        speedScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<spawnPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedScript.speed;
        transform.Translate(Vector3.back * speed * speedScalar * Time.deltaTime);
        child.Rotate(1, 0, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (chai == true)
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                speedScript.score += 250;
                speedScript.speed -= 0.4f;
                other.GetComponent<PlayerScript>().Milk();
                Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
            }
            else
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                Instantiate(Shield);
            }
            Destroy(gameObject, .5f);
        }
        else if (other.gameObject.tag == "Destroy")
            Destroy(gameObject);
    }
}
