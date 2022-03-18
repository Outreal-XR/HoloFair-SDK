
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreboardTest : Scoreboard
    {
        [System.Serializable]
        public class ModelTest
        {
            public string FullName;
            public string Email;
            public int[] Scores;
            public int currentIndex;
            public bool IsLocal;

            public JObject ToJObject()
            {
                return new JObject()
                {
                    { "FullName", FullName },
                    { "Email", Email },
                    { "Score", GetScore()},
                    { "IsLocal", IsLocal }
                };
            }

            public int GetScore()
            {
                return Scores[Mathf.Clamp(currentIndex, 0, Scores.Length - 1)];
            }
        }

        public ModelTest[] sourceTestModels;
        public ModelTest[] processedtestModels;
        public float timeBeforeNextUpdate;

        private void Start()
        {
            for (int i = 0; i < sourceTestModels.Length; i++)
            {
                if(!sourceTestModels[i].IsLocal)
                    sourceTestModels[i] = new ModelTest
                    {
                        FullName = "User " + i,
                        Email = "Email " + i,
                        Scores = new int[] {
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256),
                            Random.Range(-256, 256)
                        },
                        currentIndex = Random.Range(-7, 0),
                    };
            }
        }

        private void Update()
        {
            if(timeBeforeNextUpdate > 0)
            {
                timeBeforeNextUpdate -= UnityEngine.Time.deltaTime;
                if (timeBeforeNextUpdate <= 0) IncrementScores();
            }
        }

        public void IncrementScores()
        {
            processedtestModels = sourceTestModels.Where(x => x.currentIndex >= 0 && x.GetScore() > 0).OrderBy(x => x.GetScore()).Take(10).ToArray();
            for (int i = 0; i < sourceTestModels.Length; i++)
                sourceTestModels[i].currentIndex++;
            JValue jValue = new JValue(true);
            JArray models = new JArray();
            foreach (var model in processedtestModels)
                models.Add(model.ToJObject());
            UpdateModels(new JObject() {
                new JProperty ( "models", models)
            });
        }
    }
}