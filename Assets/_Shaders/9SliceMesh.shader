Shader "Custom/9 Slice Mesh" 
{
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Color("Color",Color) = (1,1,1,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Slice ("Slice Boader", Vector) = (0.33333,0.66666,0.33333,0.66666)
		_TileScale("Tile Scale",Range(0,10)) = 1.0
	}
	SubShader 
	{
		Pass
		{
			ZWrite Off
			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
			LOD 200
			Blend SrcAlpha OneMinusSrcAlpha 
			Cull Back

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityCG.cginc"
			sampler2D _MainTex;

			struct appdata
			{
				float4 vertex : POSITION;
				float4 normal: NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : TEXCOORD0;
				float3 localPos : TEXCOORD1;
			};
			
			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			fixed4 _Slice;
			fixed _TileScale;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.localPos = mul(unity_ObjectToWorld, v.vertex)-unity_ObjectToWorld._m03_m13_m23;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float scaleX = length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x));
				float scaleY = length(float3(unity_ObjectToWorld[0].y, unity_ObjectToWorld[1].y, unity_ObjectToWorld[2].y));
				// float scaleZ = length(float3(unity_ObjectToWorld[0].z, unity_ObjectToWorld[1].z, unity_ObjectToWorld[2].z));
				fixed2 halfScale = fixed2(scaleX/2,scaleY/2);
				float3 l = i.localPos;
				fixed2 uv = fixed2(0,0);

				fixed xStep = step(l.x,halfScale.x-_Slice.x*_TileScale);
				fixed yStep = step(l.y,halfScale.y-_Slice.z*_TileScale);
				
				if(halfScale.x-_Slice.x*_TileScale<l.x)
				{
					fixed t = halfScale.x-_Slice.x*_TileScale;
					uv.x = (_Slice.x-(l.x-t)/_TileScale);
				}
				else if(l.x < -halfScale.x+(1-_Slice.y)*_TileScale)
				{
					fixed t = -halfScale.x+(1-_Slice.y)*_TileScale;
					uv.x = _Slice.y + (-l.x+t)/_TileScale;
				}
				else
				{
					fixed t = (_Slice.y-_Slice.x)*_TileScale;
					uv.x = _Slice.y-fmod(l.x+halfScale.x,t)/_TileScale;
				}

				if(halfScale.y-_Slice.z*_TileScale < l.y)
				{
					fixed t = halfScale.y-_Slice.z*_TileScale;
					uv.y = (_Slice.z-(l.y-t)/_TileScale);
				}
				else if(-halfScale.y+(1-_Slice.w)*_TileScale > l.y)
				{
					fixed t = -halfScale.y+(1-_Slice.w)*_TileScale;
					uv.y = _Slice.w + (-l.y+t)/_TileScale;
				}
				else
				{
					fixed t = (_Slice.w-_Slice.z)*_TileScale;
					uv.y = _Slice.w-fmod(l.y+halfScale.y,t)/_TileScale;
				}
				
				fixed4 c =fixed4(0,0,0,0);
				if(i.normal.x == 0 && i.normal.y == 0)
				{
					c = tex2D(_MainTex,uv)*_Color;
				}
				return c;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
//KEEL_210 @jdatmtjp