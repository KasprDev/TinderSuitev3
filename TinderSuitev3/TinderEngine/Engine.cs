using HtmlAgilityPack;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;

namespace TinderSuitev3.TinderEngine
{
    public static class Engine
    {
        public static string ProcessEthnicity(byte[] imageBytes)
        {
            return EthnicityModel.Predict(new EthnicityModel.ModelInput()
            {
                ImageSource = imageBytes
            }).PredictedLabel;
        }

        public static async Task<string?> GetIncome(TinderUser user)
        {
            try
            {
                var job = user.Jobs?.FirstOrDefault();

                if (job == null)
                    return "N/A";

                var web = new HtmlWeb();
                var doc = await web.LoadFromWebAsync($"https://www.payscale.com/research/US/Job={job.Title?.Name.Replace(" ", "_")}/Salary");

                string xpath = "//span[contains(@class, 'paycharts__value')]";

                var salaryNode = doc.DocumentNode.SelectSingleNode(xpath);
                string salary = salaryNode?.InnerText.Trim();

                return salary;
            }
            catch
            {
                return "N/A";
            }
        }

        public static int ScoreUser(TinderUser user)
        {
            user.Bio = user.Bio.ToLower();

            var score = 100;

            // Dock points for having no bio.
            if (string.IsNullOrWhiteSpace(user.Bio))
                score -= 16;
            else if (user.Bio.Length < 20)
                score -= 22;
            else if (user.Bio.Length > 90)
                score += 8;

            if (user.RelationshipIntent?.BodyText == "Short-term fun")
                score -= 25;

            if (user.Photos.Count == 1)
                score -= 15;

            // Go through each weighted word.
            foreach (var item in Lists.WeightedWords)
            {
                if (user.Bio.Contains(item.Key))
                    score -= item.Value;
            }

            // The bio is a short social-media pitch.
            if (user.Bio.StartsWith("insta") || user.Bio.StartsWith("snap"))
                score -= 20;

            // If the name isn't capitalized, dock a few points off for that.
            if (!char.IsUpper(user.Name.First()))
                score -= 33;

            if (user.Jobs != null)
            {
                if (user.Jobs.Where(x => x.Title != null).Any(x => x.Title!.Name.Contains("OF")) ||
                    user.Jobs.Where(x => x.Title != null).Any(x => x.Title!.Name.Contains("model")))
                {
                    score -= 30;
                }
                else
                {
                    score += 5;
                }
            }
            else
            {
                score -= 5;
            }

            if (user.Bio.Contains("no hookups"))
                score += 20;

            if (score < 0)
                score = 0;

            if (score > 100)
                score = 100;

            return score;
        }
    }
}
