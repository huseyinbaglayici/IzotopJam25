using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement; // DOTween namespace

public class CutSceneController : MonoBehaviour
{
    public Image image;               // Canvas içindeki full-screen UI Image
    public Sprite[] frames;           // Cutscene PNG'ler
    public float frameDuration = 1f;  // Her frame ekranda kalma süresi
    public float fadeDuration = .7f; // Fade süresi

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        image.color = new Color(1, 1, 1, 0); // başta görünmez

        for (int i = 0; i < frames.Length; i++)
        {
            image.sprite = frames[i];

            // Fade In
            yield return image.DOFade(1f, fadeDuration).WaitForCompletion();

            // Bekleme
            yield return new WaitForSeconds(frameDuration);

            // Fade Out
            yield return image.DOFade(0f, fadeDuration).WaitForCompletion();
        }

        image.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}