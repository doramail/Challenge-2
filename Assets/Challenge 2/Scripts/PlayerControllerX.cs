using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool spawned = false;
    private float decay = 0.0f;
    [SerializeField] float InitialisationCompteur = 3.0f; // Temps en secondes avant de laisser la possibilité d'appuyer à nouveau sur la touche ESPACE.

    // Update is called once per frame
    void Update()
    {
        Reset();
        if (Input.GetKeyDown(KeyCode.Space) && !spawned)
        {
            decay = InitialisationCompteur;
            spawned = true;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    private void Reset()
    {
        if (spawned && decay > 0)
        {
            decay -= Time.deltaTime; // on décrémente le temps du timer
        }
        if (decay < 0)
        {
            decay = 0;
            spawned = false;
        }
    }
}
