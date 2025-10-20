using System.Reflection;

namespace QuizGame;

    public abstract  class Question
    {

        private int _questionIndex;
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswer { get; set; }

    public abstract int Ask();
    public abstract bool CheckAnswer(int answer);

    }
