    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "NewQuiz", menuName = "ScriptableObjects/Quiz", order = 1)]
    public class Quiz : ScriptableObject
    {
        public List<Question> questions = new List<Question>();
    }

    [System.Serializable]
    public class Question
    {
        public string questionText;
        public List<Response> responses = new List<Response>();
    }

    [System.Serializable]
    public class Response
    {
        public string responseText;
        public bool isCorrect;
    }
