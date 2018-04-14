Shader "Custom/Grayscale"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_bwBlend {"Black & white blend", Range(0,1)) = 0}
	}
		SubShader
		{
			Pass
			{
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag

				#include "UnityCG.cginc"
				uniform sampler2D _MainTex; 
				uniform float _bwBlend; 
				
				float

			ENDCG
		}
	}
}
