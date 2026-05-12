using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class RoomTimer : MonoBehaviour
{

public float tempsRestant = 300f; //(5 min) Temps en secondes
    public TMP_Text texteAffichage;
    public UnityEvent auTempsEcoule; //lancer message échouer quand c'est fini

    private bool timerActif = true;

    void Update()
    {
        if (timerActif)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                AfficherTemps(tempsRestant);
            }
            else
            {
                tempsRestant = 0;
                timerActif = false;
                auTempsEcoule.Invoke(); // Déclenche le message échoué
            }
        }
    }

    void AfficherTemps(float temps)
    {
        // Calcule les minutes et secondes
        float minutes = Mathf.FloorToInt(temps / 60);
        float secondes = Mathf.FloorToInt(temps % 60);

        // Transformer en (00:00)
        texteAffichage.text = string.Format("{0:00}:{1:00}", minutes, secondes);

        // Change la couleur en rouge lorsque qu'il reste moins de 1 minute
        if (temps < 60) texteAffichage.color = Color.red;
    }

}
