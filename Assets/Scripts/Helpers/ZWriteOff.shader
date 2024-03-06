Shader "Unlit/ZWriteOff"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite Off
        }
    }
}
