# GenAI for .NET: Build LLM Apps with OpenAI and Ollama

[![.NET](https://img.shields.io/badge/.NET-9-blueviolet)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

<img width="1371" height="489" alt="Image" src="https://github.com/user-attachments/assets/54360bbb-c541-4f2f-93f0-e87948a3c12e" />

A comprehensive, hands-on repository for building Generative AI applications with .NET 9. This project covers the full AI development pipeline — from basic LLM interactions to a complete AI-powered microservices application — using both cloud and local models.

A key design philosophy here is **flexibility**. All applications are built using Microsoft's `Microsoft.Extensions.AI` abstractions, allowing you to seamlessly switch between best-in-class cloud models from **OpenAI** (via GitHub Models) and powerful, private, free-to-run local models with **Ollama**.

---

## 🚀 What's Covered

A variety of real-world AI applications are implemented across the following areas:

- **💬 Chat & Text Analysis** — Intelligent chatbots, text classification, summarization, sentiment analysis, and prompt engineering.

- **🛠️ Function Calling** — Extend LLM capabilities by wiring up C# methods to fetch real-time data or trigger actions.

- **🔍 Vector Search & Embeddings** — Turn text into semantic vectors and perform powerful similarity searches — the core of modern recommendation engines.

- **📚 Retrieval-Augmented Generation (RAG)** — A complete RAG pipeline that answers questions from your own private documents, grounding responses in facts and reducing hallucinations.

- **🖼️ Image Analysis** — Multimodal AI applications that interpret image content and extract structured data from visual inputs (e.g., traffic camera monitoring).

- **🏆 E-Shop Semantic Search** — A full AI-powered eShop with semantic search built on a distributed microservices architecture using **.NET Aspire**, a **Qdrant** vector database, and models like **gpt-4o-mini**.

---

## 💻 Technology Stack

- **.NET 9**
- **ASP.NET Core** (Minimal APIs, Blazor)
- **.NET Aspire** for orchestration
- **OpenAI / GitHub Models** (`gpt-4o-mini`, `text-embedding-3-small`)
- **Ollama** (`Llama 3.2`, `LLaVA`, `all-minilm`)
- **Qdrant** Vector Database
- **Microsoft.Extensions.AI** Abstractions
- **Entity Framework Core** & **PostgreSQL**
- **Redis**, **RabbitMQ**, **Keycloak**
- **Docker**

---

## 📂 Repository Structure

Each numbered folder is a self-contained project:

| Folder | Description |
|---|---|
| `01-TextCompletionSentiment` | Text generation, streaming, structured output, and analysis |
| `02-ChatApp` | Interactive, context-aware chatbot |
| `03-FunctionCalling` | Enabling the LLM to execute C# code |
| `04-VectorSearch` | Embeddings and vector database fundamentals |
| `05-RAGApplication` | Complete RAG app with a custom knowledge base |
| `06-ImageAnalysis` | Multimodal AI with vision models |
| `07-EShopVectorSearch` | Capstone project — .NET Aspire + microservices + semantic search |

---

## 🏁 Getting Started

### Prerequisites

- **.NET 9 SDK** (or later)
- **Docker Desktop** (required for Ollama and Qdrant)
- **Visual Studio 2022** or **Visual Studio Code** (with the C# Dev Kit)

### Configuration

API keys are managed via .NET's `user-secrets` feature to keep them out of source control.

**For OpenAI / GitHub Models**, navigate to any project directory and run:

```bash
dotnet user-secrets init
dotnet user-secrets set "GitHubModels:Token" "YOUR_GITHUB_PAT_HERE"
```

**For the E-Shop project (using .NET Aspire)**, navigate to the `EShopVectorSearch.AppHost` directory and run:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:openai" "Endpoint=https://models.inference.ai.azure.com;Key=YOUR_GITHUB_PAT_HERE"
```

---
