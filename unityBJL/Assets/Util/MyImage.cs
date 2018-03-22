using UnityEngine.UI;
using UnityEngine;

public class MyImage : Image  
{  
	public PolygonCollider2D polyCollider;  
	
	protected override void Awake()  
	{  
		this.polyCollider = this.GetComponent<PolygonCollider2D>();  

		Debug.LogError(this.polyCollider != null);  
	}  
	
	public override bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)  
	{  
		Vector3 world = eventCamera.ScreenToWorldPoint(new Vector3(sp.x, sp.y, 0));  
		return this.polyCollider.bounds.Contains(world);  
	}  
}  