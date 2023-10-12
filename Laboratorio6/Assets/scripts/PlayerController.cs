using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Text scoreText;
    public Text livesText;
    public int maxLives = 3;
    public int score = 0;

    private Rigidbody rb;
    private int Vida;
    private bool canCollideWithAsteroid = true;
    private bool canIncreaseScore = true;
    public float IntervaloPuntaje = 1.0f;

    private Vector3 initialPosition;

    public float velocidadMovimiento = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vida = maxLives;
        StartCoroutine(IncrementScoreRoutine());
        UpdateLives();
        initialPosition = transform.position;
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoVertical, 0.0f, movimientoHorizontal);
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroide") && canCollideWithAsteroid)
        {
            if (Vida > 0)
            {
                LoseLife();
            }
            else
            {
                ResetPlayer();
            }
        }
    }

    void ResetPlayer()
    {
        transform.position = initialPosition;
        score = 0;
        UpdateScore(0);
    }

    private IEnumerator IncrementScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervaloPuntaje);

            if (canIncreaseScore)
            {
                UpdateScore(10);
            }
        }
    }

    private void UpdateScore(int puntos)
    {
        score += puntos;
        scoreText.text = "Puntos: " + score;
    }

    void UpdateLives()
    {
        livesText.text = "Vidas: " + Vida;
    }

    void LoseLife()
    {
        Vida--;
        UpdateLives();
    }
}

