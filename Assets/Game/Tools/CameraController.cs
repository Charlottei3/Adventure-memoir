using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float referenceAspect = 1920 / 1080;
    private float _referenceOrthoSize;
    private float _minAspectThreshold = 0.65f;         // Min aspect (portrait)
    [SerializeField] float _currentAspect;

    void Start()
    {
        _currentAspect = Camera.main.aspect;

        SetSizeCam(Camera.main.orthographicSize);
    }

    private void Update()
    {
        if (_currentAspect != Camera.main.aspect)
        {
            _currentAspect = Camera.main.aspect;
            AdjustCameraSize();
        }
    }

    public void SetSizeCam(float newSize)
    {
        Camera.main.orthographicSize = newSize;
        _referenceOrthoSize = newSize;
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        float screenAspect = (float)Screen.width / Screen.height;

        // Tính orthographicSize theo aspect (so với gốc)
        float newOrthoSize = _referenceOrthoSize * (referenceAspect / screenAspect);

        // Nếu gần với iPad hoặc tablet 4:3 → clamp
        if (screenAspect >= _minAspectThreshold)
        {
            newOrthoSize = Mathf.Max(newOrthoSize, _referenceOrthoSize);
            Debug.Log(newOrthoSize);
        }

        Camera.main.orthographicSize = newOrthoSize;
    }
}
