using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
	#region References

	[SerializeField] private Button myButton;
	[SerializeField] private Image paintColorImage;
	[SerializeField] private Image selectedImage;
	[SerializeField] private Image completedImage;
	[SerializeField] private Image completedImage2;
	[SerializeField] private TextMeshProUGUI paintNumber;

	#endregion

	#region Variables

	public int colorIndex = 0;

	#endregion


	public void SetColor(Color color)
	{
		paintColorImage.color = color;
	}

	public void SetNumber(int number)
	{
		colorIndex = number - 1;
		paintNumber.text = number.ToString();
	}

	public void SetSelected()
	{
		if (ColorPickerManager.Instance.selectedColorPickerController == this)
			return;
		if (ColorPickerManager.Instance.selectedColorPickerController != null)
			ColorPickerManager.Instance.selectedColorPickerController.SetNotSelected();

		ColorPickerManager.Instance.selectedColorPickerController = this;
		selectedImage.enabled = true;
		PaintManager.Instance.SetPaintPart(colorIndex);
	}

	public void SetNotSelected()
	{
		selectedImage.enabled = false;
	}

	public void SetCompleted(bool completed)
	{
		if (completed)
		{
			myButton.enabled = false;
			paintNumber.DOFade(0f, 0.5f);
			completedImage.DOFade(1f, 0.5f);
			completedImage2.DOFade(1f, 0.5f);
			SetNotSelected();
		}
	}
}