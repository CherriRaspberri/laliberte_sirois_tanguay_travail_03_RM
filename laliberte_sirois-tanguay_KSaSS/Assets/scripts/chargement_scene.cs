using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chargement_scene : MonoBehaviour
{
    public Animator canvas ;

public void onClick()
{
    StartCoroutine("chargerNiveau");
}

    IEnumerator chargerNiveau()
    {
        canvas.SetTrigger("debut");
        SceneManager.LoadScene(1);
        yield break;
    }

    public void AllerAEchec(string gameOver)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameOver); 
    }

    public void RecommencerLeNiveau()
    {
        Time.timeScale = 1f; // Relance le temps au cas où il était à 0
        string gameOver = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("game_scene");
    }
}
