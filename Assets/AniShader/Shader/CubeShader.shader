// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/CubeShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Alpha("Alpha",Range(0,1))=1
        _Color("Color",Color)=(1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass{
            CGPROGRAM
       
            #pragma  vertext vert
            #pragma fragment frag 
            
            #include "UnityCG.cginc"

        struct appdata
        {
                        //模型顶点坐标
            float4 vertext : POSITION;
                        //uv 贴图数据
            float2 uv : TEXCOLOR0;
            float3 normal : NORMAL;
        };

        struct v2f
        {
            float2 uv : TEXCOLOR0;
            float4 pos : SV_POSITION;
              float2 pos_uv : TEXCOLOR1;
        };

            //2D 贴图
            sampler2D _MainTex;
            //颜色
            fixed4 _Color;
            float _Alpha;
            float4 _MainTex_ST;

            //顶点着色
            v2f vert(appdata v){
                v2f o;
                //从模型空间转换到裁剪空间
                o.pos = UnityObjectToClipPos(v.vertext);
                o.uv = v.uv * _MainTex_ST.xy * _MainTex_ST.zw * _Time.y;
                o.pos_uv = v.vertext.xz * _MainTex_ST.xy * _MainTex_ST.zw ;
                return o;
            }

            half4 frag(v2f i):SV_Target
            {
                fixed4 col = tex2D(_MainTex,i.pos_uv);
                return col;
            }



            ENDCG
        }
       
    }
    FallBack "Diffuse"
}
