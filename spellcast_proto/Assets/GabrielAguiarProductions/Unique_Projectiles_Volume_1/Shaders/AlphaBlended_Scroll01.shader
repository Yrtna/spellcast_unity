// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33725,y:32629,varname:node_4795,prsc:2|emission-1026-OUT,custl-2393-OUT,alpha-2252-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32608,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:10ff1f268ba06f7429f974521abe4b42,ntxv:0,isnm:False|UVIN-2151-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:33246,y:32705,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-914-OUT,D-9248-OUT,E-9633-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6235296,c3:0.1470588,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Time,id:9160,x:31342,y:33199,varname:node_9160,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4567,x:31144,y:33377,ptovrint:False,ptlb:Gradient U Speed,ptin:_GradientUSpeed,varname:_GradientUSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:4497,x:31144,y:33449,ptovrint:False,ptlb:Gradient V Speed,ptin:_GradientVSpeed,varname:_GradientVSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:8618,x:31342,y:33377,varname:node_8618,prsc:2|A-4567-OUT,B-4497-OUT;n:type:ShaderForge.SFN_Multiply,id:9458,x:31597,y:33281,varname:node_9458,prsc:2|A-9160-T,B-8618-OUT;n:type:ShaderForge.SFN_Tex2d,id:4069,x:32235,y:33219,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:_Gradient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6774-OUT;n:type:ShaderForge.SFN_Multiply,id:9633,x:32638,y:33219,varname:node_9633,prsc:2|A-6074-A,B-5108-OUT,C-4289-A,D-4957-OUT;n:type:ShaderForge.SFN_Slider,id:1571,x:31185,y:33036,ptovrint:False,ptlb:Noise Amount,ptin:_NoiseAmount,varname:_NoiseAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1,max:1;n:type:ShaderForge.SFN_Lerp,id:405,x:31596,y:32916,varname:node_405,prsc:2|A-3523-UVOUT,B-2788-R,T-1571-OUT;n:type:ShaderForge.SFN_TexCoord,id:3523,x:31330,y:32623,varname:node_3523,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:2788,x:31330,y:32824,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:_Distortion,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82f4b06147155c54da475b309b9e24fa,ntxv:0,isnm:False|UVIN-2765-OUT;n:type:ShaderForge.SFN_Add,id:6774,x:31949,y:33209,varname:node_6774,prsc:2|A-405-OUT,B-9458-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9664,x:31939,y:32621,ptovrint:False,ptlb:Distort Main Texture,ptin:_DistortMainTexture,varname:_DistortMainTexture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-3523-UVOUT,B-405-OUT;n:type:ShaderForge.SFN_Multiply,id:4009,x:30781,y:32820,varname:node_4009,prsc:2|A-7842-T,B-9706-OUT;n:type:ShaderForge.SFN_Append,id:9706,x:30570,y:32903,varname:node_9706,prsc:2|A-8025-OUT,B-7472-OUT;n:type:ShaderForge.SFN_Time,id:7842,x:30570,y:32722,varname:node_7842,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8025,x:30372,y:32903,ptovrint:False,ptlb:Distortion U Speed,ptin:_DistortionUSpeed,varname:_DistortionUSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:7472,x:30372,y:32975,ptovrint:False,ptlb:Distortion V Speed,ptin:_DistortionVSpeed,varname:_DistortionVSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Add,id:2765,x:30981,y:32819,varname:node_2765,prsc:2|A-3523-UVOUT,B-4009-OUT;n:type:ShaderForge.SFN_Multiply,id:5350,x:33246,y:32904,varname:node_5350,prsc:2|A-2053-A,B-797-A,C-6074-A,D-4289-A;n:type:ShaderForge.SFN_Tex2d,id:4289,x:32638,y:33453,ptovrint:False,ptlb:MainTexMask,ptin:_MainTexMask,varname:_MainTexMask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:22,x:32437,y:33470,varname:node_22,prsc:2|VAL-4069-RGB,EXP-4674-OUT;n:type:ShaderForge.SFN_Slider,id:4674,x:32043,y:33474,ptovrint:False,ptlb:Gradient Power,ptin:_GradientPower,varname:_GradientPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;n:type:ShaderForge.SFN_Multiply,id:5108,x:32437,y:33219,varname:node_5108,prsc:2|A-4069-RGB,B-22-OUT;n:type:ShaderForge.SFN_Multiply,id:914,x:32638,y:32976,varname:node_914,prsc:2|A-797-RGB,B-1441-OUT;n:type:ShaderForge.SFN_Slider,id:1441,x:32344,y:33081,ptovrint:False,ptlb:Color Multiplier,ptin:_ColorMultiplier,varname:_ColorMultiplier,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:2252,x:33514,y:33036,varname:node_2252,prsc:2|A-5350-OUT,B-3830-OUT;n:type:ShaderForge.SFN_DepthBlend,id:3830,x:33423,y:33365,varname:node_3830,prsc:2|DIST-6057-OUT;n:type:ShaderForge.SFN_Slider,id:6057,x:33096,y:33365,ptovrint:False,ptlb:EdgeSoftness,ptin:_EdgeSoftness,varname:_EdgeSoftness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1026,x:33492,y:32720,varname:node_1026,prsc:2|A-2393-OUT,B-3830-OUT;n:type:ShaderForge.SFN_Multiply,id:1528,x:31937,y:32270,varname:node_1528,prsc:2|A-1914-T,B-123-OUT;n:type:ShaderForge.SFN_Time,id:1914,x:31746,y:32176,varname:node_1914,prsc:2;n:type:ShaderForge.SFN_Append,id:123,x:31746,y:32354,varname:node_123,prsc:2|A-5744-OUT,B-2006-OUT;n:type:ShaderForge.SFN_Add,id:2151,x:32059,y:32431,varname:node_2151,prsc:2|A-1528-OUT,B-9664-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5744,x:31508,y:32327,ptovrint:False,ptlb:MainText U Speed,ptin:_MainTextUSpeed,varname:_MainTextUSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2006,x:31508,y:32398,ptovrint:False,ptlb:MainText V Speed,ptin:_MainTextVSpeed,varname:_MainTextVSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Clamp,id:4957,x:32643,y:33690,varname:node_4957,prsc:2|IN-1761-VFACE,MIN-5471-OUT,MAX-1388-OUT;n:type:ShaderForge.SFN_FaceSign,id:1761,x:32643,y:33844,varname:node_1761,prsc:2,fstp:0;n:type:ShaderForge.SFN_Vector1,id:1388,x:32467,y:33913,varname:node_1388,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:5471,x:32467,y:33857,ptovrint:False,ptlb:DoubleSided,ptin:_DoubleSided,varname:_DoubleSided,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:797-1441-5744-2006-6074-9664-4674-4567-4497-4069-1571-8025-7472-2788-4289-6057-5471;pass:END;sub:END;*/

