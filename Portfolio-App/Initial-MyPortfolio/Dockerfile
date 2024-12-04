# Step 1: Use the ASP.NET runtime image for the container
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Step 2: Use the .NET SDK for building your app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY MyPortfolioSolution/MyPortfolioSolution.csproj ./   # Copy from the root directory
RUN dotnet restore "MyPortfolioSolution.csproj"

# Copy the Service, ServiceContracts, and Entities folders from the root directory
COPY ./Services/ ./Services/
COPY ./ServiceContracts/ ./ServiceContracts/
COPY ./Entities/ ./Entities/

# Copy everything else from the root directory
COPY ./ ./ 

RUN dotnet publish "MyPortfolioSolution.csproj" -c Release -o /app/publish

# Step 3: Final image for running the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolioSolution.dll"]
