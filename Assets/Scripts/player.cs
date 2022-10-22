using UnityEngine;
using UnityEngine.SceneManagement;

public class player: MonoBehaviour
{
    public float speed = 5.0f;

    public SpecialBar spec;

    public Transform[] health;

    public int lives = 2;

    public Laser LaserPrefab;

    public Bomb BombPrefab;

    private bool _laserActive = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(health[this.lives].gameObject);
            this.lives--;

        }
    }

    private void Update()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > (leftEdge.x + 0.2f))
            {
                this.transform.position += this.speed * Time.deltaTime * Vector3.left;
            }
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x < (rightEdge.x - 0.2f))
            {
                this.transform.position += this.speed * Time.deltaTime * Vector3.right;
            }
        } 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (spec.specActive)
            {
                ShootBomb();
                spec.specActive = false;
                Vector3 vec = spec.transform.localScale;
                vec.x = 0.0f;
                spec.transform.localScale = vec;
            }
        }
    }

    private void ShootBomb()
    {
        Instantiate(this.BombPrefab, this.transform.position, Quaternion.identity);
    }

    private void Shoot()
    {
        if (!_laserActive) { 
            Laser las = Instantiate(this.LaserPrefab, this.transform.position, Quaternion.identity);
            las.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

}
