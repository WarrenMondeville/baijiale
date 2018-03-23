using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
[AddComponentMenu("CustomUITween/Tween/Custom Tween Text")]
public class CustomTweenText : CustomUITweener
{

    public float from;
    public float to;

    float mValue;

    private Text mText;
    public Text cacheText
    {
        get
        {
            mText = GetComponent<Text>();
            if (mText == null)
            {
                Debug.LogError("Text null");
            }
            return mText;
        }
    }

    /// <summary>
    /// 小数位
    /// </summary>
    public int digits;


    public float value
    {
        get { return mValue; }
        set
        {
            mValue = value;
        }
    }

    protected override void OnUpdate(float factor, bool isFinished)
    {
        value = from + factor * (to - from);
        ValueUpdate(value, isFinished);
    }


    protected void ValueUpdate(float value, bool isFinished)
    {
        cacheText.text = (System.Math.Round(value, digits)).ToString();
    }

    public static CustomTweenText Begin(Text label, float duration, float delay, float from, float to)
    {
        CustomTweenText comp = CustomUITweener.Begin<CustomTweenText>(label.gameObject, duration);
        comp.from = from;
        comp.to = to;
        comp.delay = delay;

        if (duration <= 0)
        {
            comp.Sample(1, true);
            comp.enabled = false;
        }
        return comp;
    }
}
