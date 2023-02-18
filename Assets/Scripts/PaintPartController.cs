using UnityEngine;
using UnityEngine.EventSystems;

public class PaintPartController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Color targetColor;
	[SerializeField] private SpriteRenderer mySpriteRenderer;
	
	public bool canTouchable = false;
	private bool _isPainted;
	private bool _isTouched;

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

		TouchManager.touchCount--;
		_isTouched = false;
	}

	public void SetPaint()
	{
		mySpriteRenderer.color = targetColor;
		_isPainted = true;
	}
}