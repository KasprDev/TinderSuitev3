using OpenAI.Managers;
using OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.ObjectModels.RequestModels;
using Google.Protobuf;
using OpenAI.ObjectModels;

namespace TinderSuitev3.Helpers
{
    public class AIAssistant
    {
        public static string MessageContext { get; set; } = $"I'm going to give you the transcript of some messages between me and another user on the dating app Tinder. Reply to me as if you are replying directly to them, while being as casual as possible. " +
                                                            $"Try to make 2 sentences or less. If you're asked a question, make something up that's believable and generic. 50% of the time, throw in a question to ask them.";
        public static string PickupLineContext { get; set; } = "";


        public AIAssistant()
        {
            
        }

        public async Task<string?> GetResponse(List<ChatMessage> messages)
        {
            var settings = Settings.GetSettings().GetAwaiter().GetResult();
            var ai = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = settings!.OpenAiKey!
            });

            var res = await ai.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = messages,
                Model = Models.Gpt_3_5_Turbo,
                MaxTokens = 50
            });

            return res.Successful ? res.Choices.First().Message.Content : null;
        }
    }
}
