using UnityEditor;
using System;
using UnityEngine.Rendering;
using UnityEngine;

public class LitSpecularWithMaskGUI : CustomShaderGUI
{
	public enum WorkflowMode
	{
		Specular = 0,
		Metallic
	}
	public enum RenderFace
	{
		Front = 2,
		Back = 1,
		Both = 0
	}

	#region MaterialProperty
	MaterialProperty _Cull;
	MaterialProperty _WorkflowMode;
	MaterialProperty _BaseColor;
	MaterialProperty _BaseMap;

	MaterialProperty _Cutoff;

	MaterialProperty _Smoothness;
	MaterialProperty _GlossMapScale;
	MaterialProperty _SmoothnessTextureChannel;

	MaterialProperty _Metallic;
	MaterialProperty _MetallicGlossMap;
	MaterialProperty _MetallicOcclusionStrength;

	MaterialProperty _SpecColor;
	MaterialProperty _SpecGlossMap;
	MaterialProperty _SpecularHighlights;
	MaterialProperty _EnvironmentReflections;

	MaterialProperty _BumpScale;
	MaterialProperty _BumpMap;
	MaterialProperty _ApplyNormalDiffuse;
	MaterialProperty _Bias;
	MaterialProperty _VertexNormal;

	MaterialProperty _EmissionColor;
	MaterialProperty _EmissionMap;
	MaterialProperty _EmissionIntensity;

	MaterialProperty _UseEffectMode;
	MaterialProperty _Mask;
	MaterialProperty _MainFlowTex;
	MaterialProperty _FlowTex;
	MaterialProperty _Color;

	MaterialProperty _UseDesaturate;
	MaterialProperty _MainTexSpeed;
	MaterialProperty _FlowSpeed;
	MaterialProperty _FlowDistorStrength;
	MaterialProperty _PatternIntensity;
	MaterialProperty _PatternIntensityAdd;
	MaterialProperty _PatternIntensitySpeed;
	MaterialProperty _FresnelColor;
	MaterialProperty _FresnelScale;
	MaterialProperty _FresnelScaleAdd;
	MaterialProperty _FresnelSpeed;

	MaterialProperty _ReceiveShadows;
	MaterialProperty _ShadowBias;
	MaterialProperty _ShadowSamplingBias;

	MaterialProperty _UseMaskMode;
	MaterialProperty _MaskTex;
	MaterialProperty _Color1;
	MaterialProperty _Color2;
	MaterialProperty _Color3;
	MaterialProperty _Color4;

	MaterialProperty _CustomCubeMap;
	MaterialProperty _envmap;
	MaterialProperty _CubeIntensity;

	MaterialProperty _Ambientscale;

	MaterialProperty _DissolveOn;
	MaterialProperty _DissolveMap;
	MaterialProperty _DissolveAmount;

	MaterialProperty _DissolveGlow;
	MaterialProperty _GlowColor;
	MaterialProperty _GlowIntensity;

	MaterialProperty _OuterEdgeColor;
	MaterialProperty _InnerEdgeColor;
	MaterialProperty _OuterEdgeThickness;
	MaterialProperty _InnerEdgeThickness;

	MaterialProperty _GlowFollow;
	MaterialProperty _EdgeColorRamp;

	MaterialProperty _UseEdgeColorRamp;

	MaterialProperty _OnOffRimMode;
	MaterialProperty _RimColor;
	MaterialProperty _RimPower;
	MaterialProperty _RimFrequency;
	MaterialProperty _RimMinPower;
	MaterialProperty _RimPerPositionFrequency;

	MaterialProperty _UseLightMode;
	MaterialProperty _LightCol;
	MaterialProperty _CustomLight;
	MaterialProperty _LightValue;

	MaterialProperty _OnOffDetail;
	MaterialProperty _DetailMask;
	MaterialProperty _DetailAlbedoMap;
	MaterialProperty _DetailNormalMap;
	MaterialProperty _DetailNormalMapScale;

	MaterialProperty _InGame;

	MaterialProperty _DisableCustomLightMode;

	MaterialProperty _StencilInt;
	MaterialProperty _StencilComp;

	MaterialProperty _StencilOp;

	MaterialProperty _StencilFail;

