using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public string nameItem;   // Nombre del �tem (ej: Manzana, Banana)
    public int itemValue = 1; // Valor en puntos

    public AudioClip itemSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador recogi�: " + nameItem + " (+" + itemValue + ")");

            if (nameItem == "Poison")
            {
                GameManager.Instance.TotalPoison(itemValue);
            }else if (nameItem == "Coin")
            {
                GameManager.Instance.TotalCoin(itemValue);
            }
            //else if (nameItem == "Heart")
            //{
            //    GameManager.Instance.TotalHeart(itemValue);
            //}
            else
            {
                Debug.LogWarning("�tem desconocido: " + nameItem);
            }
            if (itemSound != null)
            {
                AudioSource.PlayClipAtPoint(itemSound,transform.position);

            }
            

            Destroy(gameObject);
        }
    }
}