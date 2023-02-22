using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RefreshContentSizeFitter : MonoBehaviour
{
	private VerticalLayoutGroup _verticalLayoutGroup;
	private HorizontalLayoutGroup _horizontalLayoutGroup;

	private void Start()
	{
		Refresh();
	}

	public void Refresh()
	{
		if(!gameObject.activeInHierarchy)
			return;
		
		if (_verticalLayoutGroup == null)
			_verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();

		if (_horizontalLayoutGroup == null)
			_horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();

		bool hasVertical = _verticalLayoutGroup != null;
		bool hasHorizontal = _horizontalLayoutGroup != null;

		IEnumerator Do()
		{
			for (int i = 0; i < 3; i++)
			{
				if (hasVertical)
				{
					_verticalLayoutGroup.spacing += 0.001f;
					yield return new WaitForEndOfFrame();
					_verticalLayoutGroup.spacing -= 0.001f;
				}
				else if (hasHorizontal)
				{
					_horizontalLayoutGroup.spacing += 0.001f;
					yield return new WaitForEndOfFrame();
					_horizontalLayoutGroup.spacing -= 0.001f;
				}
			}
		}

		StartCoroutine(Do());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}
}