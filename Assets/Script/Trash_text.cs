using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Trash_text : MonoBehaviour
{
    [SerializeField]
    private float moveds = 100;
    [SerializeField]
    private float movetm = 1.5f;

    private RectTransform recttransform;
    private TextMeshPro textUHD;

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        recttransform = GetComponent<RectTransform>();
        textUHD = GetComponent<TextMeshPro>();
    }

    private void Play(string text, Color color, Bounds bounds, float gap=0.1f)
    {
        textUHD.text = text;
        textUHD.color = color;

        StartCoroutine(OnHUDText(bounds, gap));
    }
    
    private IEnumerator OnHUDText(Bounds bounds, float gap)
    {
        Vector2 start = Camera.main.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.max.y + gap, bounds.center.z));
        Vector2 end = start + Vector2.up * moveds;

        float current = 0;
        float percent = 0;
        while (percent<1)
        {
            current += Time.deltaTime;
            percent = current / movetm;

            Color color = textUHD.color;
            color.a = Mathf.Lerp(1, 0, percent);
            textUHD.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}
