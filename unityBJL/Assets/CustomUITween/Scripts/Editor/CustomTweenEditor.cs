using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTweenAlpha))]
public class CustomTweenAlphaEditor : CustomUITweenerEditor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Space(6f); 
        CustomUITweenEditorTools.SetLabelWidth(120f);

		CustomTweenAlpha tw = target as CustomTweenAlpha;
		GUI.changed = false;

		float from = EditorGUILayout.Slider("From", tw.from, 0f, 1f);
		float to = EditorGUILayout.Slider("To", tw.to, 0f, 1f);

		if (GUI.changed)
		{
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
			tw.from = from;
			tw.to = to;
            UnityEditor.EditorUtility.SetDirty(tw);
		}
		DrawCommonProperties();
	}
}


[CustomEditor(typeof(CustomTweenColor))]
public class CustomTweenColorEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenColor tw = target as CustomTweenColor;
        GUI.changed = false;

        Color from = EditorGUILayout.ColorField("From", tw.from);
        Color to = EditorGUILayout.ColorField("To", tw.to);

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


[CustomEditor(typeof(CustomTweenHeight))]
public class CustomTweenHeightEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenHeight tw = target as CustomTweenHeight;
        GUI.changed = false;

        int from = EditorGUILayout.IntField("From", tw.from);
        int to = EditorGUILayout.IntField("To", tw.to);
        bool table = EditorGUILayout.Toggle("Update Table", tw.updateTable);

        if (from < 0) from = 0;
        if (to < 0) to = 0;

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            tw.updateTable = table;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


[CustomEditor(typeof(CustomTweenPosition))]
public class CustomTweenPositionEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenPosition tw = target as CustomTweenPosition;
        GUI.changed = false;

        Vector3 from = EditorGUILayout.Vector3Field("From", tw.from);
        Vector3 to = EditorGUILayout.Vector3Field("To", tw.to);

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


[CustomEditor(typeof(CustomTweenRotation))]
public class CustomTweenRotationEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenRotation tw = target as CustomTweenRotation;
        GUI.changed = false;

        Vector3 from = EditorGUILayout.Vector3Field("From", tw.from);
        Vector3 to = EditorGUILayout.Vector3Field("To", tw.to);

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


[CustomEditor(typeof(CustomTweenScale))]
public class CustomTweenScaleEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenScale tw = target as CustomTweenScale;
        GUI.changed = false;

        Vector3 from = EditorGUILayout.Vector3Field("From", tw.from);
        Vector3 to = EditorGUILayout.Vector3Field("To", tw.to);
        bool table = EditorGUILayout.Toggle("Update Table", tw.updateTable);

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            tw.updateTable = table;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}

[CustomEditor(typeof(CustomTweenTransform))]
public class CustomTweenTransformEditor : CustomUITweenerEditor
{
}


[CustomEditor(typeof(CustomTweenVolume))]
public class CustomTweenVolumeEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenVolume tw = target as CustomTweenVolume;
        GUI.changed = false;

        float from = EditorGUILayout.Slider("From", tw.from, 0f, 1f);
        float to = EditorGUILayout.Slider("To", tw.to, 0f, 1f);

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


[CustomEditor(typeof(CustomTweenWidth))]
public class CustomTweenWidthEditor : CustomUITweenerEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(120f);

        CustomTweenWidth tw = target as CustomTweenWidth;
        GUI.changed = false;

        int from = EditorGUILayout.IntField("From", tw.from);
        int to = EditorGUILayout.IntField("To", tw.to);
        bool table = EditorGUILayout.Toggle("Update Table", tw.updateTable);

        if (from < 0) from = 0;
        if (to < 0) to = 0;

        if (GUI.changed)
        {
            CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
            tw.from = from;
            tw.to = to;
            tw.updateTable = table;
            CustomUITweenTools.SetDirty(tw);
        }

        DrawCommonProperties();
    }
}


#if UNITY_3_5
[CustomEditor(typeof(UITweener))]
#else
[CustomEditor(typeof(CustomUITweener), true)]
#endif
public class CustomUITweenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(6f);
        CustomUITweenEditorTools.SetLabelWidth(110f);
        base.OnInspectorGUI();
        DrawCommonProperties();
    }

    protected void DrawCommonProperties()
    {
        CustomUITweener tw = target as CustomUITweener;

        if (CustomUITweenEditorTools.DrawHeader("Tweener"))
        {
            CustomUITweenEditorTools.BeginContents();
            CustomUITweenEditorTools.SetLabelWidth(110f);

            GUI.changed = false;

            CustomUITweener.Style style = (CustomUITweener.Style)EditorGUILayout.EnumPopup("Play Style", tw.style);
            EaseType easeType = (EaseType)EditorGUILayout.EnumPopup("Ease Type", tw.easeType);
            AnimationCurve curve = EditorGUILayout.CurveField("Animation Curve", tw.animationCurve, GUILayout.Width(170f), GUILayout.Height(62f));
            GUILayout.BeginHorizontal();
            float dur = EditorGUILayout.FloatField("Duration", tw.duration, GUILayout.Width(170f));
            GUILayout.Label("seconds");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            float del = EditorGUILayout.FloatField("Start Delay", tw.delay, GUILayout.Width(170f));
            GUILayout.Label("seconds");
            GUILayout.EndHorizontal();

            int tg = EditorGUILayout.IntField("Tween Group", tw.tweenGroup, GUILayout.Width(170f));
            bool ts = EditorGUILayout.Toggle("Ignore TimeScale", tw.ignoreTimeScale);

            if (GUI.changed)
            {
                CustomUITweenEditorTools.RegisterUndo("Tween Change", tw);
                tw.easeType = easeType;
                tw.style = style;
                tw.ignoreTimeScale = ts;
                tw.tweenGroup = tg;
                tw.duration = dur;
                tw.delay = del;
                CustomUITweenTools.SetDirty(tw);
            }
            CustomUITweenEditorTools.EndContents();
        }

        CustomUITweenEditorTools.SetLabelWidth(80f);
        CustomUITweenEditorTools.DrawEvents("On Finished", tw, tw.onFinished);
    }
}
