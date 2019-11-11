FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["lr.apps.cash-machine/lr.apps.cash-machine.csproj", "lr.apps.cash-machine/"]
RUN dotnet restore "lr.apps.cash-machine/lr.apps.cash-machine.csproj"
COPY . .
WORKDIR "/src/lr.apps.cash-machine"
RUN dotnet build "lr.apps.cash-machine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lr.apps.cash-machine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/out .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lr.apps.cash-machine.dll"]