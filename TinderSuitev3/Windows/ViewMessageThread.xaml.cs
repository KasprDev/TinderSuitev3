using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using OpenAI.ObjectModels.RequestModels;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    public partial class ViewMessageThread : Window, INotifyPropertyChanged
    {
        public static string? UserId { get; set; }
        public static Match? Match { get; set; }
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

        public async Task<string?> GenerateAiReply(Message[] messages)
        {
            //The information to send to the AI to process a reply.
            var aiContextMessages = new List<ChatMessage>();

            // No messages have been exchanged yet, come up with a pickup line instead.
            if (messages.Length == 0)
            {
                aiContextMessages.Add(ChatMessage.FromUser(AIAssistant.PickupLineContext));
            }
            else
            {
                // Feed the AI a list of received messages for context.
                var m = messages.Where(x => x.From != UserId).ToList();
                var msg = m.Aggregate("", (current, message) => current + $"{(message.From == UserId ? "I said" : "They said")} \"{message.Text}\". Then, ");

                // Remove the trailing "Then,"
                msg = msg.Substring(0, msg.Length - 5);

                aiContextMessages.Add(ChatMessage.FromUser(AIAssistant.MessageContext));
                aiContextMessages.Add(ChatMessage.FromUser(msg));
            }

            return await new AIAssistant().GetResponse(aiContextMessages);
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(NewMessage.Text))
                return;

            var messages = Messages?.ToList();

            messages?.Add(new Message()
            {
                Text = NewMessage.Text,
                From = UserId!
            });

            await Tinder.Instances.First().SendMessage(Match.MatchId, NewMessage.Text);

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
            NewMessage.Text = await GenerateAiReply(Messages);
        }

        private void ViewProfile_OnClick(object sender, RoutedEventArgs e)
        {
            new ViewProfile(Match?.Person.Id).Show();
        }
    }
}
