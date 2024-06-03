using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
                player.transform.position.x,
                player.transform.position.y + 1.5f,
                player.transform.position.z - 1.5f);
        
        transform.rotation = 
                player.transform.rotation;
        transform.Rotate(30f, 0f, 0f);
        /*
        transform.Rotate(
            new Vector3(0f,
                player.transform.rotation.y*3,
                0f));
        */

        //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation , 3f);
        //float rotationSpeed = 5f;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        // transform.LookAt(Vector3.zero);
    }

}