using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<CatalogDbContext>(
    connectionName: "catalogdb");

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductAIService>();


// Ollama
builder.AddOllamaApiClient("llama")
    .AddChatClient();

builder.AddOllamaApiClient("nomic-embed-text")
    .AddEmbeddingGenerator();


// Qdrant
builder.AddQdrantClient("vectordb");

builder.Services.AddQdrantCollection<ulong, ProductVector>(
    "product-vectors");


var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseMigration();

app.MapProductEndpoints();

app.Run();