Shader "GAP/AlphaBlendedDistortionScroll" {
    Properties {
        _TintColor ("Color", Color) = (1,0.6235296,0.1470588,1)
        _ColorMultiplier ("Color Multiplier", Range(0, 10)) = 1
        _MainTextUSpeed ("MainText U Speed", Float ) = 0
        _MainTextVSpeed ("MainText V Speed", Float ) = 0
        _MainTex ("MainTex", 2D) = "white" {}
        [MaterialToggle] _DistortMainTexture ("Distort Main Texture", Float ) = 0
        _GradientPower ("Gradient Power", Range(0, 50)) = 0
        _GradientUSpeed ("Gradient U Speed", Float ) = 0.1
        _GradientVSpeed ("Gradient V Speed", Float ) = 0.1
        _Gradient ("Gradient", 2D) = "white" {}
        _NoiseAmount ("Noise Amount", Range(-1, 1)) = 0.1
        _DistortionUSpeed ("Distortion U Speed", Float ) = 0.1
        _DistortionVSpeed ("Distortion V Speed", Float ) = 0.1
        _Distortion ("Distortion", 2D) = "white" {}
        _MainTexMask ("MainTexMask", 2D) = "white" {}
        _EdgeSoftness ("EdgeSoftness", Range(0, 1)) = 0
        _DoubleSided ("DoubleSided", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _GradientUSpeed;
            uniform float _GradientVSpeed;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform float _NoiseAmount;
            uniform sampler2D _Distortion; uniform float4 _Distortion_ST;
            uniform fixed _DistortMainTexture;
            uniform float _DistortionUSpeed;
            uniform float _DistortionVSpeed;
            uniform sampler2D _MainTexMask; uniform float4 _MainTexMask_ST;
            uniform float _GradientPower;
            uniform float _ColorMultiplier;
            uniform float _EdgeSoftness;
            uniform float _MainTextUSpeed;
            uniform float _MainTextVSpeed;
            uniform float _DoubleSided;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 node_1914 = _Time;
                float4 node_7842 = _Time;
                float2 node_2765 = (i.uv0+(node_7842.g*float2(_DistortionUSpeed,_DistortionVSpeed)));
                float4 _Distortion_var = tex2D(_Distortion,TRANSFORM_TEX(node_2765, _Distortion));
                float2 node_405 = lerp(i.uv0,float2(_Distortion_var.r,_Distortion_var.r),_NoiseAmount);
                float2 node_2151 = ((node_1914.g*float2(_MainTextUSpeed,_MainTextVSpeed))+lerp( i.uv0, node_405, _DistortMainTexture ));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2151, _MainTex));
                float4 node_9160 = _Time;
                float2 node_6774 = (node_405+(node_9160.g*float2(_GradientUSpeed,_GradientVSpeed)));
                float4 _Gradient_var = tex2D(_Gradient,TRANSFORM_TEX(node_6774, _Gradient));
                float4 _MainTexMask_var = tex2D(_MainTexMask,TRANSFORM_TEX(i.uv0, _MainTexMask));
                float3 node_2393 = (_MainTex_var.rgb*i.vertexColor.rgb*(_TintColor.rgb*_ColorMultiplier)*2.0*(_MainTex_var.a*(_Gradient_var.rgb*pow(_Gradient_var.rgb,_GradientPower))*_MainTexMask_var.a*clamp(isFrontFace,_DoubleSided,1.0)));
                float node_3830 = saturate((sceneZ-partZ)/_EdgeSoftness);
                float3 emissive = (node_2393*node_3830);
                float3 finalColor = emissive + node_2393;
                fixed4 finalRGBA = fixed4(finalColor,((i.vertexColor.a*_TintColor.a*_MainTex_var.a*_MainTexMask_var.a)*node_3830));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
