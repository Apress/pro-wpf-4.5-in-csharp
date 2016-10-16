using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Speech.Synthesis;

namespace SoundAndVideo
{
    /// <summary>
    /// Interaction logic for SpeechSynthesis.xaml
    /// </summary>

    public partial class SpeechSynthesis : System.Windows.Window
    {

        public SpeechSynthesis()
        {
            InitializeComponent();
        }

        private void cmdSpeak_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Speak(txtWords.Text);
        }

        private void cmdPromptTest_Click(object sender, RoutedEventArgs e)
        {
            PromptBuilder prompt = new PromptBuilder();
            
            prompt.AppendText("How are you");            
            prompt.AppendBreak(TimeSpan.FromSeconds(2));
            prompt.AppendText("How ", PromptEmphasis.Reduced);
            PromptStyle style = new PromptStyle();
            style.Rate = PromptRate.ExtraSlow;
            style.Emphasis = PromptEmphasis.Strong;
            prompt.StartStyle(style);
            prompt.AppendText("are ");
            prompt.EndStyle();            
            prompt.AppendText("you?");          
            
            
            
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Speak(prompt);
            
        }
    }
}