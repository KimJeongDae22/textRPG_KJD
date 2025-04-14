using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    int time = 0;
    void Start()
    {
        StartCoroutine(Coroutine_Test());
    }
    IEnumerator Coroutine_Test()
    {
        while (true)
        {
            time += 1;
            Debug.Log(time);
            yield return new WaitForSeconds(1);
        }
    }
}