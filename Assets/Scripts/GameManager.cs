using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseGeneral;
    public bool pause;
    public int playerColor;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void GoGame()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Debug.Log("Esta saliendo del juego");
    }
    public void Reanudar()
    {
        pauseGeneral.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Rojo()
    {
        player.GetComponent<SpriteRenderer>().color = Color.red;
        playerColor = 1;
    }
    public void Blue()
    {
        player.GetComponent<SpriteRenderer>().color = Color.blue;
        playerColor = 2;
    }
    public void Green()
    {
        player.GetComponent<SpriteRenderer>().color = Color.green;
        playerColor = 3;
    }
    public void Yellow()
    {
        player.GetComponent<SpriteRenderer>().color = Color.yellow;
        playerColor = 4;
    }
    public void Cyan()
    {
        player.GetComponent<SpriteRenderer>().color = Color.cyan;
        playerColor = 5;
    }
    public void Pause()
    {
        pause = !pause;
        if (pause)
        {
            pauseGeneral.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseGeneral.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

