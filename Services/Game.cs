
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace QuizGame;

public class Game
{

    public List<Question> _questions = new List<Question>();
    public Player player;
    private string _dataDirectory;
    private string getAssemblyDirectory()
    {
        string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        // Go up 3 levels: bin → Debug → netX.X ->
        var solutionRoot = Directory.GetParent(assemblyDir)!.Parent!.Parent!.FullName;

        return solutionRoot;
    }
    public Game(string directoryPath)
    {
        var dataDirectory = Path.Combine(getAssemblyDirectory(), directoryPath);
        if (!Directory.Exists(dataDirectory))
        {
            throw new Exception($"Could not find '{dataDirectory}'");
        }

        _dataDirectory = dataDirectory;
        
         player = new Player();
    }
    
    
    public void Start(string name)
    {
        player.Name = name;
        // load all questions
        LoadQuestions();
        //run quiz loop
        foreach (var question in _questions)
        {
            var userAnswer = question.Ask();
            if (question.CheckAnswer(userAnswer))
            {
                player.AddScore();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Good Job {player.Name}. You are so smart!!!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Wrong! Correct answer: {question.Options[question.CorrectAnswer]}\n");
                Console.ResetColor();

            }
        }
        // Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"your score is {player.Score} out of {_questions.Count} \n");
        // Console.ResetColor();
        //show score.x
    }

        private void LoadQuestions()
        {
            var questionFile = Directory.GetFiles(_dataDirectory, "*.json");
            var fileContent = File.ReadAllText(questionFile[0]);
            var questionsArray = JsonNode.Parse(fileContent)!.AsArray();
            foreach (var node in questionsArray)
            {
                Question question;
                QuestionType type = Enum.Parse<QuestionType>(node["Type"]!.ToString());
                question = type switch
                {
                    QuestionType.MultipleChoice => new MultipleChoice(),
                    QuestionType.TrueFalse => new TrueFalse(),
                    _ => throw new Exception($"Unknow type {type}")
                };
                question.Type = type;
                question.Id = int.Parse(node["Id"]!.ToString());
                question.Text = node["Text"]!.ToString();   
                question.Options = node["Options"]!.AsArray().Select(x => x.ToString()).ToList();
                question.CorrectAnswer = int.Parse(node["CorrectAnswer"]!.ToString()!);
                _questions.Add(question);
                
            }

        }
    }
