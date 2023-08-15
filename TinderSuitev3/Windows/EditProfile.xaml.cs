using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using TinderSuitev3.Helpers;

namespace TinderSuitev3.TinderEngine
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private async void GenerateBio_OnClick(object sender, RoutedEventArgs e)
        {
            var settings = await Settings.GetSettings();

            if (string.IsNullOrWhiteSpace(settings?.OpenAiKey))
            {
                new DarkMessageBox("You need to configure your OpenAI API Key in the Settings to use this feature.").ShowDialog();
                return;
            }

            var ai = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = settings!.OpenAiKey!
            });
            
            
            var res = await ai.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>()
                    { ChatMessage.FromUser("Give me a good bio to use for a dating app (Tinder). Don't be too formal and come off as a relaxed, but fun and sexy person.") },
                Model = Models.Gpt_3_5_Turbo,
                MaxTokens = 50
            });

            if (res.Successful)
            {
                BioText.Text = res.Choices.First().Message.Content;
            }
        }
    }
}
