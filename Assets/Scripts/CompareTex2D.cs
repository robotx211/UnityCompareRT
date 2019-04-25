using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class CompareTex2D : MonoBehaviour
{
    public Texture2D tex1;
    public Texture2D tex2;

    public int differentPixelCount;

    public void Compare()
    {

        if (tex1.isReadable == false)
        {
            tex1 = duplicateTexture(tex1);
        }

        if (tex2.isReadable == false)
        {
            tex2 = duplicateTexture(tex2);
        }

        differentPixelCount = 0;

        Color[] firstPix = tex1.GetPixels();
        Color[] secondPix = tex2.GetPixels();
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

    //https://stackoverflow.com/questions/44733841/how-to-make-texture2d-readable-via-script
    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}
