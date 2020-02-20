FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./PeopleWebApi.csproj", "PeopleWebApi/PeopleWebApi.csproj"]
RUN dotnet restore "PeopleWebApi/PeopleWebApi.csproj"
COPY . ./PeopleWebApi
WORKDIR "/src/PeopleWebApi"
RUN dotnet build "PeopleWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PeopleWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PeopleWebApi.dll"]