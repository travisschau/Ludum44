using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    float frameCount;
    float dt;
    float fps;
    float updateRate = 4;  // 4 updates per sec.

    public TextMeshProUGUI fpsCountText;
    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0/updateRate)
        {
            fps = frameCount / dt ;
            frameCount = 0;
            dt -= 1/updateRate;
        }

        fpsCountText.text = fps.ToString();
    }
}