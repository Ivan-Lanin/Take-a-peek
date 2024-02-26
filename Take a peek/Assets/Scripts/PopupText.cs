using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PopupText : MonoBehaviour
{
    private TMP_Text tmpText;
    private float appearStep = 0.02f;
    private float appearTime = 0.01f;

    private void OnEnable()
    {
        tmpText = GetComponent<TMP_Text>();
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        while (tmpText.color.a < 1)
        {
            tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, tmpText.color.a + appearStep);
            yield return new WaitForSeconds(appearTime);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        while (tmpText.color.a > 0)
        {
            tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, tmpText.color.a - appearStep);
            yield return new WaitForSeconds(appearTime);
        }
        Destroy(gameObject);
    }
}
