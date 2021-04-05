using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingTaxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        int platformLayer = LayerMask.GetMask("Player");

        bool RaycastBounce = Physics.Raycast(transform.position, Vector3.up, 5f, platformLayer);

        if (RaycastBounce) {
            GameObject.Find("Astronaut").GetComponent<Player>().moveDirection.y += 5f;
        }
    }
}
