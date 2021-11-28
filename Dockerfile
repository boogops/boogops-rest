FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["src/Boogops.Rest/Boogops.Rest.csproj", "src/Boogops.Rest/"]
COPY ["src/Boogops.Common/Boogops.Common.csproj", "src/Boogops.Common/"]
RUN dotnet restore "src/Boogops.Rest/Boogops.Rest.csproj"
COPY . .
RUN dotnet build "src/Boogops.Rest/Boogops.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Boogops.Rest/Boogops.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boogops.Rest.dll"]
