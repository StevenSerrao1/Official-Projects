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

# Copy everything else from Initial-MyPortfolio into the container
COPY ./MyPortfolioSolution/. /src/MyPortfolioSolution/

RUN dotnet publish -c Release -o /app/publish "MyPortfolioSolution.csproj"

# Step 3: Final image for running the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolioSolution.dll"]
