using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScrollRectStartPos : MonoBehaviour
{
	[SerializeField] private float startValue = 0f;
	private ScrollRect _scrollRect;
	
    // Start is called before the first frame update
    void Start()
	{
		_scrollRect = GetComponent<ScrollRect>();
		if (_scrollRect == null)
			return;
		StartCoroutine(Do());

	}

	private IEnumerator Do()
	{
		yield return new WaitForSeconds(0.1f);
		_scrollRect.horizontalNormalizedPosition = startValue;
	}
}
