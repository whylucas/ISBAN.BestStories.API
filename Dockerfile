FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ISBAN.BestStories.API/ISBAN.BestStories.API.csproj", "ISBAN.BestStories.API/"]
RUN dotnet restore "ISBAN.BestStories.API/ISBAN.BestStories.API.csproj"
COPY . .
WORKDIR "/src/ISBAN.BestStories.API"
RUN dotnet build "ISBAN.BestStories.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ISBAN.BestStories.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ISBAN.BestStories.API.dll"]