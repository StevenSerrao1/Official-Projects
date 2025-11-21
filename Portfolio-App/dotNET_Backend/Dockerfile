# Step 1: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Step 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything in this folder (Dockerfile is in same folder as .csproj)
COPY . ./

# Restore dependencies
RUN dotnet restore "*.csproj"

# Publish
RUN dotnet publish -c Release -o /app/publish "*.csproj"

# Step 3: Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "MyPortfolioSolution.dll"]  # replace with actual DLL
