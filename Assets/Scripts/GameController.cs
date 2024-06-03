using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreBoard;

    public static int countPoints = 0;
    public static int countLife = 3;

    [SerializeField]
    AudioSource somDaMoeda;
    [SerializeField]
    AudioSource SoundJump;
    [SerializeField]
    AudioSource SoundHit;
    [SerializeField]
    AudioSource SoundFinish;

    [SerializeField]
    GameObject checkPoint;
    [SerializeField]
    private static TMP_Text messageFrame;

    public static float checkPos;
    public static int somaPontos;

    void Start()
    {
        checkPos  = checkPoint.transform.position.x;

        GameObject go = GameObject.FindGameObjectWithTag("TextoMenssagem");
        messageFrame = go.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countLife == 0)
        {
            scoreBoard.text = "GAME OVER" + "\nPontos: " + countPoints.ToString();
        }
        else
        {
            scoreBoard.text = "Pontos: " + countPoints.ToString() + " \nVidas: " + countLife.ToString();
        }
    }

    public static void removeLife()
    {
        countLife--;

        if (countLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public static void setPoints(int ponto)
    {
        countPoints += ponto;
        somaPontos += ponto;

        if (somaPontos >= 500)
        {
            setLife(1);
            somaPontos = 0;
        }
    }
    public static void setLife(int life)
    {
        countLife += life;
    }

    public static void newGame()
    {
        countPoints = 0;
        countLife = 3;
    }

    public void tocarSom()
    {
        somDaMoeda.Play();
    }
    public void tocarSomPulo()
    {
        SoundJump.Play();
    }
    public void tocarSomHit()
    {
        SoundHit.Play();
    }
    public void tocarSomFinish()
    {
        SoundFinish.Play();
    }

    public static void setMessage(string msg)
    {
        messageFrame.text = msg;
    }

}