	MaterialProperty _StencilZFail;

	MaterialProperty _Surface;
	MaterialProperty _Blend;
	MaterialProperty _AlphaClip;
	MaterialProperty _SrcBlend;
	MaterialProperty _DstBlend;
	MaterialProperty _ZWrite;

	//
	MaterialProperty _SurfaceOptionT;
	MaterialProperty _ShadowT;
	MaterialProperty _SurfaceInputsT;
	MaterialProperty _MetallicSpecMaskT;
	MaterialProperty _EmissionT;
	MaterialProperty _EnableNormalMapT;
	MaterialProperty _RimlightingT;
	MaterialProperty _MaskSetT;
	MaterialProperty _CustomCubeMapT;
	MaterialProperty _LightSetT;
	MaterialProperty _UseEffectT;
	MaterialProperty _DissolveT;
	MaterialProperty _DetailInputsT;
	MaterialProperty _AdvancedT;


	//MaterialProperty _Cull;
	#endregion
	void SetKeyword(Material m, string keyword, bool state)
	{
		if (state)
			m.EnableKeyword(keyword);
		else
			m.DisableKeyword(keyword);
	}

	override protected void FindProperties(MaterialProperty[] properties)
	{
		_Cull = FindProperty("_Cull", properties);
		_WorkflowMode = FindProperty("_WorkflowMode", properties);
		_BaseColor = FindProperty("_BaseColor", properties);
		_BaseMap = FindProperty("_BaseMap", properties);

		_Cutoff = FindProperty("_Cutoff", properties);

		_Smoothness = FindProperty("_Smoothness", properties);
		_GlossMapScale = FindProperty("_GlossMapScale", properties);
		_SmoothnessTextureChannel = FindProperty("_SmoothnessTextureChannel", properties);

		_Metallic = FindProperty("_Metallic", properties);
		_MetallicGlossMap = FindProperty("_MetallicGlossMap", properties);
		_MetallicOcclusionStrength = FindProperty("_MetallicOcclusionStrength", properties); 

		_SpecColor = FindProperty("_SpecColor", properties);
		_SpecGlossMap = FindProperty("_SpecGlossMap", properties);
		_SpecularHighlights = FindProperty("_SpecularHighlights", properties);
		_EnvironmentReflections = FindProperty("_EnvironmentReflections", properties);

		_BumpScale = FindProperty("_BumpScale", properties);
		_BumpMap = FindProperty("_BumpMap", properties);
		_ApplyNormalDiffuse = FindProperty("_ApplyNormalDiffuse", properties);
		_Bias = FindProperty("_Bias", properties);
		_VertexNormal = FindProperty("_VertexNormal", properties);

		_EmissionColor = FindProperty("_EmissionColor", properties);
		_EmissionMap = FindProperty("_EmissionMap", properties);
		_EmissionIntensity = FindProperty("_EmissionIntensity", properties);

		_UseEffectMode = FindProperty("_UseEffectMode", properties);
		_Mask = FindProperty("_Mask", properties);
		_MainFlowTex = FindProperty("_MainFlowTex", properties);
		_FlowTex = FindProperty("_FlowTex", properties);
		_Color = FindProperty("_Color", properties);

		_UseDesaturate = FindProperty("_UseDesaturate", properties);
		_MainTexSpeed = FindProperty("_MainTexSpeed", properties);
		_FlowSpeed = FindProperty("_FlowSpeed", properties);
		_FlowDistorStrength = FindProperty("_FlowDistorStrength", properties);
		_PatternIntensity = FindProperty("_PatternIntensity", properties);
		_PatternIntensityAdd = FindProperty("_PatternIntensityAdd", properties);
		_PatternIntensitySpeed = FindProperty("_PatternIntensitySpeed", properties);
		_FresnelColor = FindProperty("_FresnelColor", properties);
		_FresnelScale = FindProperty("_FresnelScale", properties);
		_FresnelScaleAdd = FindProperty("_FresnelScaleAdd", properties);
		_FresnelSpeed = FindProperty("_FresnelSpeed", properties);

		_ReceiveShadows = FindProperty("_ReceiveShadows", properties);
		_ShadowBias = FindProperty("_ShadowBias", properties);
		_ShadowSamplingBias = FindProperty("_ShadowSamplingBias", properties);

		_UseMaskMode = FindProperty("_UseMaskMode", properties);
		_MaskTex = FindProperty("_MaskTex", properties);
		_Color1 = FindProperty("_Color1", properties);
		_Color2 = FindProperty("_Color2", properties);
		_Color3 = FindProperty("_Color3", properties);
		_Color4 = FindProperty("_Color4", properties);

		_CustomCubeMap = FindProperty("_CustomCubeMap", properties);
		_envmap = FindProperty("_envmap", properties);
		_CubeIntensity = FindProperty("_CubeIntensity", properties);


		_UseLightMode = FindProperty("_UseLightMode", properties);
		_LightCol = FindProperty("_LightCol", properties);
		_Ambientscale = FindProperty("_Ambientscale", properties);

		_DissolveOn = FindProperty("_DissolveOn", properties);
		_DissolveMap = FindProperty("_DissolveMap", properties);
		_DissolveAmount = FindProperty("_DissolveAmount", properties);

		_DissolveGlow = FindProperty("_DissolveGlow", properties);
		_GlowColor = FindProperty("_GlowColor", properties);
		_GlowIntensity = FindProperty("_GlowIntensity", properties);

		_OuterEdgeColor = FindProperty("_OuterEdgeColor", properties);
		_InnerEdgeColor = FindProperty("_InnerEdgeColor", properties);
		_OuterEdgeThickness = FindProperty("_OuterEdgeThickness", properties);
		_InnerEdgeThickness = FindProperty("_InnerEdgeThickness", properties);

		_GlowFollow = FindProperty("_GlowFollow", properties);
		_EdgeColorRamp = FindProperty("_EdgeColorRamp", properties);

		_UseEdgeColorRamp = FindProperty("_UseEdgeColorRamp", properties);

		_OnOffRimMode = FindProperty("_OnOffRimMode", properties);
		_RimColor = FindProperty("_RimColor", properties);
		_RimPower = FindProperty("_RimPower", properties);
		_RimFrequency = FindProperty("_RimFrequency", properties);
		_RimMinPower = FindProperty("_RimMinPower", properties);
		_RimPerPositionFrequency = FindProperty("_RimPerPositionFrequency", properties);

		_CustomLight = FindProperty("_CustomLight", properties);
		_LightValue = FindProperty("_LightValue", properties);

		_OnOffDetail = FindProperty("_OnOffDetail", properties);
		_DetailMask = FindProperty("_DetailMask", properties);
		_DetailAlbedoMap = FindProperty("_DetailAlbedoMap", properties);
		_DetailNormalMap = FindProperty("_DetailNormalMap", properties);
		_DetailNormalMapScale = FindProperty("_DetailNormalMapScale", properties);

		_InGame = FindProperty("_InGame", properties);

		_DisableCustomLightMode = FindProperty("_DisableCustomLightMode", properties);

		_StencilInt = FindProperty("_StencilInt", properties);
		_StencilComp = FindProperty("_StencilComp", properties);

		_StencilOp = FindProperty("_StencilOp", properties);

		_StencilFail = FindProperty("_StencilFail", properties);

		_StencilZFail = FindProperty("_StencilZFail", properties);

		_Surface = FindProperty("_Surface", properties);
		_Blend = FindProperty("_Blend", properties);
		_AlphaClip = FindProperty("_AlphaClip", properties);
		_SrcBlend = FindProperty("_SrcBlend", properties);
		_DstBlend = FindProperty("_DstBlend", properties);
		_ZWrite = FindProperty("_ZWrite", properties);

		//
		_SurfaceOptionT = FindProperty("_SurfaceOptionT", properties);
		_ShadowT = FindProperty("_ShadowT", properties);
		_SurfaceInputsT = FindProperty("_SurfaceInputsT", properties);
		_MetallicSpecMaskT = FindProperty("_MetallicSpecMaskT", properties);
		_EmissionT = FindProperty("_EmissionT", properties);
		_EnableNormalMapT = FindProperty("_EnableNormalMapT", properties);
		_RimlightingT = FindProperty("_RimlightingT", properties);
		_MaskSetT = FindProperty("_MaskSetT", properties);
		_CustomCubeMapT = FindProperty("_CustomCubeMapT", properties);
		_LightSetT = FindProperty("_LightSetT", properties);
		_UseEffectT = FindProperty("_UseEffectT", properties);
		_DissolveT = FindProperty("_DissolveT", properties);
		_DetailInputsT = FindProperty("_DetailInputsT", properties);
		_AdvancedT = FindProperty("_AdvancedT", properties);
	}
	override protected void MaterialChanged(Material material)
	{
		SetupMaterial(material);
	}

