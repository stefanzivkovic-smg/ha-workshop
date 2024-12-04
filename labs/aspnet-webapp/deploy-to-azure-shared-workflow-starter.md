## Starter File: ASP.NET Web App Deploy to Azure Using Shared Workflow

```yaml
name: ASP.NET Web App Deploy to Azure
on:
  push:
    paths:
      - '.github/workflows/aspnet-webapp-deploy.yml'
      - 'src/dotnet/WebApp/**'

env:
  AZURE_WEBAPP_NAME: github-actions-workshop-aspnet-webapp
  AZURE_WEBAPP_PACKAGE_PATH: ./published
  CONFIGURATION: Release
  DOTNET_CORE_VERSION: 8.0.x
  WORKING_DIRECTORY: 'src/dotnet/WebApp'
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - name: Setup .NET SDK
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: ${{ env.DOTNET_CORE_VERSION }}
      - name: Verify Working Directory
        run: |
          echo "Current Directory: $(pwd)"
          ls ${{ env.WORKING_DIRECTORY }}
      - name: Restore dependencies
        run: dotnet restore ${{ env.WORKING_DIRECTORY }}
      - name: Build
        run: dotnet build "${{ env.WORKING_DIRECTORY }}" --configuration ${{ env.CONFIGURATION }} --no-restore
      - name: Publish
        run: dotnet publish "${{ env.WORKING_DIRECTORY }}" --configuration ${{ env.CONFIGURATION }} --output "${{ env.AZURE_WEBAPP_PACKAGE_PATH }}"
      - name: Publish Artifacts
        uses: actions/upload-artifact@v4
        with:
          name: webapp
          path: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}
  deploy:
```
