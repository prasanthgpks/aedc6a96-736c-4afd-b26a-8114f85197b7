#!/bin/bash
set -eu -o pipefail

dotnet restore /code/LongestIncreasingSequence/LIS.Tests.csproj
dotnet test /code/LongestIncreasingSequence/LIS.Tests.csproj