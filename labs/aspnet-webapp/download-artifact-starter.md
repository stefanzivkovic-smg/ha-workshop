## Starter File: ASP.NET Web App Download Artifact

```yaml
name: ASP.NET Web App - Download Artifact

on:
  push:
    paths:
      - '.github/workflows/aspnet-webapp-download-artifact.yml'
      - 'src/dotnet/WebApp/**'
  workflow_dispatch:

jobs:
  build-and-upload:
    runs-on: ubuntu-latest
    defaults:
      run:
        working-directory: ./src/dotnet/WebApp
    steps:
      - name: Checkout Code
        uses: actions/checkout@v4.1.7

      - name: Set up .NET Core
        uses: actions/setup-dotnet@v4.0.1
        with:
          dotnet-version: '8.x'

      - name: Build Code
        run: dotnet build --configuration Release

      - name: Publish Code
        run: dotnet publish -c Release --property:PublishDir="${{runner.temp}}/webapp"

      - name: Upload Artifact
        uses: actions/upload-artifact@v4.3.6
        with:
          name: aspnet-web-app # Artifact name
          path: ${{runner.temp}}/webapp
```
