using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;
using System.Numerics.Tensors;

// get credentials from user secrets
IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var credential = new ApiKeyCredential(config["GitHubModels:Token"] ?? throw new InvalidOperationException("Missing configuration: GitHubModels:Token."));
var options = new OpenAIClientOptions()
{
    Endpoint = new Uri("https://models.github.ai/inference")
};

// create a chat client
IChatClient client =
    new OpenAIClient(credential, options).GetChatClient("gpt-4o-mini").AsIChatClient();

// Create an embedding generator (text-embedding-3-small is an example)
IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator =
    new OpenAIClient(credential, options).GetEmbeddingClient("openai/text-embedding-3-small").AsIEmbeddingGenerator();

//// 1: Generate a single embedding
//var embedding = await embeddingGenerator.GenerateVectorAsync("Hello, world!");
//Console.WriteLine($"Embedding dimensions: {embedding.Span.Length}");
//foreach (var value in embedding.Span)
//{
//    Console.Write("{0:0.00}, ", value);
//}

// Compare multiple embeddings using Cosine Similarity
var fishVector = await embeddingGenerator.GenerateVectorAsync("fish");
var dogVector = await embeddingGenerator.GenerateVectorAsync("dog");
var SharkVector = await embeddingGenerator.GenerateVectorAsync("shark");

Console.WriteLine($"fish-dog similarity: {TensorPrimitives.CosineSimilarity(fishVector.Span, dogVector.Span):F2}");
Console.WriteLine($"fish-shark similarity: {TensorPrimitives.CosineSimilarity(fishVector.Span, SharkVector.Span):F2}");
Console.WriteLine($"dog-shark similarity: {TensorPrimitives.CosineSimilarity(dogVector.Span, SharkVector.Span):F2}");