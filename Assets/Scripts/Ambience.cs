using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour {

    public GameObject[] planets;

    private void Start()
    {
        StartCoroutine(CreationPlanets());
    }

    IEnumerator CreationPlanets()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {           
            CreatePlanet();
            yield return new WaitForSeconds(30);
        }
    }

    void CreatePlanet()
    {
        GameObject randomPlanet = planets[Random.Range(0, planets.Length)];
        Instantiate(randomPlanet, randomPlanet.transform.position, Quaternion.identity);
    }
}
