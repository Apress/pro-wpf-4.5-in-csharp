sampler2D  ImageSampler : register(S0);  //take ImageSampler from S0 register. 

// 'uv' vector from TEXCOORD0 semantics is our texture coordinate, two floating point numbers in the range 0-1.
float4 PS( float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D( ImageSampler, uv); // get the color of texture at the current point
    color.rgb = dot(color.rgb, float3(0.3, 0.59, 0.11)); //compose correct luminance value
    return color;
}
