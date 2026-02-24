using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWhiteOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration =1f;
 
    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }
 
    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(255f, 255f, 255f, 1f); // White with alpha 1.
 
        while (timer < fadeDuration)
        {
            // Interpolate the color between start and end over time.
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
 
        // Ensure the image is completely white at the end.
        fadeImage.color = endColor;
    }
}
 
