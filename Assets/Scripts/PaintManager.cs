using UnityEngine;

public class PaintManager : Singleton<PaintManager>
{
	private int _currentPart = 0;
	public int paintedCount = 0; 
	
	public void Prepare()
	{
		PaintPartManager.Instance.PrepareGroups();
		ColorPickerManager.Instance.PrepareColors();
		StartPainting();
	}

	public void StartPainting()
	{
		foreach (var paintPartController in PaintPartManager.Instance.paintPartGroups[_currentPart].groupedPaintPartControllerList)
		{
			paintPartController.SetPaintable();
		}
	}
	
	public void NextPaintPart()
	{
		paintedCount = 0;
		_currentPart++;
		if (_currentPart >= PaintPartManager.Instance.paintPartGroups.Count)
		{
			return;
		}
		StartPainting();
	}
	
	public void CheckPaintedParts()
	{
		paintedCount++;
		if (paintedCount >= PaintPartManager.Instance.paintPartGroups[_currentPart].groupedPaintPartControllerList.Count)
		{
			Debug.Log("All parts painted");
			NextPaintPart();
		}
	}
	

}
