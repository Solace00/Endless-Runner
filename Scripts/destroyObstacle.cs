using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObstacle : MonoBehaviour
{
    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            Destroy(other.gameObject);

        if (other.gameObject.tag == "Road")
            other.transform.position = spawner.position + new Vector3(6.25f, 0, 0);
    }
}
