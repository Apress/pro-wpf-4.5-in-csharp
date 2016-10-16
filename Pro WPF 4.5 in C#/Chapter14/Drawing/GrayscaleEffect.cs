using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;

namespace Drawing
{
    public class GrayscaleEffect : ShaderEffect
    {

        public GrayscaleEffect()
        {
            Uri pixelShaderUri = new Uri("Grayscale_Compiled.ps",
              UriKind.Relative);

            // Load the information from the .ps file.
            PixelShader = new PixelShader();
            PixelShader.UriSource = pixelShaderUri;

            UpdateShaderValue(InputProperty);
        }

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0 /* assigned to sampler register S0 */);

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
    }
}
