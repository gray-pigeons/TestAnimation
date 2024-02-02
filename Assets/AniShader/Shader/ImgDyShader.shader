Shader "Custom/ImgDyShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex("NoiseTex",2D) = "white"{}
        _NoiseScaleX("NoiseScaleX",Range(0,1))=0.1// 水平噪点放大系数
        _NoiseScaleY("NoiseScaleY",Range(0,1))=0.1//垂直放大系数
        _NoiseSpeedX("NoiseSpeedX",Range(0,10))=1 //水平扰动速度
        _NoiseSpeedY("NoiseSpeedY",Range(0,10))=1 //垂直扰动速度
        _NoiseBrightOffest("NoiseBrightOffest",Range(0,0.9))=0.25// 噪点图整体的数值偏移
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;//主顶点
                float2 uv : TEXCOORD0;//主uv
                float4 texcoord:TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float2 uv_Noise:TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            float _NoiseScaleX;
            float _NoiseScaleY;
            float _NoiseSpeedX;
            float _NoiseSpeedY;
            float _NoiseBrightOffest;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                _MainTex_ST.zw += _Time * float2(_NoiseSpeedX,_NoiseSpeedY);//控制扰动速度系数
                // 计算出经过缩放和偏移后的纹理坐标
                o.uv_Noise = TRANSFORM_TEX(v.texcoord,_NoiseTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float r = tex2D(_NoiseTex,i.uv_Noise).g;
                fixed2 offest = fixed2(r,r)*_Time;
                  // 修正，防止纹理边缘产生扭曲的效果
                offest -= _NoiseBrightOffest;
                offest *= fixed2(_NoiseScaleX,_NoiseScaleY);
                // sample the texture
                // 加上扰动UV后再采样主纹理
                fixed4 col = tex2D(_MainTex, i.uv + offest);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
