namespace OpenSurvey.Core.Model
{
    using System;

    public class Question
    {
        public virtual int Id { get; set; }
        public virtual string QuestionText { get; set; }
        public virtual string QuestionType { get; set; }
    }
}
