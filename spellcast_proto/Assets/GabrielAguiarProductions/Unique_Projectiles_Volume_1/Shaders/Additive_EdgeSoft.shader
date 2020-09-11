// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:1,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33535,y:32620,varname:node_4795,prsc:2|emission-1209-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32574,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ee563c601ce871f42ad3f66c8ae56b8e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32670,y:32776,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-567-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33121,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_DepthBlend,id:4085,x:32655,y:33056,varname:node_4085,prsc:2|DIST-7893-OUT;n:type:ShaderForge.SFN_Slider,id:7893,x:32382,y:33138,ptovrint:False,ptlb:EdgeSoftness,ptin:_EdgeSoftness,varname:_EdgeSoftness,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:567,x:32519,y:32544,varname:node_567,prsc:2|A-6074-A,B-2053-A,C-797-A;n:type:ShaderForge.SFN_Multiply,id:1209,x:33125,y:32651,varname:node_1209,prsc:2|A-2393-OUT,B-4085-OUT,C-5816-OUT;n:type:ShaderForge.SFN_Clamp,id:5816,x:33092,y:33026,varname:node_5816,prsc:2|IN-8001-VFACE,MIN-2399-OUT,MAX-9360-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2399,x:32916,y:33153,ptovrint:False,ptlb:DoubleSided,ptin:_DoubleSided,varname:_DoubleSided,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:9360,x:32916,y:33249,varname:node_9360,prsc:2,v1:1;n:type:ShaderForge.SFN_FaceSign,id:8001,x:33092,y:33180,varname:node_8001,prsc:2,fstp:0;proporder:797-6074-7893-2399;pass:END;sub:END;*/

Shader "GAP/Additive_EdgeSoft" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _EdgeSoftness ("EdgeSoftness", Range(0, 1)) = 0
        _DoubleSided ("DoubleSided", Float ) = 1
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
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 2.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed4 _TintColor;
            uniform fixed _EdgeSoftness;
            uniform fixed _DoubleSided;
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
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = ((_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0*(_MainTex_var.a*i.vertexColor.a*_TintColor.a))*saturate((sceneZ-partZ)/_EdgeSoftness)*clamp(isFrontFace,_DoubleSided,1.0));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Mobile/Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
