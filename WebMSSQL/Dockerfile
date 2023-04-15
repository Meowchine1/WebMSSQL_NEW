#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebMSSQL/WebMSSQL.csproj", "WebMSSQL/"]
COPY ["TelegramBot/TelegramBot.csproj", "TelegramBot/"]
RUN dotnet restore "WebMSSQL/WebMSSQL.csproj"
COPY . .
WORKDIR "/src/WebMSSQL"
RUN dotnet build "WebMSSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMSSQL.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMSSQL.dll"]

#docker build  -t testcontainer -f WebMSSQL/Dockerfile .
# docker run -p 50001:80 -d testcontainer
# второй проект тож добавить