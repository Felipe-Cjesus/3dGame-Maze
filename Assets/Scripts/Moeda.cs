using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameController.countPoints++;
            GameController.setPoints(50);

            FindObjectOfType<GameController>().tocarSom();

            Destroy(this.gameObject);
        }
    }
}
