using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        speed = 6f;
        //transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Astronaut");
        //GetComponent<Rigidbody>().MovePosition(player.transform.position);

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.LookAt(player.transform.position + new Vector3(0,1f,0));
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.deltaTime);

        int playerLayer = LayerMask.GetMask("Player");

        bool RaycastHit = Physics.Raycast(transform.position, Vector3.forward, 1f, playerLayer);
        if (RaycastHit)
        {
            player.GetComponent<Player>().health--;
        }
    }


    
}
