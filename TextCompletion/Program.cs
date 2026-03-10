using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;

//get credentials from user secrets
IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var credentials = new ApiKeyCredential(config["GitHubModels:Token"] ?? throw new InvalidOperationException()) ;

var options = new OpenAIClientOptions
{
    Endpoint = new Uri("https://models.github.ai/inference"),
};

//create chat client

IChatClient client = new OpenAIClient(credentials, options).GetChatClient("gpt-4o-mini").AsIChatClient();

//send a message to the model and get a response
ChatResponse response = await client.GetResponseAsync("What is Ai ? explain max 20 words");

Console.WriteLine(response);