using System.Collections.Generic;
using JetBrains.Annotations;

namespace Data
{
    [System.Serializable]
    public class ServerResponse<T>
    {
        public List<T> data { get; set; }
        public object meta { get; set; }
    }
    
    [System.Serializable]
    public class BaseEntity
    {
        public int id { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
    
    [System.Serializable]
    public class QuestionEntity: BaseEntity
    {
        public string question { get; set; }
        public string historical_reference { get; set; }
        public AnswerEntity right_answer { get; set; }
        [CanBeNull] public LevelEntity[] levels { get; set; }
        [CanBeNull] public TagEntity[] tags { get; set; }
        [CanBeNull] public AnswerEntity[] answers { get; set; }
    }

    [System.Serializable]
    public class AnswerEntity: BaseEntity
    {
        public string text { get; set; }
        [CanBeNull] public QuestionEntity[] questions { get; set; }
        [CanBeNull] public TagEntity[] tags { get; set; }
    }

    [System.Serializable]
    public class TagEntity : BaseEntity
    {
        public string value { get; set; }
        [CanBeNull] public QuestionEntity[] questions { get; set; }
        [CanBeNull] public AnswerEntity[] answer { get; set; }
        [CanBeNull] public LevelEntity[] levels { get; set; }
    }

    [System.Serializable]
    public class LevelEntity : BaseEntity
    {
        [CanBeNull] public QuestionEntity[] questions { get; set; }
        [CanBeNull] public TagEntity[] tags { get; set; }
    }
}