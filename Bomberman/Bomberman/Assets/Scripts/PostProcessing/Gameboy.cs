using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Gameboy : MonoBehaviour {

    public Material gameboyMat;
    public Material identityMat;

    private RenderTexture _downscaledRenderTexture;

    private void OnEnable()
    {
        var camera = GetComponent<Camera>();
        int height = 144;
        int width = Mathf.RoundToInt(camera.aspect * height);
        _downscaledRenderTexture = new RenderTexture(width, height, 16);
        _downscaledRenderTexture.filterMode = FilterMode.Point; 
    }

    private void OnDisable()
    {
        Destroy(_downscaledRenderTexture); 
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, _downscaledRenderTexture, gameboyMat);
        Graphics.Blit(_downscaledRenderTexture, destination, identityMat); 

    }
}
