using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public float flashDelayTime = 0.5f;
    private SpriteRenderer bodySpriteRenderer;
    private Color defaultColor;

    void Start()
    {
        // Find the child named "Body" and get the SpriteRenderer component
        Transform body = transform.Find("Body");
        if (body != null)
        {
            bodySpriteRenderer = body.GetComponent<SpriteRenderer>();
            if (bodySpriteRenderer != null)
            {
                defaultColor = bodySpriteRenderer.color; // Store the default color
            }
            else
            {
                Debug.LogError("No SpriteRenderer found on the child object named 'Body'");
            }
        }
        else
        {
            Debug.LogError("No child object named 'Body' found");
        }
    }

    public void DamagedFlash()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        
        
            // Set the color to red
            bodySpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashDelayTime);

            // Set the color back to default
            bodySpriteRenderer.color = defaultColor;
            yield return new WaitForSeconds(flashDelayTime);
        
    }
}
