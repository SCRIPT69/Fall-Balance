using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class CameraControllingPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] CinemachineFreeLook _camera;
    private int _fingerID;
    private bool _isTouched = false;
    private float _cameraXRotationSpeed = 120;
    private float _cameraYRotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _camera.m_XAxis.m_MaxSpeed = _cameraXRotationSpeed;
        _camera.m_YAxis.m_MaxSpeed = _cameraYRotationSpeed;

        _camera.m_YAxis.m_InputAxisName = "";
        _camera.m_XAxis.m_InputAxisName = "";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            _isTouched = true;
            _fingerID = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isTouched = false;
        _camera.m_YAxis.m_InputAxisValue = 0;
        _camera.m_XAxis.m_InputAxisValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTouched)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == _fingerID)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        _camera.m_XAxis.m_InputAxisValue = touch.deltaPosition.x;
                        _camera.m_YAxis.m_InputAxisValue = touch.deltaPosition.y;
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        _camera.m_YAxis.m_InputAxisValue = 0;
                        _camera.m_XAxis.m_InputAxisValue = 0;
                    }
                }
            }
        }
    }
}
