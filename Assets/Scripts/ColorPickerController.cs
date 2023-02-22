using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
	[SerializeField] private Image paintColorImage;
	[SerializeField] private TextMeshProUGUI paintNumber;
	
	public void SetColor(Color color)
	{
		paintColorImage.color = color;
	}
	
	public void SetNumber(int number)
	{
		paintNumber.text = number.ToString();
	}
}
