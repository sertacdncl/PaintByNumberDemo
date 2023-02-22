using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerManager : Singleton<ColorPickerManager>
{
	#region References

	[SerializeField] private GameObject colorPickerPrefab;
	[SerializeField] private List<ColorPickerController> colorPickerControllerList;

	#endregion

	[HideInInspector] public ColorPickerController selectedColorPickerController;

	public void PrepareColors()
	{
		var colorList = PaintPartManager.Instance.GetColorList();

		CheckColorPickerCountIsEnough(colorList);

		for (var index = 0; index < colorPickerControllerList.Count; index++)
		{
			var colorPickerController = colorPickerControllerList[index];
			colorPickerController.SetColor(colorList[index]);
			colorPickerController.SetNumber(index + 1);
			colorPickerController.gameObject.SetActive(true);
			
			if(index == 0)
				colorPickerController.SetSelected();
		}
	}

	private void CheckColorPickerCountIsEnough(List<Color> colorList)
	{
		if (colorPickerControllerList.Count < colorList.Count)
		{
			var difference = colorList.Count - colorPickerControllerList.Count;
			for (int i = 0; i < difference; i++)
			{
				CreateColorPicker();
			}
		}
		else if (colorPickerControllerList.Count > colorList.Count)
		{
			var difference = colorPickerControllerList.Count - colorList.Count;
			for (int i = colorList.Count; i < colorPickerControllerList.Count; i++)
			{
				Destroy(colorPickerControllerList[i].gameObject);
			}

			colorPickerControllerList.RemoveRange(colorList.Count, difference);
		}
	}

	private void CreateColorPicker()
	{
		var colorPicker = Instantiate(colorPickerPrefab, colorPickerControllerList[0].transform.parent);
		colorPickerControllerList.Add(colorPicker.GetComponent<ColorPickerController>());
	}

	public void SetSelectedColorPicker(int index)
	{
		colorPickerControllerList[index].SetSelected();
	}
	
	public void SetCompletedPicker(int index)
	{
		colorPickerControllerList[index].SetCompleted(true);
	}
}