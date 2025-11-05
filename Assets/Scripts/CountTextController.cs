using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountTextController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float count;
    private TextMeshProUGUI countLastText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -10);
        countLastText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        count += Time.deltaTime;

        if (count >= 5)
        {
            rb.linearVelocity = Vector2.zero;
        }

        countLastText.text = TitleController.count.ToString("F0");
    }
}
