namespace QuizGame;

public class TrueFalse : Question
{
    public override int Ask()
        {
            Console.WriteLine($"{Text} \n");
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i}: {Options[i]} \n");
            }
            int userAnswer;
            while (true)
            {
                
                    Console.WriteLine("Enter 1 for True and 0 For False");
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out userAnswer) && (userAnswer == 0  || userAnswer == 1))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number.\n");
                                 
        }
        return userAnswer;
        }

   

    public override bool CheckAnswer(int answer)
        {
            return answer == CorrectAnswer;
            
        }
}
