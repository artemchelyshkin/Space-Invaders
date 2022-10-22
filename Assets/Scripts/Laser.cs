using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 direction;

    public System.Action destroyed;

    public float speed = 10.0f;

    private void Update()
    {
        this.transform.position += this.speed * Time.deltaTime * this.direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke();
        }
        Destroy(this.gameObject);
    }
}
