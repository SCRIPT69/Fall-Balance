using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerModelRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject _playerModel;
    private Rigidbody _playerModelRigidbody;
    private int _fingerID;
    private bool _isTouched = false;

    private Vector3 _rotationStartVelocity;
    private Vector3 _rotationStartAngularVelocity;

    void Start()
    {
        _playerModelRigidbody = _playerModel.GetComponent<Rigidbody>();
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
        StopRotation();
    }

    private void StopRotation()
    {
        StopCoroutine(stopRotationAnimation());
        StartCoroutine(stopRotationAnimation());
    }

    IEnumerator stopRotationAnimation()
    {
        //yield return new WaitForSeconds(0.3f);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            _playerModelRigidbody.velocity = new Vector3(lerpToZero(_rotationStartVelocity.x, i), lerpToZero(_rotationStartVelocity.y, i), 0);
            _playerModelRigidbody.angularVelocity = new Vector3(lerpToZero(_rotationStartAngularVelocity.x, i), lerpToZero(_rotationStartAngularVelocity.y, i), 0);

            yield return null;
        }
        _playerModelRigidbody.velocity = Vector3.zero;
        _playerModelRigidbody.angularVelocity = Vector3.zero;
    }
    private float lerpToZero(float value, float interpolation)
    {
        return Mathf.Lerp(value, 0, interpolation);
    }


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
                        //Rotation here
                        _playerModelRigidbody.AddTorque(touch.deltaPosition.y, -touch.deltaPosition.x, 0, ForceMode.Acceleration);

                        //For animation of stop
                        _rotationStartVelocity = _playerModelRigidbody.velocity;
                        _rotationStartAngularVelocity = _playerModelRigidbody.angularVelocity;
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        StartCoroutine(stopRotationAnimation());
                    }
                }
            }
        }
    }
}
