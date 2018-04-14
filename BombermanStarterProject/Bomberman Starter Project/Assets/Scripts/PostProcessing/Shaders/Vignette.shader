Shader "Custom/Vignette"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_vRadius("Vignette Radius", Range(0.0, 1.0)) = 1.0
		_vSoft("Vignette Softness", Range(0.0, 1.0)) = 0.5

	}
		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float _vRadius; 
			float _vSoft; 

	float4 frag(v2f_img input) : COLOR{

		float4 base = tex2D(_MainTex, input.uv);

		float distFromCenter = distance(input.uv.xy,
		float2(0.5,0.5)); 
			
		float vignette = smoothstep(_vRadius, _vRadius - _vSoft
			, distFromCenter); 

		base = saturate(base * vignette); 
		return base; 
			}
			ENDCG
		}
	}
}
