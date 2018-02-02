using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Difficulty());
    }

    IEnumerator Difficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            IncreaseDifficulty();
        }
    }

    void IncreaseDifficulty()
    {
        if (Enemies_Creator.instance.CreationFrequancy > 0.7f)
            Enemies_Creator.instance.CreationFrequancy -= 0.05f;
    }

}
