FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EMailAPI/EMailAPI.csproj", "EMailAPI/"]
RUN dotnet restore "EMailAPI/EMailAPI.csproj"
COPY . .
WORKDIR "/src/EMailAPI"
RUN dotnet build "EMailAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EMailAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMailAPI.dll"]
