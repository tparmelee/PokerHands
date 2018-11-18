FROM microsoft/dotnet:2.1-sdk as builder
WORKDIR /source

COPY *.csproj .
RUN dotnet restore

COPY ./ ./

RUN dotnet publish "./PokerHands.API.csproj" --output "./dist" --configuration Debug --no-restore

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=builder /source/dist .
EXPOSE 80 5000
ENTRYPOINT ["dotnet", "PokerHands.API.dll"]
