using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    /// <summary>
    /// Interaction logic for ViewMessageThread.xaml
    /// </summary>
    public partial class ViewMessageThread : Window, INotifyPropertyChanged
    {
        public static string? UserId { get; set; }
        public static Match Match { get; set; }
        private string MatchId { get; set; }
        public Message[]? Messages { get; set; }
        public ViewMessageThread(Match match)
        {
            Match = match;
            MatchId = Match.Id;
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var u = await Tinder.Instances.First().GetUser();
            UserId = u.Id;

            var messages = await Tinder.Instances.First().GetChatThread(MatchId);
            Messages = messages?.Data.Messages.Reverse().ToArray();
            OnPropertyChanged("Messages");

            Title = $"Chat with {Match.Person.Name}";
        }

        public async Task<string?> GenerateAIReply(Message[] messages)
        {
            var settings = await Settings.GetSettings();

            if (string.IsNullOrWhiteSpace(settings?.OpenAiKey))
            {
                new DarkMessageBox("You need to configure your OpenAI API Key in the Settings to use this feature.").ShowDialog();
                return null;
            }

            if (messages.Length == 0)
                return null;

            var m = messages.ToList();
            m = m.Where(x => x.From != UserId).ToList();
            Messages = m.ToArray();

            var ai = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = settings!.OpenAiKey!
            });

            var aiMessages = new List<ChatMessage>() 
                { ChatMessage.FromUser($"I'm going to give you the transcript of a few messages from a dating app between me and another user. Reply to me as if you are replying directly to them. " +
                                       $"Don't pay attention to anything that I said in the below chat logs, just pay attention to their last response; using the rest of the messages as context. Try to make 2 sentences or less. If you're asked a question, " +
                                       $"make something up that's believable and generic. Also, 50% of the time, can you throw in a question to ask them? Ask something casual and don't be super formal with your message.") };

            var msg = "";

            foreach (var message in messages)
            {
                msg += $"{(message.From == UserId ? "I said" : "They said")} \"{message.Text}\". Then, ";
            }

            msg = msg.Substring(0, msg.Length - 5);
            aiMessages.Add(ChatMessage.FromUser(msg));

            var res = await ai.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = aiMessages,
                Model = Models.Gpt_3_5_Turbo,
                MaxTokens = 50
            });

            if (res.Successful)
            {
                return res.Choices.First().Message.Content;
            }

            return null;
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(NewMessage.Text))
                return;

            var messages = Messages?.ToList();

            messages.Add(new Message()
            {
                Text = NewMessage.Text,
                From = UserId!
            });

            // await Tinder.Instances.First().SendMessage(Match.MatchId, NewMessage.Text);

            NewMessage.Text = "";
            Messages = messages.ToArray();
            OnPropertyChanged("Messages");
        }

        private async void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async void NewMessage_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                await SendMessage();
        }

        private async void AIGenButton_OnClick(object sender, RoutedEventArgs e)
        {
            var lastMessage = Messages?.LastOrDefault(x => x.From != UserId);
            var s = await GenerateAIReply(Messages);
            NewMessage.Text = s;
        }

        private void ViewProfile_OnClick(object sender, RoutedEventArgs e)
        {
            new ViewProfile(Match.Person.Id).Show();
        }
    }
}
