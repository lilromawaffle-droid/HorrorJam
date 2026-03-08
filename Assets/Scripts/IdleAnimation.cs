using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class IdleAnimation : MonoBehaviour
{    [SerializeField] Image image;
    [SerializeField] Sprite[] frames; // drag semua sprite di Inspector
    [SerializeField] float frameInterval = 0.1f;
    [SerializeField] bool loop = true;

    private Coroutine animationCoroutine;

    void Start()
    {
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);

        animationCoroutine = StartCoroutine(Animate());
    }

    public void StopAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }

    IEnumerator Animate()
    {
        int currentFrame = 0;

        do
        {
            // Ganti gambar
            image.sprite = frames[currentFrame];

            // Tunggu sebelum frame berikutnya
            yield return new WaitForSeconds(frameInterval);

            // Pindah ke frame berikutnya
            currentFrame++;

            // Reset ke frame pertama jika sudah habis
            if (currentFrame >= frames.Length)
                currentFrame = 0;

        } while (loop); // jika loop = false, animasi hanya sekali
    }
}

