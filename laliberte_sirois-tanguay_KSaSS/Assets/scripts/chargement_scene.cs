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
}
