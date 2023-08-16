using System.Windows;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using TinderSuitev3.Helpers;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await Tinder.Instances.First().UpdateBio(BioText.Text);

            new DarkMessageBox("Your bio has been updated!").ShowDialog();
            this.Close();
        }

        private async void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            var p = await Tinder.Instances.First().GetUser();
            BioText.Text = p.Bio;
        }
    }
}
