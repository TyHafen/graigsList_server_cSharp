FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY ./bin/Release/net5.0/publish/ App/
WORKDIR /App
CMD ASPNETCORE_URLS=http://*:$PORT dotnet graigsList_server_cSharp.dll
