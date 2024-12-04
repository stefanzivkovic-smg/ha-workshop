## Lab: ASP.NET Web App Upload Artifact

## Introduction

In this lab, you will create a GitHub Actions workflow to upload artifact generated during the build process of an ASP.NET Web Application. This lab demonstrates the use of the `actions/upload-artifact` action to store build outputs for later use.

> **Duration**: 15-20 minutes

---

## Prerequisites

Before starting this lab, ensure that:

1. You have completed the [ASP.NET Web App Build with Ubuntu Runner](./build-ubuntu-runner-lab.md) lab.
2. The **ASP.NET Web App Build on Ubuntu Runner Workflow** is functional and capable of generating build artifact.

Refer to the [ASP.NET Web App Upload Artifact Starter](./upload-artifact-starter.md) file for the initial workflow content.

---

## Instructions

### Step 1: Create a YAML Workflow Using the Starter File

1. Refer to the [**ASP.NET Web App Upload Artifact Starter File**](./upload-artifact-starter.md).
2. Copy the content of the starter file:

   ```yaml
   name: ASP.NET Web App Upload Artifact

   on:
     push:
       paths:
         - '.github/workflows/aspnet-webapp-build-ubuntu-runner.yml'
         - 'src/dotnet/WebApp/**'
     workflow_dispatch:

   jobs:
     build:
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
   ```

3. In your repository, create a new workflow file under `.github/workflows` and name it `aspnet-webapp-upload-artifact.yml`.
4. Paste the copied content into the new file.
5. Commit and push the changes to your repository.

---

### Step 2: Add the Upload Artifact Step

1. Open the `aspnet-webapp-build-upload-artifact.yml` file in your repository.
2. Add a step to upload the generated artifact after the `Publish Code` step. Update the `jobs` section to include the following:

   ```yaml
   - name: Upload Artifact
     uses: actions/upload-artifact@v4.3.6
     with:
       name: aspnet-web-app # Artifact name
       path: ${{runner.temp}}/webapp # Path to the published artifact
   ```

   - **Artifact name**: The name assigned to the artifact (`aspnet-web-app` in this case).
   - **Path**: Specifies the directory containing the build output.

---

### Step 3: Verify the Complete Workflow File

Ensure your `aspnet-webapp-upload-artifact.yml` file matches the following:

```yaml
name: ASP.NET Web App - Upload Artifact

on:
  push:
    paths:
      - '.github/workflows/aspnet-webapp-upload-artifact.yml'
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
          name: aspnet-web-app
          path: ${{runner.temp}}/webapp
```

---

### Step 4: Commit and Push the Workflow File

1. Save the changes to the `aspnet-webapp-upload-artifact.yml` file.
2. Commit the updated file with a descriptive message, e.g., `"Added workflow for uploading build artifact"`.
3. Push the changes to your repository.

---

### Step 5: Trigger and Run the Workflow

1. Navigate to the **Actions** tab in your GitHub repository.
2. Manually trigger the **ASP.NET Web App - Upload Artifact** workflow via the **workflow_dispatch** event.
3. Monitor the workflow run and ensure the `build-and-upload` job executes successfully.

---

### Step 6: Verify the Uploaded Artifact

1. Once the workflow completes, go to the **Artifact** section on the summary page of the workflow run.
2. Confirm that the `aspnet-web-app` artifact is listed.
3. Download the artifact, extract it locally, and verify that it matches the expected output.

---

## Summary

In this lab, you extended the ASP.NET Web App build workflow to upload artifact using the `actions/upload-artifact` action. You learned how to configure and trigger a new workflow for uploading build outputs and verified the artifact in GitHub Actions.

---

This version maintains the focus on the upload artifact functionality, with clear instructions for creating a new workflow dependent on the build workflow. Let me know if further adjustments are needed!
