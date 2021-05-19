using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blurEffect : MonoBehaviour
{

    public Shader blurShader;
    public float blurSpread = 0.6f;
    public int iterations = 3;
    private static Material m_Material;

    // Methods
    private void DownSample4x(RenderTexture source, RenderTexture dest)
    {
        float y = 1f;
        Vector2[] offsets = new Vector2[] { new Vector2(-y, -y), new Vector2(-y, y), new Vector2(y, y), new Vector2(y, -y) };
        Graphics.BlitMultiTap(source, dest, this.material, offsets);
    }

    public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
    {
        float y = 0.5f + (iteration * this.blurSpread);
        Vector2[] offsets = new Vector2[] { new Vector2(-y, -y), new Vector2(-y, y), new Vector2(y, y), new Vector2(y, -y) };
        Graphics.BlitMultiTap(source, dest, this.material, offsets);
    }

    protected void OnDisable()
    {
        if (m_Material != null)
        {
            Object.DestroyImmediate(m_Material);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture dest = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
        RenderTexture texture2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
        this.DownSample4x(source, dest);
        bool flag = true;
        for (int i = 0; i < this.iterations; i++)
        {
            if (flag)
            {
                this.FourTapCone(dest, texture2, i);
            }
            else
            {
                this.FourTapCone(texture2, dest, i);
            }
            flag = !flag;
        }
        if (flag)
        {
            Graphics.Blit(dest, destination);
        }
        else
        {
            Graphics.Blit(texture2, destination);
        }
        RenderTexture.ReleaseTemporary(dest);
        RenderTexture.ReleaseTemporary(texture2);
    }
    protected void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            base.enabled = false;
        }
        else if ((this.blurShader == null) || !this.material.shader.isSupported)
        {
            base.enabled = false;
        }
    }
    // Properties
    protected Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(this.blurShader);
                m_Material.hideFlags = HideFlags.DontSave;
            }
            return m_Material;
        }
    }
}
