using System.Collections.Generic;
using UnityEngine;

public class PaintPartManager : Singleton<PaintPartManager>
{
	[SerializeField] private List<PaintPartController> paintPartControllerList;
	public List<PaintPartGroup> paintPartGroups;

	public void PrepareGroups()
	{
		paintPartGroups = new List<PaintPartGroup>();
		foreach (var paintPartController in paintPartControllerList)
		{
			var groupIndex = paintPartGroups.FindIndex(x=>x.groupColor == paintPartController.targetColor);
			if (groupIndex >= 0)
			{
				paintPartGroups[groupIndex].groupedPaintPartControllerList.Add(paintPartController);
				paintPartController.SetNumber(groupIndex+1);
			}
			else
			{
				var paintPartGroup = new PaintPartGroup
				{
					groupColor = paintPartController.targetColor,
					groupedPaintPartControllerList = new List<PaintPartController> { paintPartController }
				};

				paintPartGroups.Add(paintPartGroup);
				paintPartController.SetNumber(paintPartGroups.Count);
			}
		}
	}

	public List<Color> GetColorList()
	{
		var colorList = new List<Color>();
		
		foreach (var group in paintPartGroups)
		{
			colorList.Add(group.groupColor);
		}

		return colorList;
	}
}