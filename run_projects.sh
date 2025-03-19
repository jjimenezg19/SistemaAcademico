#!/bin/bash
osascript -e 'tell app "Terminal" to do script "cd ~/SistemaAcademico/SistemaAcademico && dotnet run --project Api/Api.csproj && exit"'
osascript -e 'tell app "Terminal" to do script "dotnet run --project SistemaAcademico/SistemaAcademico.csproj"'
