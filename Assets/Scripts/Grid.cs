using UnityEngine;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour
{
    public Invader[] invaderInst;

    public System.Action newkill;

    public int rows = 5;

    public float dps = 1.0f;

    public int columns = 11;

    public Laser InvLaser;

    private Vector3 _direction = Vector2.right;

    public AnimationCurve speed;

    public int killed;

    public int total => this.rows * this.columns;

    public float percent => (float)this.killed / (float)this.total;

    private void Awake()
    {
        for (int i = 0; i < this.rows; i++)
        {
            Vector3 positionForIRow = new Vector3(-3.75f, 0.5f * i + 1.5f, 0.0f);
            for (int j = 0; j < this.columns; j++)
            {
                Invader inv = Instantiate(this.invaderInst[i], this.transform);
                inv.killed += _invKilled;
                Vector3 InvPos = positionForIRow;
                InvPos.x += j * 0.75f;
                inv.transform.localPosition = InvPos;

            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(missile), this.dps, this.dps);
    }

    private void _invKilled()
    {
        killed += 1;
        if (this.killed >= this.total)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        this.newkill.Invoke();
    }

    private void missile()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < 4.0f / (float)(this.total - this.killed))
            {
                Instantiate(this.InvLaser, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    private void Update()
    {
        this.transform.position += this.speed.Evaluate(this.percent) * _direction * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (this.transform.position.y < -3.5f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 0.3f) ||
                _direction == Vector3.left && invader.position.x <= (leftEdge.x + 0.3f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
            position.y -= 0.4f;
        this.transform.position = position;


    }

}
