using UnityEngine;

public class SpecialBar : MonoBehaviour
{
    public bool specActive = false;
    public Grid gr;
    private void Awake()
    {
        this.transform.localScale = new Vector3(0.0f, 0.24f, 1.0f);
        gr.newkill += updTable;
    }

    private void updTable()
    {
        Vector3 vec = this.transform.localScale;
        vec.x += 0.15f;
        if (vec.x >= 1.0f)
        {
            this.specActive = true;
            vec.x = 1.0f;
        }
        this.transform.localScale = vec;
    }

    private void Update()
    {
        if (!this.specActive)
        {
            Vector3 vec = this.transform.localScale;
            if (vec.x > 0.0003f)
            {
                vec.x -= 0.0003f;
                this.transform.localScale = vec;
            }
        }
    }
}
