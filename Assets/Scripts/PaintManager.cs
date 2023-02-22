using UnityEngine;

public class PaintManager : Singleton<PaintManager>
{
	private int _currentPart = 0;

	private int PaintedCount
	{
		get
		{
			var count = 0;
			foreach (var paintPartController in PaintPartManager.Instance.paintPartGroups[_currentPart]
						.groupedPaintPartControllerList)
			{
				if (paintPartController.IsPainted)
					count++;
			}

			return count;
		}
	}
	
	private int PaintedGroupCount
	{
		get
		{
			var count = 0;
			foreach (var paintPartGroup in PaintPartManager.Instance.paintPartGroups)
			{
				if (paintPartGroup.isPainted)
					count++;
			}

			return count;
		}
	}

	public void Prepare()
	{
		PaintPartManager.Instance.PrepareGroups();
		ColorPickerManager.Instance.PrepareColors();
		SetPaintableGroup(true);
	}

	public void SetPaintableGroup(bool isPaintable)
	{
		foreach (var paintPartController in PaintPartManager.Instance.paintPartGroups[_currentPart]
					.groupedPaintPartControllerList)
		{
			if (isPaintable)
				paintPartController.SetPaintable();
			else
				paintPartController.SetNotPaintable();
		}
		if(isPaintable)
			ColorPickerManager.Instance.SetSelectedColorPicker(_currentPart);
	}

	public void SetPaintPart(int index)
	{
		SetPaintableGroup(false);
		_currentPart = index;
		SetPaintableGroup(true);
	}

	public void NextPaintPart()
	{
		if (PaintedGroupCount >= PaintPartManager.Instance.paintPartGroups.Count)
		{
			
			return;
		}
		
		//Find next paintable group
		for (int index = 0; index < PaintPartManager.Instance.paintPartGroups.Count; index++)
		{
			var paintPartGroup = PaintPartManager.Instance.paintPartGroups[index];
			if (!paintPartGroup.isPainted)
			{
				_currentPart = index;
				break;
			}
		}

		SetPaintableGroup(true);
	}

	public void CheckPaintedParts()
	{
		if (PaintedCount >= PaintPartManager.Instance.paintPartGroups[_currentPart].groupedPaintPartControllerList.Count)
		{
			Debug.Log("All parts painted");
			PaintPartManager.Instance.paintPartGroups[_currentPart].isPainted = true;
			ColorPickerManager.Instance.SetCompletedPicker(_currentPart);
			NextPaintPart();
		}
	}
}