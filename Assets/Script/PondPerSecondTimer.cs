using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondPerSecondTimer : MonoBehaviour
{
   public float TimerDuration = 1f;
    public double ChillperSecond {  get;  set; }
    private float counter;
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= TimerDuration )
        {
            PondManager.instance.SimpleChillIncreases(ChillperSecond);

            counter = 0;
        }    
    }
}
