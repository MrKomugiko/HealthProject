using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bmiValue;
    // Start is called before the first frame update
    void Start()
    {
        if (float.Parse(bmiValue.text) <= 18.5f)
        {
            // UNDERWEIGHT
            this.GetComponent<Image>().color = Color.blue;
        }
        else if (float.Parse(bmiValue.text) <= 24.9f)
        {
            // NORMAL
            this.GetComponent<Image>().color = Color.green;
        }
        else if (float.Parse(bmiValue.text) <= 29.9f)
        {
            // OVERWEIGHT
            this.GetComponent<Image>().color = Color.yellow;
        }
        else if (float.Parse(bmiValue.text) <= 34.9f)
        {
            // OBESE
            this.GetComponent<Image>().color = Color.red;
        }
        else if (float.Parse(bmiValue.text) >= 35f)
        {
            // EXTREMELYOBESE
            this.GetComponent<Image>().color = Color.magenta;
        }
    }
}
