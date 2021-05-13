#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CustomerManagement.Abstractions/CustomerManagement.Abstractions.csproj", "CustomerManagement.Abstractions/"]
RUN dotnet restore "CustomerManagement.Abstractions/CustomerManagement.Abstractions.csproj"
COPY . .
WORKDIR "/src/CustomerManagement.Abstractions"
RUN dotnet build "CustomerManagement.Abstractions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerManagement.Abstractions.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerManagement.Abstractions.dll"]