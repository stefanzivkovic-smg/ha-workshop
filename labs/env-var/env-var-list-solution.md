## Solution: Environment Variable List

```yaml
name: Env Var List

on:
  workflow_dispatch:
  push:
    paths:
      - '.github/workflows/env-var-list.yml'

jobs:
  ubuntu:
    runs-on: ubuntu-latest
    steps:
      - name: Display Environment Variables on Ubuntu
        run: printenv | sort
  mac:
    runs-on: macos-latest
    steps:
      - name: Display Environment Variables on MacOS
        run: printenv | sort
  windows:
    runs-on: windows-latest
    steps:
      - name: Display Environment Variables on Windows
        run: printenv | sort
        shell: bash
# This job can also be implemented using matrix as shown below

# jobs:
#   display:
#     strategy:
#       matrix:
#         os: [ubuntu-latest, windows-latest, macos-latest]
#     runs-on: ${{ matrix.os }}
#     steps:
#       - name: Display Environment Variables
#         run: printenv | sort
#         shell: bash
```
