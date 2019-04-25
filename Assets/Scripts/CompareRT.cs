using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareRT : MonoBehaviour
{

    public RenderTexture rt1;
    public RenderTexture rt2;

    public int differentPixelCount;

    public void Compare()
    {

        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = rt1;
        Texture2D tempTex1 = new Texture2D(rt1.width, rt1.height);
        tempTex1.ReadPixels(new Rect(0, 0, rt1.width, rt1.height), 0, 0);
        tempTex1.Apply();
        RenderTexture.active = previous;

        previous = RenderTexture.active;
        RenderTexture.active = rt2;
        Texture2D tempTex2 = new Texture2D(rt2.width, rt2.height);
        tempTex2.ReadPixels(new Rect(0, 0, rt2.width, rt2.height), 0, 0);
        tempTex2.Apply();
        RenderTexture.active = previous;

        differentPixelCount = 0;

        Color[] firstPix = tempTex1.GetPixels();
        Color[] secondPix = tempTex2.GetPixels();
        if (firstPix.Length != secondPix.Length)
        {
            Debug.LogError("Different Sizes");
            return;
        }
        for (int i = 0; i < firstPix.Length; i++)
        {
            if (firstPix[i] != secondPix[i])
            {
                differentPixelCount++;
            }
        }

        return;

    }

}
