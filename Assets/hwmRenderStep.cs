using UnityEngine;

/// <summary>
/// 这个组件需要挂在一个Camera上才能收到Unity的事件<see cref="OnPostRender"/>
/// </summary>
[RequireComponent(typeof(Camera))]
public class hwmRenderStep : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    private RenderTexture m_ScreenRenderTarget;

    protected void Awake()
    {
        m_ScreenRenderTarget = new RenderTexture(1920, 1080, 64);

        Camera1.enabled = false; 
        Camera1.targetTexture = m_ScreenRenderTarget;
        Camera2.enabled = false;
        Camera2.targetTexture = m_ScreenRenderTarget;
    }

    protected void OnPostRender()
    {
        RenderTexture originalRenderTarget = RenderTexture.active;
        RenderTexture.active = m_ScreenRenderTarget;
        GL.Clear(true, true, Color.red);

        RenderTexture.active = originalRenderTarget;

        Camera1.Render();
        Camera2.Render();
        Graphics.Blit(m_ScreenRenderTarget, (RenderTexture)null);
    }
}