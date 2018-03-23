using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 绘制顶级导航菜单
/// </summary>
static public class CustomUITweenMenu
{
    #region Tweens

    [MenuItem("CustomUITween/Tween/Custom Tween Alpha", false, 8)]
	static void Tween1 () { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenAlpha>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Alpha", true)]
    static bool Tween1a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<MaskableGraphic>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Color", false, 8)]
    static void Tween2() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenColor>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Color", true)]
    static bool Tween2a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<MaskableGraphic>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Width", false, 8)]
    static void Tween3() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenWidth>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Width", true)]
    static bool Tween3a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<RectTransform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Height", false, 8)]
    static void Tween4() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenHeight>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Height", true)]
    static bool Tween4a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<RectTransform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Position", false, 8)]
    static void Tween5() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenPosition>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Position", true)]
    static bool Tween5a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Rotation", false, 8)]
    static void Tween6() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenRotation>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Rotation", true)]
    static bool Tween6a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Scale", false, 8)]
    static void Tween7() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenScale>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Scale", true)]
    static bool Tween7a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Transform", false, 8)]
    static void Tween8() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenTransform>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Transform", true)]
    static bool Tween8a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Volume", false, 8)]
    static void Tween9() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenVolume>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Volume", true)]
    static bool Tween9a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<AudioSource>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Text", false, 8)]
    static void Tween10() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenText>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Text", true)]
    static bool Tween10a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Text>() != null); }

    [MenuItem("CustomUITween/Tween/Custom Tween Slider", false, 8)]
    static void Tween11() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<CustomTweenSlider>(); }

    [MenuItem("CustomUITween/Tween/Custom Tween Slider", true)]
    static bool Tween11a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Slider>() != null); }
#endregion

    #region Interaction


    [MenuItem("CustomUITween/Interaction/Button Offset", false, 9)]
    static void Interaction1() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<UIButtonOffset>(); }

    [MenuItem("CustomUITween/Interaction/Button Offset", true)]
    static bool Interaction1a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Interaction/Button Rotation", false, 9)]
    static void Interaction2() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<UIButtonRotation>(); }

    [MenuItem("CustomUITween/Interaction/Button Rotation", true)]
    static bool Interaction2a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Interaction/Button Scale", false, 9)]
    static void Interaction3() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<UIButtonScale>(); }

    [MenuItem("CustomUITween/Interaction/Button Scale", true)]
    static bool Interaction3a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Interaction/Button Activate", false, 9)]
    static void Interaction4() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<UIButtonActivate>(); }

    [MenuItem("CustomUITween/Interaction/Button Activate", true)]
    static bool Interaction4a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Transform>() != null); }

    [MenuItem("CustomUITween/Interaction/Slider Colors", false, 9)]
    static void Interaction5() { if (Selection.activeGameObject != null) Selection.activeGameObject.AddMissingComponent<UISliderColors>(); }

    [MenuItem("CustomUITween/Interaction/Slider Colors", true)]
    static bool Interaction5a() { return (Selection.activeGameObject != null) && (Selection.activeGameObject.GetComponent<Slider>() != null); }
    #endregion
}
