using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public bl_Joystick joystick;
    public float hiz = 5f;
    public float donmeHizi = 15f;

    // Animasyonu kontrol etmek için değişken
    private Animator anim;

    void Start()
    {
        // Karakterin üzerindeki Animator bileşenini otomatik bulur
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        Vector3 hareket = new Vector3(x, 0, y);

        if (hareket.magnitude > 0.1f)
        {
            transform.position += hareket * hiz * Time.deltaTime;

            Quaternion hedefDonus = Quaternion.LookRotation(hareket);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefDonus, donmeHizi * Time.deltaTime);

            // Hareket varsa yürüme/koşma animasyonuna geç
            anim.SetBool("isWalking", true);
        }
        else
        {
            // Hareket yoksa durma (Idle) animasyonuna geç
            anim.SetBool("isWalking", false);
        }
    }
}