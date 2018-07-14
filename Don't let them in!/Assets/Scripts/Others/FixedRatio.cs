using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRatio : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float offset;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height; // basically height * screen aspect ratio

        Sprite s = spriteRenderer.sprite;
        float unitWidth = s.textureRect.width / s.pixelsPerUnit;
        float unitHeight = s.textureRect.height / s.pixelsPerUnit;

        spriteRenderer.transform.localScale = new Vector3((width / unitWidth) + offset, height / unitHeight);
        spriteRenderer.transform.position = Vector3.zero;
    }

    private void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height; // basically height * screen aspect ratio

        Sprite s = spriteRenderer.sprite;
        float unitWidth = s.textureRect.width / s.pixelsPerUnit;
        float unitHeight = s.textureRect.height / s.pixelsPerUnit;

        spriteRenderer.transform.localScale = new Vector3((width / unitWidth) + offset, height / unitHeight);
        spriteRenderer.transform.position = Vector3.zero;
    }
}
