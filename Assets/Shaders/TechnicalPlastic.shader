﻿Shader "Custom/TechnicalPlastic" {
	Properties {
		_Color ("Color", Color) = (0.434, 0.402, 0.348, 1)
		_TextureIntensity ("Texture Intensity", Range(0.1,2)) = 1
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.25
		_Metallic ("Metallic", Range(0,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		//LOD 200

		UsePass "DynamicAmbient/DYNAMICAMBIENT"
		Blend One One

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows noambient

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		half _TextureIntensity;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = (_TextureIntensity * tex2D(_MainTex, IN.uv_MainTex)) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Normal = UnpackNormal(tex2D(_MainTex, IN.uv_MainTex));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
