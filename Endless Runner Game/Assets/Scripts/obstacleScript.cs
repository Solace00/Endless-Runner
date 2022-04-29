using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    public float speed;
    public float speedScalar;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("GameController").GetComponent<spawnPlatform>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.FindGameObjectWithTag("GameController").GetComponent<spawnPlatform>().speed;
        transform.Translate(Vector3.back * speed * speedScalar * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerScript>().hp -= damage;
            gameObject.GetComponent<AudioSource>().enabled = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<spawnPlatform>().speed *= 0.5f;
        }
    }
}
