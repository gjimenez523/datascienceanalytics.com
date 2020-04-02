#FROM microsoft/aspnetcore:2.0 AS base
#WORKDIR /app
#EXPOSE 80

#FROM microsoft/aspnetcore-build:2.0 AS build
#WORKDIR /src
#COPY src/datascienceanalytics.com.Web/datascienceanalytics.com.Web.csproj src/datascienceanalytics.com.Web/
#COPY src/datascienceanalytics.com.EntityFrameworkCore/datascienceanalytics.com.EntityFrameworkCore.csproj src/datascienceanalytics.com.EntityFrameworkCore/
#COPY src/datascienceanalytics.com.Core/datascienceanalytics.com.Core.csproj src/datascienceanalytics.com.Core/#
#COPY src/datascienceanalytics.com.Application/datascienceanalytics.com.Application.csproj src/datascienceanalytics.com.Application/
#RUN dotnet restore src/datascienceanalytics.com.Web/datascienceanalytics.com.Web.csproj
#COPY . .
#WORKDIR /src/src/datascienceanalytics.com.Web
#RUN dotnet build datascienceanalytics.com.Web.csproj -c Release -o /app

#FROM build AS publish
#RUN dotnet publish datascienceanalytics.com.Web.csproj -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "datascienceanalytics.com.Web.dll"]


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app

COPY ./ /app/out/

ENTRYPOINT ["dotnet", "mysoonie.Web.Host.dll"]