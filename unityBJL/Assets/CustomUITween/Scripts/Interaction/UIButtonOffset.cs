using UnityEngine;
using UnityEngine.EventSystems;


[AddComponentMenu("CustomUITween/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour, CustomUITweenEventSystemsInterface
{
	public Transform tweenTarget;
	public Vector3 hover = Vector3.zero;
	public Vector3 pressed = new Vector3(2f, -2f);
	public float duration = 0.2f;

	Vector3 mPos;
	bool mStarted = false;

	void Start ()
	{
		if (!mStarted)
		{
			mStarted = true;
			if (tweenTarget == null) tweenTarget = transform;
			mPos = tweenTarget.localPosition;
		}
	}

    void OnDisable()
    {
        if (mStarted && tweenTarget != null)
        {
            CustomTweenPosition tc = tweenTarget.GetComponent<CustomTweenPosition>();

            if (tc != null)
            {
                tc.value = mPos;
                tc.enabled = false;
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Offset(mPos + hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Offset(mPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Offset(mPos + pressed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Offset(mPos);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    void Offset(Vector3 to)
    {
        CustomTweenPosition.Begin(tweenTarget.gameObject, duration, to).easeType = EaseType.linear;
    }
}
