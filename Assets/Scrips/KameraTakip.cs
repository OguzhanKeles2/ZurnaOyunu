using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform hedef; // Karakterini buraya sürükle
    public Vector3 mesafe = new Vector3(0, 8, -6); // Kameranın karakterden uzaklığı
    public float yumusaklik = 5f;
    public float egimAcisi = 45f;

    void LateUpdate()
    {
        if (hedef == null) return;

        // Kameranın gitmesi gereken sabit pozisyon
        Vector3 hedefPozisyon = hedef.position + mesafe;

        // Kamerayı yumuşakça oraya taşı
        transform.position = Vector3.Lerp(transform.position, hedefPozisyon, yumusaklik * Time.deltaTime);

        // Kameranın her zaman sabit bir açıyla aşağı bakmasını sağla
        // (X: 45 derece aşağı eğim verir)
        transform.rotation = Quaternion.Euler(egimAcisi, 0, 0);
    }
}