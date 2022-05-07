#!/bin/bash
set -eu -o pipefail

dotnet restore /code/Lis.Tests.csproj
dotnet test /code/Lis.Tests.csproj