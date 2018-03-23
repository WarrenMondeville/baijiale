using UnityEngine;

/// <summary>
/// Tween the audio source's volume.
/// </summary>

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("CustomUITween/Tween/Custom Tween Volume")]
public class CustomTweenVolume : CustomUITweener
{
	[Range(0f, 1f)] public float from = 1f;
	[Range(0f, 1f)] public float to = 1f;

	AudioSource mSource;

	public AudioSource audioSource
	{
		get
		{
			if (mSource == null)
			{
				mSource = GetComponent<AudioSource>();
				
				if (mSource == null)
				{
					mSource = GetComponent<AudioSource>();

					if (mSource == null)
					{
						Debug.LogError("TweenVolume needs an AudioSource to work with", this);
						enabled = false;
					}
				}
			}
			return mSource;
		}
	}

	public float value
	{
		get
		{
			return audioSource != null ? mSource.volume : 0f;
		}
		set
		{
			if (audioSource != null) mSource.volume = value;
		}
	}

	protected override void OnUpdate (float factor, bool isFinished)
	{
		value = from * (1f - factor) + to * factor;
		mSource.enabled = (mSource.volume > 0.01f);
	}

	/// <summary>
	/// 寮濮嬭ˉ闂存搷浣浱
	/// </summary>

	static public CustomTweenVolume Begin (GameObject go, float duration, float targetVolume)
	{
		CustomTweenVolume comp = CustomUITweener.Begin<CustomTweenVolume>(go, duration);
		comp.from = comp.value;
		comp.to = targetVolume;
		return comp;
	}

	public override void SetStartToCurrentValue () { from = value; }
	public override void SetEndToCurrentValue () { to = value; }
}
