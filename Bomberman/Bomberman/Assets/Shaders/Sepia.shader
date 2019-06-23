Shader "Custom/Sepia"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SepiaOutput("SepiaOutput", Float) = 0
	}
	SubShader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _SepiaOutput; 
			
			fixed4 frag(v2f_img i) : SV_Target
			{
				fixed4 original = tex2D(_MainTex, i.uv); 
				
			half3x3 vals = half3x3
				(
					0.393, 0.349, 0.273,
					0.769, 0.686, 0.534,
					0.189, 0.168, 0.131

					); 
			half3 input = half3(original.rgb);

			half sepiaout = half(_SepiaOutput); 

			half3 intermed = (sepiaout * mul(input, vals)) +
				((1 - sepiaout) * input); 

			fixed4 output = half4(intermed, original.a); 

			return output; 
			}
			ENDCG
		}
	}
}
