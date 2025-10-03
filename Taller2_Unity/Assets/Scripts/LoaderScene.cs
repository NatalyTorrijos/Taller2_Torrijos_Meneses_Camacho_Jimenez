using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoaderScenes : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;

    public void lectorEscena(string nameScene)
    {
        StartCoroutine(FadeAndLoad(nameScene));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        float alpha = 0f;
        fadeImage.gameObject.SetActive(true);

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