	void SetupMaterial(Material material)
	{
		if (material == null)
			throw new ArgumentNullException("material");

		bool alphaClip = false;
		if (material.HasProperty("_AlphaClip"))
			alphaClip = material.GetFloat("_AlphaClip") >= 0.5;

		if (alphaClip)
		{
			material.EnableKeyword("_ALPHATEST_ON");
		}
		else
		{
			material.DisableKeyword("_ALPHATEST_ON");
		}

		if (material.renderQueue < 2726)
		{
			if (alphaClip)
			{
				material.SetOverrideTag("RenderType", "TransparentCutout");
			}
			else
			{
				material.SetOverrideTag("RenderType", "Opaque");
			}

			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			material.SetInt("_ZWrite", 1);
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.SetShaderPassEnabled("ShadowCaster", true);
		}
		else
		{
			BlendMode blendMode = (BlendMode)material.GetFloat("_Blend");
			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

			// General Transparent Material Settings
			material.SetOverrideTag("RenderType", "Transparent");
			material.SetInt("_ZWrite", 0);
			material.SetShaderPassEnabled("ShadowCaster", false);
		}

		if (material.GetInt("_CustomLight") == 1)
		{
			material.EnableKeyword("_CUSTOMCHARACTERLIGHT");
		}
		else
		{
			material.DisableKeyword("_CUSTOMCHARACTERLIGHT");
		}

		if (material.GetInt("_CustomCubeMap") == 1)
		{
			material.EnableKeyword("_CUSTOMCUBEMAP");
		}
		else
		{
			material.DisableKeyword("_CUSTOMCUBEMAP");
		}

		if (material.GetInt("_OnOffRimMode") == 1)
		{
			material.EnableKeyword("_OnOffRim");
		}
		else
		{
			material.DisableKeyword("_OnOffRim");
		}

		if (material.GetInt("_UseMaskMode") == 1)
		{
			material.EnableKeyword("_UseMask");
		}
		else
		{
			material.DisableKeyword("_UseMask");
		}

		if (material.GetInt("_UseLightMode") == 1)
		{
			material.EnableKeyword("_UseLight");
		}
		else
		{
			material.DisableKeyword("_UseLight");
		}

		if (material.GetInt("_UseEffectMode") == 1)
		{
			material.EnableKeyword("_UseEffect");
		}
		else
		{
			material.DisableKeyword("_UseEffect");
		}

		if (material.GetInt("_DissolveOn") == 1)
		{
			material.EnableKeyword("_UseDissolve");
		}
		else
		{
			material.DisableKeyword("_UseDissolve");
		}

		if (material.GetInt("_DisableCustomLightMode") == 1)
		{
			material.EnableKeyword("_DISABLECUSTOMLIGHTMODEON");
		}
		else
		{
			material.DisableKeyword("_DISABLECUSTOMLIGHTMODEON");
		}

		if (_ApplyNormalDiffuse.floatValue == 1)
		{
			material.EnableKeyword("_NORMALMAPDIFFUSE");
		}
		else
		{
			material.DisableKeyword("_NORMALMAPDIFFUSE");

		}

		// Receive Shadows
		if (material.HasProperty("_ReceiveShadows"))
			CoreUtils.SetKeyword(material, "_RECEIVE_SHADOWS_OFF", material.GetFloat("_ReceiveShadows") == 0.0f);

		// Emission
		if (material.HasProperty("_EmissionColor"))
			MaterialEditor.FixupEmissiveFlag(material);
		bool shouldEmissionBeEnabled =
			(material.globalIlluminationFlags & MaterialGlobalIlluminationFlags.EmissiveIsBlack) == 0;
		if (material.HasProperty("_EmissionEnabled") && !shouldEmissionBeEnabled)
			shouldEmissionBeEnabled = material.GetFloat("_EmissionEnabled") >= 0.5f;
		CoreUtils.SetKeyword(material, "_EMISSION", shouldEmissionBeEnabled);

		// Normal Map
		if (material.HasProperty("_BumpMap"))
			CoreUtils.SetKeyword(material, "_NORMALMAP", material.GetTexture("_BumpMap"));

		if (material.HasProperty("_EmissionMap"))
			CoreUtils.SetKeyword(material, "_EMISSION", material.GetTexture("_EmissionMap"));

		var hasGlossMap = false;

		var isSpecularWorkFlow = material.GetFloat("_WorkflowMode") == 0;

		var opaque = ((SurfaceType)material.GetFloat("_Surface") ==
					 SurfaceType.Opaque);

		if (isSpecularWorkFlow)
		{
			hasGlossMap = material.GetTexture("_SpecGlossMap") != null;
		}
		else
		{
			hasGlossMap = material.GetTexture("_MetallicGlossMap") != null;
		}

		SetKeyword(material, "_SPECULAR_SETUP", isSpecularWorkFlow);

		SetKeyword(material, "_METALLICSPECGLOSSMAP", hasGlossMap);

		if (material.HasProperty("_SpecularHighlights"))
			SetKeyword(material, "_SPECULARHIGHLIGHTS_OFF",
				material.GetFloat("_SpecularHighlights") == 0.0f);
		if (material.HasProperty("_EnvironmentReflections"))
			SetKeyword(material, "_ENVIRONMENTREFLECTIONS_OFF",
				material.GetFloat("_EnvironmentReflections") == 0.0f);
		if (material.HasProperty("_OcclusionMap"))
			SetKeyword(material, "_OCCLUSIONMAP", material.GetTexture("_OcclusionMap"));

	}

