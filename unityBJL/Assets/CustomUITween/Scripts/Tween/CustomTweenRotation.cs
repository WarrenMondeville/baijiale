using UnityEngine;

/// <summary>
/// 旋转
/// </summary>

[AddComponentMenu("CustomUITween/Tween/Custom Tween Rotation")]
public class CustomTweenRotation : CustomUITweener
{
	public Vector3 from;
	public Vector3 to;

	Transform mTrans;

	public Transform cachedTransform 
    { 
        get 
        { 
            if (mTrans == null) 
                mTrans = transform; 
            return mTrans; 
        } 
    }

	public Quaternion value 
    { 
        get 
        { 
            return cachedTransform.localRotation; 
        } 
        set 
        { 
            cachedTransform.localRotation = value; 
        } 
    }

	protected override void OnUpdate (float factor, bool isFinished)
	{
		value = Quaternion.Euler(new Vector3(
			Mathf.Lerp(from.x, to.x, factor),
			Mathf.Lerp(from.y, to.y, factor),
			Mathf.Lerp(from.z, to.z, factor)));
	}

	/// <summary>
	/// 开始补间操作
	/// </summary>

	static public CustomTweenRotation Begin (GameObject go, float duration, Quaternion rot)
	{
		CustomTweenRotation comp = CustomUITweener.Begin<CustomTweenRotation>(go, duration);
		comp.from = comp.value.eulerAngles;
		comp.to = rot.eulerAngles;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("设置当前值为From的值")]
	public override void SetStartToCurrentValue () { from = value.eulerAngles; }

    [ContextMenu("设置当前值为To的值")]
	public override void SetEndToCurrentValue () { to = value.eulerAngles; }

	[ContextMenu("切换到From值状态")]
	void SetCurrentValueToStart () { value = Quaternion.Euler(from); }

    [ContextMenu("切换到To值状态")]
	void SetCurrentValueToEnd () { value = Quaternion.Euler(to); }
}
