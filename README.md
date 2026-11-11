# Project 1 (Properties)

A .NET API with static data that also serves an Angular page, plus Bruno and Playwright tests.

| Folder | What it is | Tests |
|---|---|---|
| `api/` | .NET 10 minimal API (`/api/properties`, `/api/health`) | MSTest |
| `web/` | Angular page, built into the API at deploy time | Vitest |
| `bruno/` | API tests, run against the deployed App Service | Bruno CLI |
| `playwright/` | UI tests, run against the deployed App Service | Playwright |

## Pipeline
`.github/workflows/ci.yml` runs on every push to `main`:
1. Runs the .NET and Angular unit tests.
2. Builds the app and deploys it to the App Service.
3. Runs the Bruno and Playwright tests against the live address.
4. Writes one result file (`summary.json`) and publishes it, at the same time, to blob storage and to `result-repo`.

## Repository secrets needed
`AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_SUBSCRIPTION_ID` and `RESULTS_REPO_TOKEN`.

## Run locally
```bash
cd api/SampleApi && dotnet run --urls http://127.0.0.1:5003       # terminal 1
cd web && npm install && npm start                                 # terminal 2, page on http://127.0.0.1:4200
cd bruno && npm install && npm test                                # API tests against http://127.0.0.1:5003
cd playwright && npm install && npx playwright install chromium && BASE_URL=http://127.0.0.1:4200 npm test
```
