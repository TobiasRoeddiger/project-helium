// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "DynamicAmbient" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_MainTex ("Normal (Normal)", 2D) = "bump" {}
	}

	SubShader {
		Pass {
			Name "DynamicAmbient"
			Tags {"LightMode" = "Always"}

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest

				#include "UnityCG.cginc"

				struct v2f
				{
					float4	pos : SV_POSITION;
					float2	uv : TEXCOORD0;
					float3	normal : TEXCOORD2;
					float3	tangent : TEXCOORD3;
					float3	binormal : TEXCOORD4;
				}; 

				v2f vert (appdata_tan v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord.xy;
					o.normal = mul(unity_ObjectToWorld, float4(v.normal, 0)).xyz;
					o.tangent = v.tangent.xyz;
					o.binormal = cross(o.normal, o.tangent) * v.tangent.w;
					return o;
				}

				fixed4 _Color;
				sampler2D _MainTex;
				samplerCUBE _WorldCube;

				float4 frag(v2f i) : COLOR
				{
					float3 normal = UnpackNormal(tex2D(_MainTex, i.uv));

					float3 worldNormal = normalize((i.tangent * normal.x) + (i.binormal * normal.y) + (i.normal * normal.z));

					float3 nSquared = worldNormal * worldNormal;
					fixed3 linearColor;
					linearColor = nSquared.x * texCUBEbias(_WorldCube, float4(worldNormal.x, 0.00001, 0.00001, 999)).rgb; // For unknown reasons, giving an absolute vector ignores the mips....
					linearColor += nSquared.y * texCUBEbias(_WorldCube, float4(0.00001, worldNormal.y, 0.00001, 999)).rgb; // ...so unused components must have a tiny, non-zero value in.
					linearColor += nSquared.z * texCUBEbias(_WorldCube, float4(0.00001, 0.00001, worldNormal.z, 999)).rgb;

					float4 c;
					c.rgb = linearColor * _Color.rgb;
					c.a = _Color.a;
					return c;
				}
			ENDCG
		}
	}
	FallBack Off
}