Shader "Custom/lanboteShader"
{
    Properties
    {
        //消融度
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex("NoiseTex",2D)="white"{}
        _BurnAmount("BurnAmount",Range(0.0,1.0))=0.0
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
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uvMainTex : TEXCOORD0;
                float2 uvNoiseTex :TEXCOLORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            float _BurnAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                //计算纹理坐标
                o.uvMainTex = TRANSFORM_TEX(v.uv, _MainTex);
                o.uvNoiseTex = TRANSFORM_TEX(v.uv,_NoiseTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //对噪声纹理进行采样
                fixed3 noiseCol = tex2D(_NoiseTex,i.uvNoiseTex).rgb;
                 // 剔除小于消融度的像素
                clip(noiseCol.r - _BurnAmount);

                //计算环境光照 = 环境光+反射率
                //反射率
                fixed3 albedo = tex2D(_MainTex, i.uvMainTex).rgb;
                //环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                //漫反射 = 入射光颜色 * 材质颜色 * Max(0,入射光方向*当前点的法线方向)
                //入射光方向
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //法线方向
                fixed3 normalDir = UnpackNormal(tex2D(_MainTex,i.uvMainTex));
                fixed3 diffuse = _LightColor0.rgb * max(0,dot(normalDir,lightDir));

                fixed3 mainCol = diffuse+ambient;
                // 使用smoothstep计算混合系数t
                fixed t = 1 - smoothstep(0.0, clamp(tan(_Time.y),0.0,0.2), noiseCol.r - _BurnAmount);
                   // 使用混合系数，插值当前的两种颜色
                fixed3 finalCol = lerp(noiseCol,mainCol,cos(_Time.w));
                 // 对结果进行5次方处理，使结果更接近烧焦效果
                finalCol = pow(finalCol, 3);
                return fixed4(finalCol,1);
            }
            ENDCG
        }
    }
}
