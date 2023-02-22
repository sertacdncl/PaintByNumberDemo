using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PaintPartGroup
{
	public bool isPainted;
	public Color groupColor;
	public List<PaintPartController> groupedPaintPartControllerList;
}