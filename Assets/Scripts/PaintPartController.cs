using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintPartController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	#region References

	[HideInInspector] public PolygonCollider2D collider;

	public Color targetColor;
	private TextMeshPro _numberText;
	private SpriteRenderer _mySpriteRenderer;

	#endregion

	#region Variables
	
	private bool _isPainted;
	private bool _isTouched;

	private Texture2D _texture;

	#endregion


	private void Awake()
	{
		_mySpriteRenderer = GetComponent<SpriteRenderer>();
		_numberText = GetComponentInChildren<TextMeshPro>();
		collider = GetComponent<PolygonCollider2D>();
		
		var newMaterial = new Material(_mySpriteRenderer.material);
		_mySpriteRenderer.material = newMaterial;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!TouchManager.CanTouch || _isPainted)
			return;

		TouchManager.touchCount++;
		_isTouched = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!_isTouched)
			return;

		SetPaintWithAnimation();
		TouchManager.touchCount--;
		_isTouched = false;
	}
	
	public void SetPaintable()
	{
		_isPainted = false;
		collider.enabled = true;
		_mySpriteRenderer.material.SetFloat("_Opacity", 1f);
	}

	private void SetPaintWithAnimation()
	{
		_numberText.enabled = false;
		collider.enabled = false;
		_isPainted = true;
		_mySpriteRenderer.color = targetColor;
		_mySpriteRenderer.material.DOFloat(0, "_Opacity", 0.5f);
	}
	

	private void SetPaint()
	{
		_mySpriteRenderer.color = targetColor;
		_numberText.enabled = false;
		collider.enabled = false;
		_isPainted = true;
	}

	public void SetNumber(int number)
	{
		_numberText.text = number.ToString();
	}
}