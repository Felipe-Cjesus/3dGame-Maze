using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float velocidade;
    [SerializeField]
    float pulo;
    [SerializeField]
    GameObject tiro;
    [SerializeField]
    GameObject StartPosition;

    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        GameController.setMessage("A cada 500 pontos voce ganha uma vida!");
        //Invoke("LimparMensagem", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        verificaY();
        atira();
    }

    void LimparMensagem()
    {
        // Limpa a mensagem da tela
        GameController.setMessage("");
    }

    void atira() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject go = Instantiate(tiro,
                transform.position,
                Quaternion.identity);
            
            go.GetComponent<Rigidbody>().AddForce(
                transform.forward*400f, ForceMode.Acceleration);
            Destroy(go, 2f);
        }
    }

    void verificaY() {
        if (transform.position.y < -10)
        {
            GameController.countLife--;
            transform.position = new Vector3(0f, 2f, 0f);
            //GameOver
        }
    }

    void move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        this.transform.Translate(
            new Vector3(x * Time.deltaTime * velocidade,
                        0f,
                        z * Time.deltaTime * velocidade));

        this.transform.Rotate(
               new Vector3(0f,
                Input.GetAxis("Mouse X") * velocidade, 0f));
    }

    void jump() {
        if (Input.GetButtonDown("Jump") && jumping == false) {
            jumping = true;
            rb.AddForce(new Vector3(0f,pulo, 0f), ForceMode.Impulse);
        }
    }

    void die()
    {
        GameController.removeLife();

        //transform.position = new Vector3(0f, 2f, 0f);
        this.transform.position = StartPosition.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            jumping = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {

            // collision.gameObject.GetComponent<Rigidbody>()
            //  .AddForce(new Vector3(0f,0f, 500f));

            die();
        }
        if (collision.gameObject.tag == "Finish")
        {
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
