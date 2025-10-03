using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Este script NO guarda las vidas, solo trabaja con las del GameManager

    public void SumarVida(int cantidad)
    {
        GameManager.Instance.AddLives(cantidad);
    }

    public void RestarVida(int cantidad)
    {
        GameManager.Instance.AddLives(-cantidad);

        if (GameManager.Instance.playerLives <= 0)
        {
            Debug.Log("El jugador ha muerto");
            // Aquí puedes agregar animación de muerte, cargar escena GameOver, etc.
        }
    }
}
