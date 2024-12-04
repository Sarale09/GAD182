using UnityEngine;
using UnityEngine.UI;

public class ButtonPressEffect : MonoBehaviour
{
    public float scaleUpFactor = 1.2f; // Scale size when pressed
    public float animationSpeed = 0.1f; // Speed of scaling

    private Vector3 originalScale;
    private Button button;

    private void Start()
    {
        originalScale = transform.localScale; // Save the initial scale
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked); // Add a click listener
        }
    }

    private void OnButtonClicked()
    {
        // Trigger the scale animation when clicked
        StartCoroutine(AnimateButtonPress());
    }

    private System.Collections.IEnumerator AnimateButtonPress()
    {
        // Scale up
        yield return ScaleTo(originalScale * scaleUpFactor, animationSpeed / 2);

        // Scale back down
        yield return ScaleTo(originalScale, animationSpeed / 2);
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 targetScale, float duration)
    {
        Vector3 currentScale = transform.localScale;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(currentScale, targetScale, timer / duration);
            yield return null;
        }

        transform.localScale = targetScale; // Ensure final scale
    }
}
