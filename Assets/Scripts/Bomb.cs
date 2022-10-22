using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector3 direction;

    public Explotion ExplotionPrefab;

    public float speed = 5.0f;

    private void Update()
    {
        this.direction.y = 1.0f;
        this.transform.position += this.speed * Time.deltaTime * this.direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(this.ExplotionPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        
    }
}
