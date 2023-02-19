using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintPartController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Color targetColor;
	private SpriteRenderer _mySpriteRenderer;
	
	public bool canTouchable = false;
	private bool _isPainted;
	private bool _isTouched;

	private void Awake()
	{
		_mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!TouchManager.CanTouch)
			return;

		TouchManager.touchCount++;
		_isTouched = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if(!_isTouched)
			return;
		
		SetPaint();
		TouchManager.touchCount--;
		_isTouched = false;
	}

	public void SetPaint()
	{
		_mySpriteRenderer.color = targetColor;
		_isPainted = true;
	}
}