	override protected void DrawSurfaceInputs(MaterialEditor materialEditor, Material material)
	{
		MakeFoldOutHeaderGroup(_SurfaceOptionT, "Surface Options", materialEditor, material, OnDrawSurfaceOption);
		MakeFoldOutHeaderGroup(_ShadowT, "Shadow", materialEditor, material, OnDrawShadow);
		MakeFoldOutHeaderGroup(_SurfaceInputsT, "Surface Inputs", materialEditor, material, OnDrawSurfaceInputs);

		string strMetallicSpec = ((WorkflowMode)_WorkflowMode.floatValue == WorkflowMode.Metallic) ? "Metallic Mask" : "Specular Mask";
		MakeFoldOutHeaderGroup(_MetallicSpecMaskT, strMetallicSpec, materialEditor, material, OnDrawMetallicSpecMask);

		MakeFoldOutHeaderGroup(_EmissionT, "Emission", materialEditor, material, OnDrawEmission);
		MakeFoldOutHeaderGroup(_EnableNormalMapT, "Enable Normal Map", materialEditor, material, OnDrawEnableNormalMap);
		MakeFoldOutHeaderGroup(_RimlightingT, "Rim lighting", materialEditor, material, OnDrawRimlighting);
		MakeFoldOutHeaderGroup(_MaskSetT, "Mask Set", materialEditor, material, OnDrawMaskSet);
		MakeFoldOutHeaderGroup(_CustomCubeMapT, "Custom CubeMap", materialEditor, material, OnDrawCustomCubeMap);		
		MakeFoldOutHeaderGroup(_LightSetT, "Light Set", materialEditor, material, OnDrawLightSet);
		MakeFoldOutHeaderGroup(_UseEffectT, "Use Effect", materialEditor, material, OnDrawUseEffect);
		MakeFoldOutHeaderGroup(_DissolveT, "Dissolve", materialEditor, material, OnDrawDissolve);
		materialEditor.ShaderProperty(_DisableCustomLightMode, "Disable Custom Light Specular");
		MakeFoldOutHeaderGroup(_DetailInputsT, "Detail Inputs", materialEditor, material, OnDrawDetailInputs);
		materialEditor.ShaderProperty(_InGame, "InGame");
		MakeFoldOutHeaderGroup(_AdvancedT, "Advanced", materialEditor, material, OnDrawAdvanced);
	}

