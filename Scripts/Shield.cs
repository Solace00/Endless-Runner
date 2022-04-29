using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7f);
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            other.GetComponent<obstacleScript>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 20);
            Destroy(other.gameObject, 1.5f);
        }
    }
}
