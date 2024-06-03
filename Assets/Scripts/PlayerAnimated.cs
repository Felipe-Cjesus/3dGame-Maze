using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimated : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    GameObject tiro;
    [SerializeField]
    GameObject StartPosition;
    [SerializeField]
    float pulo;

    private bool jumping = false;

    public float speed;
    //public float gravity;
    //public float rotSpeed;
    //private float rot;
    //private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        this.transform.position = StartPosition.transform.position;

        GameController.setMessage("A cada 500 pontos voce ganha uma vida!\nMate os inimigos e colete as moedas...\nBoa sorte...");
        Invoke("LimparMensagem", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        attack();
        jump();
    }

    void LimparMensagem()
    {
        // Limpa a mensagem da tela
        GameController.setMessage("");
    }

    void Move()
    {
        /*
        if (controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetInteger("transition", 1);
            }

            if (Input.GetKeyUp(KeyCode.W)) 
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot,0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
        */
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        this.transform.Translate(
            new Vector3(x * Time.deltaTime * speed,
                        0f,
                        z * Time.deltaTime * speed));

        this.transform.Rotate(
               new Vector3(0f,
                Input.GetAxis("Mouse X") * speed, 0f));

        if (Input.GetKey(KeyCode.W))
        {
           anim.SetInteger("transition", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("transition", 2);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("transition", 3);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            speed = 2;
            anim.SetInteger("transition", 4);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 6;
            anim.SetInteger("transition", 6);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3;
            anim.SetInteger("transition", 0);
        }
    }

    void die()
    {
        GameController.removeLife();

        this.transform.position = StartPosition.transform.position;
        //anim.SetInteger("transition", 0);

    }
    void attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetInteger("transition", 5);
            //Invoke("shootAttack", 1.7f);
            shootAttack();
        }
    }

    void shootAttack()
    {
        GameObject go = Instantiate(tiro,
                new Vector3(transform.position.x, 1f, transform.position.z),
                Quaternion.identity);

        go.GetComponent<Rigidbody>().AddForce(
            transform.forward * 400f, ForceMode.Acceleration);

        anim.SetInteger("transition", 0);
        Destroy(go, 2f);
    }

    void jump()
    {
        
        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            jumping = true;
            rb.AddForce(new Vector3(0f, pulo, 0f), ForceMode.Impulse);
            FindObjectOfType<GameController>().tocarSomPulo();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //anim.SetInteger("transition", 7);
            //Invoke("die", 5f);
            die();
        }
        if (collision.gameObject.tag == "Chao")
        {
            jumping = false;
        }
        if (collision.gameObject.tag == "Finish") 
        {
            FindObjectOfType<GameController>().tocarSomFinish();
            SceneManager.LoadScene("FaseConcluida");
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            jumping = true;
        }
    }
}
