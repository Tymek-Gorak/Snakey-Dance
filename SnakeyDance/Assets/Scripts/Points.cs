using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public static int points = 0;
    public static int highscore = 0;
    private TextMeshProUGUI pointText;
    void Start()
    {
        pointText = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " + points + "\nHighscore: " + highscore;
    }
}
