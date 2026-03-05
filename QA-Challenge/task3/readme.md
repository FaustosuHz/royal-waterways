# Cypress E2E Tests

Hello!

This test suite was created as a technical challenge. Below you will find some information that may be useful to understand and run the project.

Note: In a real project, some information should be added to the `.gitignore` file (such as test data, credentials, or environment-specific configuration).

The root directory of this project is the **qa-automation** folder.


## Stack
- Node.js
- Cypress
- JavaScript
- Page Object Model (POM)
- Cypress Fixtures for test data

## Setup

### Install dependencies

npm install

npx cypress open


### If Cypress is not installed yet:

npm install cypress --save-dev

### Running Cypress

Open Cypress Test Runner (interactive mode):

npx cypress open --e2e
npx cypress open


### Run all tests in headless mode:

npx cypress run


## Project Structure

```
qa-automation/
└─ cypress/
   ├─ e2e/                  # Test specs (*.cy.js)
   │  ├─ login.cy.js
   │  ├─ register.cy.js
   │  ├─ folder.cy.js
   │  ├─ todoItem.cy.js
   │  └─ settings.cy.js
   │
   ├─ pages/                # Page Objects
   │  ├─ loginPage.js
   │  ├─ registrationPage.js
   │  ├─ folderPage.js
   │  ├─ todoItemPage.js
   │  └─ settingsPage.js
   │
   ├─ fixtures/             # Test data
   │  └─ data.json
   │
   └─ cypress.config.js
```
