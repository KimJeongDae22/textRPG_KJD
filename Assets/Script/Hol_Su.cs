using UnityEngine;

public class Hol_Su : MonoBehaviour
{
    int i;

    void Start()
    {
        Debug.Log("for ¹®");
        int i = 1;
        for (i = 1; i < 100; i++)
        {

            if (i % 2 == 1)

            {

                Debug.Log(i);

            }

        }
        Debug.Log("while ¹®");
        i = 1;
        while (i < 100)
        {

            if (i % 2 == 1)

            {

                Debug.Log(i);

            }

            i += 1;

        }
        Debug.Log("do while ¹®");
        i = 1;
        do
        {

            if (i % 2 == 1)

            {

                Debug.Log(i);

            }

            i += 1;

        } while (i < 100);
    }
}