	void OnDrawSurfaceOption(MaterialEditor materialEditor, Material material)
	{
		//_WorkflowMode
		DoPopup("Workflow Mode", _WorkflowMode, Enum.GetNames(typeof(WorkflowMode)), materialEditor);

		//_Cull
		DoPopup("Culling", _Cull, Enum.GetNames(typeof(CullMode)), materialEditor);
		if (_Cull.floatValue == 0.0f)
		{
			if (material.doubleSidedGI == false)
			{
				Debug.Log("Material " + material.name + ": Double Sided Global Illumination enabled.", material);
			}
			material.doubleSidedGI = true;
		}
		else
		{
			if (material.doubleSidedGI == true)
			{
				Debug.Log("Material " + material.name + ": Double Sided Global Illumination disabled.", material);
			}
			material.doubleSidedGI = false;
		}

		DoPopup("Surface Type", _Surface, Enum.GetNames(typeof(SurfaceType)), materialEditor);
		if ((SurfaceType)_Surface.floatValue == SurfaceType.Transparent)
			DoPopup("Blend", _Blend, Enum.GetNames(typeof(BlendMode)), materialEditor);

	}
	void OnDrawShadow(MaterialEditor materialEditor, Material material)
	{
		//_ReceiveShadows
		materialEditor.ShaderProperty(_ReceiveShadows, "Receive Shadows");

		//_ShadowBias
		materialEditor.ShaderProperty(_ShadowBias, "Shadow Bias");

		//_ShadowSamplingBias
		materialEditor.ShaderProperty(_ShadowSamplingBias, "Shadow Sampling Bias");
	}
	void OnDrawSurfaceInputs(MaterialEditor materialEditor, Material material)
	{
		//_BaseMap
		materialEditor.ShaderProperty(_BaseMap, "Albedo (RGB) Alpha (A)");

		//_BaseColor
		materialEditor.ShaderProperty(_BaseColor, "Base Color");

		//_AlphaClip
		materialEditor.ShaderProperty(_AlphaClip, "Alpha Clipping");

		if(_AlphaClip.floatValue == 1.0)
		{
			//Threshold
			materialEditor.ShaderProperty(_Cutoff, "Threshold");
		}		
	}
	void OnDrawMetallicSpecMask(MaterialEditor materialEditor, Material material)
	{
		bool hasGlossMap = false;
		if ((WorkflowMode)_WorkflowMode.floatValue == WorkflowMode.Metallic)
		{
			hasGlossMap = _MetallicGlossMap.textureValue != null;
			materialEditor.ShaderProperty(_MetallicGlossMap, "Metallic (R) Roughness (G) Occlusion (B) Emissive (A)");

			EditorGUI.BeginChangeCheck();
			//materialEditor.ShaderProperty(_Metallic, "Metallic");
			var Metallic = EditorGUILayout.Slider("Metallic", _Metallic.floatValue - 1, -1f, 1f);
			if (EditorGUI.EndChangeCheck())
				_Metallic.floatValue = Metallic + 1;

			EditorGUI.BeginChangeCheck();
			//EditorGUI.showMixedValue = _Smoothness.hasMixedValue;
			decimal smoothness = (decimal)EditorGUILayout.Slider(SkinPropertiesStyles.roughnessText,  (_Smoothness.floatValue + 0.5f) * -1f, -0.5f, 0.5f);

			if (EditorGUI.EndChangeCheck())
			{
				_Smoothness.floatValue = (float)(smoothness + (decimal)0.5) * -1f;
			}
			

			EditorGUI.BeginChangeCheck();
			var occ = EditorGUILayout.Slider("Occlusion", (_MetallicOcclusionStrength.floatValue - 1f), -1f, 1f);
			//materialEditor.ShaderProperty(_MetallicOcclusionStrength, "Occlusion");
			if (EditorGUI.EndChangeCheck())
				_MetallicOcclusionStrength.floatValue = occ + 1f;
			//EditorGUI.showMixedValue = false;
		}
		else
		{
			hasGlossMap = _SpecGlossMap.textureValue != null;
			materialEditor.ShaderProperty(_SpecGlossMap, "Specular (RGB) Smoothness (A)");

			if (!hasGlossMap)
			{
				materialEditor.ColorProperty(_SpecColor, "Spec Color");
			}

			EditorGUI.BeginChangeCheck();
			//EditorGUI.showMixedValue = _Smoothness.hasMixedValue;

			EditorGUI.BeginChangeCheck();
			//EditorGUI.showMixedValue = _Smoothness.hasMixedValue;
			var smoothness = EditorGUILayout.Slider(SkinPropertiesStyles.roughnessText, (_Smoothness.floatValue - 0.5f), -0.5f, 0.5f);
			if (EditorGUI.EndChangeCheck())
				_Smoothness.floatValue = smoothness + 0.5f;
			//EditorGUI.showMixedValue = false;
		}
	}
	void OnDrawEmission(MaterialEditor materialEditor, Material material)
	{
		//_EmissiveMap
		materialEditor.ShaderProperty(_EmissionMap, "Emission Map");

		//_EmissiveColor
		materialEditor.ColorProperty(_EmissionColor, "Emission Color");

		//_EmissiveIntensity
		materialEditor.ShaderProperty(_EmissionIntensity, "Emission Intensity");
	}
	void OnDrawEnableNormalMap(MaterialEditor materialEditor, Material material)
	{
		//_BumpMap, _BumpScale
		BaseShaderGUI.DrawNormalArea(materialEditor, _BumpMap, _BumpScale);

		//_ApplyNormalDiffuse
		materialEditor.ShaderProperty(_ApplyNormalDiffuse, "Enable Diffuse Normal Sample");

		//_Bias
		materialEditor.ShaderProperty(_Bias, "Bias");

		//_VertexNormal
		materialEditor.ShaderProperty(_VertexNormal, "Use Vertex Normal for Diffuse");
	}
	void OnDrawRimlighting(MaterialEditor materialEditor, Material material)
	{
		//_Rim
		materialEditor.ShaderProperty(_OnOffRimMode, "Enable Rim");

		//_RimColor
		materialEditor.ShaderProperty(_RimColor, "Rim Color");

		//_RimPower
		materialEditor.ShaderProperty(_RimPower, "Rim Power");

		//_RimFrequency
		materialEditor.ShaderProperty(_RimFrequency, "Rim Frequency");

		//_RimMinPower
		materialEditor.ShaderProperty(_RimMinPower, "Rim Min Power");

		//_RimPerPositionFrequency
		materialEditor.ShaderProperty(_RimPerPositionFrequency, "Rim PerPosition Frequency");
	}
	void OnDrawMaskSet(MaterialEditor materialEditor, Material material)
	{
		//_Mask
		materialEditor.ShaderProperty(_UseMaskMode, "Use Mask");

		//_MaskTex
		materialEditor.ShaderProperty(_MaskTex, "Mask (RGBA)");

		//_Color1
		materialEditor.ShaderProperty(_Color1, "R");

		//_Color2
		materialEditor.ShaderProperty(_Color2, "G");

		//_Color3
		materialEditor.ShaderProperty(_Color3, "B");

		//_Color4
		materialEditor.ShaderProperty(_Color4, "A");
	}
	void OnDrawCustomCubeMap(MaterialEditor materialEditor, Material material)
	{
		//_CustomCubeMap
		materialEditor.ShaderProperty(_CustomCubeMap, "Use Custom CubeMap");

		//_Envmap
		materialEditor.ShaderProperty(_envmap, "Cube Map");

		//_CubeIntensity
		materialEditor.ShaderProperty(_CubeIntensity, "Cube Intensity");
	}
	void OnDrawLightSet(MaterialEditor materialEditor, Material material)
	{
		//_Light;
		materialEditor.ShaderProperty(_UseLightMode, "Use Light");

		//_LightCol;
		materialEditor.ShaderProperty(_LightCol, "Inner Light Color");

		//_CustomLight
		materialEditor.ShaderProperty(_CustomLight, "Use Custom Character Light");

		//_LightValue;
		materialEditor.ShaderProperty(_LightValue, "Light Value");
	}
	void OnDrawUseEffect(MaterialEditor materialEditor, Material material)
	{
		//_UseEffectMode
		materialEditor.ShaderProperty(_UseEffectMode, "Use Effect Mode");

		//_Mask
		materialEditor.ShaderProperty(_Mask, "Use Mask");

		//_MainFlowTex
		materialEditor.ShaderProperty(_MainFlowTex, "Main FlowTex");

		//_FlowTex
		materialEditor.ShaderProperty(_FlowTex, "FlowTex");

		//_Color
		materialEditor.ShaderProperty(_Color, "Color");

		//_UseDesaturate
		materialEditor.ShaderProperty(_UseDesaturate, "Use Desaturatet");

		//_MainTexSpeed
		materialEditor.ShaderProperty(_MainTexSpeed, "MainTex Speed");

		//_FlowSpeed
		materialEditor.ShaderProperty(_FlowSpeed, "Flow Speed");

		//_FlowDistorStrength
		materialEditor.ShaderProperty(_FlowDistorStrength, "Flow Distor Strength");

		//_PatternIntensity
		materialEditor.ShaderProperty(_PatternIntensity, "Pattern Intensity");

		//_PatternIntensityAdd
		materialEditor.ShaderProperty(_PatternIntensityAdd, "Pattern Intensity Add");

		//_PatternIntensitySpeed
		materialEditor.ShaderProperty(_PatternIntensitySpeed, "Pattern Intensity Speed");

		//_FresnelColor
		materialEditor.ShaderProperty(_FresnelColor, "Fresnel Color");

		//_FresnelScale
		materialEditor.ShaderProperty(_FresnelScale, "Fresnel Scale");

		//_FresnelScaleAdd
		materialEditor.ShaderProperty(_FresnelScaleAdd, "Fresnel Scale Add");

		//_FresnelSpeed
		materialEditor.ShaderProperty(_FresnelSpeed, "Fresnel Speed");

		//_Ambientscale
		materialEditor.ShaderProperty(_Ambientscale, "Ambient scale");
	}
	void OnDrawDissolve(MaterialEditor materialEditor, Material material)
	{
		//_DissolveOn
		materialEditor.ShaderProperty(_DissolveOn, "Use Dissolve");

		//_DissolveMap
		materialEditor.ShaderProperty(_DissolveMap, "Dissolve Map");

		//_DissolveAmount
		materialEditor.ShaderProperty(_DissolveAmount, "Ddissolve Amount");

		//_GlowColor
		materialEditor.ShaderProperty(_GlowColor, "Glow Color");

		//_GlowIntensity
		materialEditor.ShaderProperty(_GlowIntensity, "Glow Intensity");

		//_OuterEdgeColor
		materialEditor.ShaderProperty(_OuterEdgeColor, "Outer Edge Color");

		//_InnerEdgeColor
		materialEditor.ShaderProperty(_InnerEdgeColor, "Inner Edge Color");

		//_OuterEdgeThickness
		materialEditor.ShaderProperty(_OuterEdgeThickness, "Outer Edge Thickness");

		//_InnerEdgeThickness
		materialEditor.ShaderProperty(_InnerEdgeThickness, "Inner Edge Thickness");		
	}
	void OnDrawDetailInputs(MaterialEditor materialEditor, Material material)
	{
		//_EnableDetail
		materialEditor.ShaderProperty(_OnOffDetail, "Enable Detail");

		//_DetailMask
		materialEditor.ShaderProperty(_DetailMask, "Mask");

		//_DetailAlbedoMap
		materialEditor.ShaderProperty(_DetailAlbedoMap, "Base Map");

		//_DetailNormalMap
		materialEditor.ShaderProperty(_DetailNormalMap, "Normal Map");

		//_DetailAlbedoMapScaleOffset
		materialEditor.TextureScaleOffsetProperty(_DetailAlbedoMap);

		//_DetailNormalMapScale
		materialEditor.ShaderProperty(_DetailNormalMapScale, "Normal Scale");	
	}
	void OnDrawAdvanced(MaterialEditor materialEditor, Material material)
	{
		//renderQueue
		materialEditor.RenderQueueField();

		//_EnvironmentReflection
		materialEditor.ShaderProperty(_EnvironmentReflections, "EnvironmentReflection");
	}
}
