using UnityEngine;

public class PulseRect : MonoBehaviour
{
    public float speed = 2f;
    public float alphaAmount = 0.5f;

    private Material mat;
    private Color baseColor;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        baseColor = mat.color;
    }

    void Update()
    {
        float a = Mathf.Abs(Mathf.Sin(Time.time * speed)) * alphaAmount + 0.2f;
        Color c = baseColor;
        c.a = a;
        mat.color = c;
    }
}