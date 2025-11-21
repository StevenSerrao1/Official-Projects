# Step 1: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80 443

# Step 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project and restore dependencies
COPY MyPortfolioSolution.csproj ./
RUN dotnet restore "MyPortfolioSolution.csproj"

# Copy the rest of the project
COPY . ./

# Publish
RUN dotnet publish "MyPortfolioSolution.csproj" -c Release -o /app/publish

# Step 3: Runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "MyPortfolioSolution.dll"]