using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("CustomUITween/Tween/Custom Tween Alpha")]
public class CustomTweenAlpha : CustomUITweener
{
#if UNITY_3_5
	public float from = 1f;
	public float to = 1f;
#else
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;
#endif
    ImageEffectOpaque dd;
    MaskableGraphic mMaskableGraphic;
    Color mColor;

    public MaskableGraphic cachedMaskableGraphic
	{
		get
		{
            if (mMaskableGraphic == null)
			{
                mMaskableGraphic = GetComponent<MaskableGraphic>();
                if (mMaskableGraphic == null) mMaskableGraphic = GetComponentInChildren<MaskableGraphic>();
			}
            mColor = mMaskableGraphic.color;
            return mMaskableGraphic;
		}
	}

	public float value 
    { 
        get 
        {
            return alpha;
        } 
        set 
        {
            alpha = value;
        }
    }

    public float alpha
    {
        get
        {
            return cachedMaskableGraphic.color.a;
        }
        set
        {
            cachedMaskableGraphic.color = new Color(mColor.r, mColor.g, mColor.b, value);
        }
    }

	protected override void OnUpdate (float factor, bool isFinished) { value = Mathf.Lerp(from, to, factor); }

	/// <summary>
	/// 开始补间操作
	/// </summary>

	static public CustomTweenAlpha Begin (GameObject go, float duration, float alpha)
	{
		CustomTweenAlpha comp = CustomUITweener.Begin<CustomTweenAlpha>(go, duration);
		comp.from = comp.value;
		comp.to = alpha;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
