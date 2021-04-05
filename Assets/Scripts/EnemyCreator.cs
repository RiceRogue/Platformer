using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public float timer;
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 12)
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            timer = 0;
        }
    }
}
