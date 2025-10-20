    namespace QuizGame;

    public  class Question
    {

        private int _questionIndex;
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswer { get; set; }
    
        public int Ask()
        {
            Console.WriteLine($"{Text} \n");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Options[i]} \n");
            }
            int userAnswer;
            while (true)
        {
            if (Type == "MultipleChoice")
            {
                Console.Write("Enter your choice number: \n");
                var input = Console.ReadLine();

                if (int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= Options.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.\n");

            } else if(Type == "TrueFalse")
            {
                Console.WriteLine("Enter 1 for True and 0 For False");
                var input = Console.ReadLine();
                if (int.TryParse(input, out userAnswer) && userAnswer > 0 && userAnswer < 1)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.\n");

            }
                
        }
        return userAnswer;
        }

        public  bool CheckAnswer(int answer)
        {
            return answer == CorrectAnswer;
            
        }    

    }
