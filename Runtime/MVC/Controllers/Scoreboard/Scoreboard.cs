using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class Scoreboard : MonoBehaviour
    {
        [System.Serializable]
        public class Model
        {
            public int Rank;
            public string FullName;
            public string Email;
            public int Score;
            public bool IsLocal;

            public Model(int rank, string fullName, string email, int score, bool isLocal = false)
            {
                Rank = rank;
                FullName = fullName;
                Email = email;
                Score = score;
                IsLocal = isLocal;
            }

            public Model(int rank, JObject jObject)
            {
                Rank = rank;
                FullName = jObject.GetValue("FullName").Value<string>();
                Email = jObject.GetValue("Email").Value<string>();
                Score = jObject.GetValue("Score").Value<int>();
                IsLocal = jObject.ContainsKey("IsLocal") ? jObject.GetValue("IsLocal").Value<bool>() : false;
            }

            public override int GetHashCode()
            {
                return Email.GetHashCode() + Score.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return obj is Model model && model.Score == Score && model.Email == Email;
            }
        }

        public Model localModel = new Model(7, "...", "...", 0, true);

        public Model[] models = {
            new Model(1, "...", "...", 0),
            new Model(2, "...", "...", 0),
            new Model(3, "...", "...", 0),
            new Model(4, "...", "...", 0),
            new Model(5, "...", "...", 0),
            new Model(6, "...", "...", 0),
            new Model(7, "...", "...", 0, true),
            new Model(8, "...", "...", 0),
            new Model(9, "...", "...", 0),
            new Model(10, "...", "...", 0)
        };

        public ScoreboardRow scoreboardLocalRow;
        public ScoreboardRow[] scoreboardRows;

        private void Start()
        {
            UpdateUI();
        }

        public void UpdateModels(JObject jObject)
        {
            models = new Model[]{
                new Model(1, "...", "...", 0),
                new Model(2, "...", "...", 0),
                new Model(3, "...", "...", 0),
                new Model(4, "...", "...", 0),
                new Model(5, "...", "...", 0),
                new Model(6, "...", "...", 0),
                new Model(7, "...", "...", 0, true),
                new Model(8, "...", "...", 0),
                new Model(9, "...", "...", 0),
                new Model(10, "...", "...", 0)
            };
            bool update = false;
            JArray jArray = jObject.GetValue("models").Value<JArray>();
            for (int i = 0; i < models.Length; i++)
            {
                if (i < jArray.Count)
                {
                    Model model = new Model(i + 1, jArray[i].Value<JObject>());
                    if (!models[i].Equals(model))
                    {
                        models[i] = model;
                        update = true;
                    }
                    if (model.IsLocal && !localModel.Equals(model)) localModel = models[i];
                }
                else
                {
                    break;
                }
            }
            if (update) UpdateUI();
        }

        void UpdateUI ()
        {
            scoreboardLocalRow.SetModel(localModel);
            for (int i = 0; i < scoreboardRows.Length; i++)
            {
                scoreboardRows[i].SetModel(models[i]);
            }
        }
    }
}