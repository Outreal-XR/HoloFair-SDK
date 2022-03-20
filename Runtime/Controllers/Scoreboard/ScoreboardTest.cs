
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreboardTest : Scoreboard
    {

        [Serializable]
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

            internal int CompareTo(ModelTest i1)
            {
                return GetScore().CompareTo(i1.GetScore());
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
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256),
                            UnityEngine.Random.Range(-256, 256)
                        },
                        currentIndex = UnityEngine.Random.Range(-7, 0),
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
            var filteredModels = sourceTestModels.Where(x => x.currentIndex >= 0 && x.GetScore() > 0);
            Comparison<ModelTest> comparison = new Comparison<ModelTest>((i1, i2) => i2.CompareTo(i1));
            Array.Sort<ModelTest>(filteredModels.ToArray(), comparison);
            for (int i = 0; i < sourceTestModels.Length; i++)
                sourceTestModels[i].currentIndex++;
            processedtestModels = filteredModels.Take(10).ToArray();
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