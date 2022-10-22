using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] listOfSprites;

    public float time = 1.0f;

    private SpriteRenderer _currentSprite;

    private int _index;

    public System.Action killed;

    private void Awake()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Animate), this.time, this.time);
    }

    private void Animate()
    {
        _index++;
        if(_index >= this.listOfSprites.Length)
        {
            _index = 0;
        }
        _currentSprite.sprite = this.listOfSprites[_index];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }

}
