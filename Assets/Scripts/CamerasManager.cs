using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerasManager : Singleton<CamerasManager>
{
    [SerializeField]
    private CinemachineVirtualCamera _mainCam, _missionCam;
    private float _defaultZoomSize;

    private void Start()
    {
        _defaultZoomSize = _mainCam.m_Lens.OrthographicSize;
    }

    public void EnableMissionCam(Transform target)
    {
        _missionCam.gameObject.SetActive(true);
        _missionCam.m_Follow = target;
    }

    public void BackToNormal()
    {
        _mainCam.m_Lens.OrthographicSize = _defaultZoomSize;
        _missionCam.gameObject.SetActive(false);
    }

    //public void SetZoom()
    //{
    //    _mainCam.m_Lens.OrthographicSize -= 100f;
    //}

    //public void ScreenShake()
    //{

    //}
}
