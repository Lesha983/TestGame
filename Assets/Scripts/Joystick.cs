using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image _joystick;
    private Image _miniJoystick;
    private Vector2 _inputPosition, _mousePos;
    private int _distanceMiniJoystick = 100;

    private void Start()
    {
        _joystick = GetComponent<Image>();
        _miniJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputPosition = eventData.position;
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputPosition = Vector2.zero;
        _mousePos = Vector2.zero;
        _miniJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.rectTransform, eventData.position, eventData.pressEventCamera, out _mousePos))
        {
            _mousePos = eventData.position - _inputPosition;
        }
        if (_mousePos.magnitude < _distanceMiniJoystick)
        {
            _miniJoystick.rectTransform.anchoredPosition = _mousePos;
        }
        else
        {
            _miniJoystick.rectTransform.anchoredPosition = _mousePos.normalized * _distanceMiniJoystick;
        }
    }

    public Vector2 VectorMove()
    {
        return _mousePos.normalized;
    }
}
