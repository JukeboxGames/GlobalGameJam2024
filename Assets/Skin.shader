Shader "Custom/Skin"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    
    SubShader
    {
        Tags {"Queue"="Overlay" }
        LOD 100
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            // Sample the main texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            
            // Use the alpha value of the main texture as the mask
            c.rgb *= c.a;
            
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    
    FallBack "Diffuse"
}
