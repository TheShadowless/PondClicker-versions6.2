using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class ChillDisplay : MonoBehaviour
{
    public void UpdateChillText(double chillCount, TextMeshProUGUI textToChange, string optinalEndText = null)
    {
        string[] suffixes = { "", "k", "M", "B", "T", "Q" };
        int index = 0;

        while (chillCount >= 1000 && index < suffixes.Length - 1)
        {
            chillCount /= 1000;
            index++;

            if (index >= suffixes.Length - 1 && chillCount >= 1000)
            {
                break;
            }
        }
        string formattedText;
        if (index == 0)
        {
            formattedText = chillCount.ToString();
        }

        else
        {
            formattedText = chillCount.ToString("F1") + suffixes[index];
        }
        textToChange.text = formattedText + optinalEndText;
    }
    
}
