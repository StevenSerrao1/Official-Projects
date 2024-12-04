# Step 1: Use the ASP.NET runtime image for the container
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Step 2: Use the .NET SDK for building your app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ./MyPortfolioSolution/MyPortfolioSolution.csproj /src/
RUN dotnet restore "MyPortfolioSolution.csproj"

# Copy the Service, ServiceContracts, and Entities folders (all from Initial-MyPortfolio)
COPY Services/ ../Services/
COPY ServiceContracts/ ./ServiceContracts/
COPY Entities/ ./Entities/

# Copy everything else from Initial-MyPortfolio into the container
COPY ./ ./  # Copy everything from the current context

RUN dotnet publish -c Release -o /app/publish "MyPortfolioSolution.csproj"

# Step 3: Final image for running the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolioSolution.dll"]
