using UnityEngine;

public class MetricasFinales : MonoBehaviour
{
    public GameObject panelResultados; 

    void Start()
    {
        
        if (panelResultados != null)
            panelResultados.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (panelResultados != null)
                panelResultados.SetActive(true);

        }
    }
}
