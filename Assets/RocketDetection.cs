using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDetection : MonoBehaviour
{
    public int Bombs;
    // Start is called before the first frame update
    void Start()
    {
        Bombs = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Bombs <= 0)
        {
            StartCoroutine(Boom());
        }
    }

    public IEnumerator Boom()
    {
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }
}
