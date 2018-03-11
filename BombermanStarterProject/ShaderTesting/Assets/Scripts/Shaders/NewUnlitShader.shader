// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/NewUnlitShader"
{

	Properties
	{
		_MainTex("Texture",2D) = "white" {}
		_SecondTex(" Second Texture",2D) = "white" {}
		_Tween("Transition float", Range(0,1)) = 0.5
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
		}
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION; 
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION; 
				float2 uv : TEXCOORD0;
			}; 

			v2f vert(appdata v)
			{
				v2f o; 
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv; 
				return o; 
			}
			float4 _Color; 
			sampler2D _MainTex;
			sampler2D _SecondTex;
			float _Tween; 

			float4 frag(v2f i) : SV_Target
			{
				float4 color = lerp(tex2D(_MainTex, i.uv), tex2D(_SecondTex,i.uv), _Tween) *_Color;
				/*float4 color2 = tex2D(_SecondTex, i.uv) * _Color; 
				float4 output = lerp(_MainTex, _SecondTex, _Tween);*/

				return color; 
			}
			ENDCG
		}
	}

	}