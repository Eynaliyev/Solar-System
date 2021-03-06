using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu(SgtHelper.ComponentMenuPrefix + "Custom Starfield")]
public class SgtCustomStarfield : SgtStarfield
{
	public List<SgtStarfieldStar> Stars = new List<SgtStarfieldStar>();
	
	public static SgtCustomStarfield CreateCustomStarfield(Transform parent = null)
	{
		return CreateCustomStarfield(parent, Vector3.zero, Quaternion.identity, Vector3.one);
	}
	
	public static SgtCustomStarfield CreateCustomStarfield(Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
	{
		var gameObject = SgtHelper.CreateGameObject("Custom Starfield", parent, localPosition, localRotation, localScale);
		var starfield  = gameObject.AddComponent<SgtCustomStarfield>();
		
		return starfield;
	}
	
	protected override void CalculateStars(out List<SgtStarfieldStar> stars, out bool pool)
	{
		stars = Stars;
		pool  = false;
	}
	
#if UNITY_EDITOR
	[UnityEditor.MenuItem(SgtHelper.GameObjectMenuPrefix + "Custom Starfield", false, 10)]
	private static void CreateCustomStarfieldMenuItem()
	{
		var starfield = CreateCustomStarfield(SgtHelper.GetSelectedParent());
		
		SgtHelper.SelectAndPing(starfield);
	}
#endif
}