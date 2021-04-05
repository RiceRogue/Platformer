using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Astronaut");
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().MovePosition(player.transform.position);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Astronaut")
        {
            collision.gameObject.GetComponent<Player>().health--;
        }

    }
}
