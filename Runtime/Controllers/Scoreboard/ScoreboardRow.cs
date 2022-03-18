using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreboardRow : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI Rank, FullName, Email, Score;

        public void SetModel(Scoreboard.Model model)
        {
            SetRank(model.Rank);
            SetFullName(model.FullName);
            SetEmail(model.Email);
            SetScore(model.Score);
        }

        public void SetRank(int val)
        {
            Rank.text = $"#{val}";
        }

        public void SetFullName(string val)
        {
            FullName.text = $"{val}";
        }

        public void SetEmail(string val)
        {
            Email.text = $"{val}";
        }

        public void SetScore(int val)
        {
            Score.text = $"{val}";
        }
    }
}