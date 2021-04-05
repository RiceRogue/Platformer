using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public GameObject player;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position ) <= 3)
        {

            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                SceneManager.LoadScene("Game");
            }

        }



    }
    




    
}
