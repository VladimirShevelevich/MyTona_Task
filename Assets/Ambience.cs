using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour {

    public GameObject[] planets;

    int index;

    IEnumerator CreationPlanets()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            CreatePlanet();
        }
    }

    void CreatePlanet()
    {
        Instantiate(planets[index], planets[index].transform.position, Quaternion.identity);
        index++;
        if (index >= planets.Length)
            index = 0;
    }
}
