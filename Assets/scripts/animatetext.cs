using UnityEngine;
using UnityEngine.UI;

public class animatetext : MonoBehaviour
{
    public Text textToAnimate;
    public float animationSpeed = 1.0f;
    public float maxBrightness = 1.0f;

    private float timeCounter = 0f;

    void Update()
    {
        timeCounter += Time.deltaTime * animationSpeed;

        float brightness = Mathf.PingPong(timeCounter, maxBrightness);

        Color newColor = textToAnimate.color;
        newColor.a = brightness;
        textToAnimate.color = newColor;
    }
}
