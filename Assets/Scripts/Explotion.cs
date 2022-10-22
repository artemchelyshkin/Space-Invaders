using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    float time = 1.0f;
    // Start is called before the first frame update
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(this.gameObject);
        }    
    }
}
