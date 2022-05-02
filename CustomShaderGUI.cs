using UnityEngine;
using UnityEditor;
using System;

public abstract class CustomShaderGUI : ShaderGUI
{
	bool m_FirstTimeApply = true;

	#region Util
	protected void MakeFoldOutHeaderGroup(MaterialProperty materialProperty, string HeaderName, MaterialEditor materialEditor, Material material, Action<MaterialEditor, Material> action)
    {
        materialProperty.floatValue = EditorGUILayout.BeginFoldoutHeaderGroup(materialProperty.floatValue == 1, HeaderName) ? 1 : 0;
        if (materialProperty.floatValue == 1)
        {
            action?.Invoke(materialEditor, material);
            EditorGUILayout.Space();
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
    }

    protected void DoPopup(string label, MaterialProperty property, string[] options, MaterialEditor materialEditor)
    {
        if (property == null)
            throw new ArgumentNullException("property");

        EditorGUI.showMixedValue = property.hasMixedValue;

        var mode = property.floatValue;
        EditorGUI.BeginChangeCheck();
        mode = EditorGUILayout.Popup(label, (int)mode, options);
        if (EditorGUI.EndChangeCheck())
        {
            materialEditor.RegisterPropertyChangeUndo(label);
            property.floatValue = mode;
        }

        EditorGUI.showMixedValue = false;
    }
    #endregion

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        if (materialEditor == null)
        {
            Debug.LogError("materialEditor null");
            return;
        }

        FindProperties(properties);

        Material material = materialEditor.target as Material;

        if (m_FirstTimeApply)
        {
            int renderQueue = material.renderQueue;
            material.renderQueue = renderQueue;
            m_FirstTimeApply = false;
        }

        EditorGUI.BeginChangeCheck();

        DrawSurfaceInputs(materialEditor, material);

        if (EditorGUI.EndChangeCheck())
        {
            MaterialChanged(material);
        }
    }

    abstract protected void FindProperties(MaterialProperty[] properties);
    abstract protected void MaterialChanged(Material material);
    abstract protected void DrawSurfaceInputs(MaterialEditor materialEditor, Material material);


   

}
