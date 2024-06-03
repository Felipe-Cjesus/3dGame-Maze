using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    PlayerAnimated player;
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (player.transform.position.x >= GameController.checkPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                player.transform.position, (speed * Time.deltaTime));
        }
        */

        if (player.transform.position.x >= -30 && player.transform.position.x <= 0)
        {
            followPlayer();
            
        }

        if (player.transform.position.x >= 0 && player.transform.position.x < 20)
        {
            followPlayer();
           
        }

        if (player.transform.position.x >= 20)
        {
            followPlayer();
          
        }

    }

    public void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
               player.transform.position, (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.tag == "Player") {
           
            collision.gameObject.GetComponent<Rigidbody>()
                .AddForce(new Vector3(0f,0f, 500f));

            GameController.removeLife();
        }
        */
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "GunShot")
        {
            Destroy(this.gameObject);
            GameController.setPoints(100);
            FindObjectOfType<GameController>().tocarSomHit();
            
        }
    }
}
