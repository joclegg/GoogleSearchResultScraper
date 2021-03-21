<!-- omit in toc -->

# React App shell

<!-- omit in toc -->

## Table of Contents

- [Prerequisites](#prerequisites)
- [Install](#install)
- [Start](#start)
- [Build](#build)
- [Validate code](#validate-code)
  - [Configure linter and code formatter in IDE](#configure-linter-and-code-formatter-in-ide)
    - [Visual Studio Code](#visual-studio-code)
    - [Rider and other IDEs from Jetbrains family](#rider-and-other-ides-from-jetbrains-family)
- [Unit tests](#unit-tests)
- [End-to-end tests](#end-to-end-tests)
- [Folder structure](#folder-structure)
- [Technology stack](#technology-stack)

## Prerequisites

First of all you have to install following software:

- Node 14+, install LTS (Long Term Support) version if you are not sure (https://nodejs.org/)
- Yarn (https://yarnpkg.com/getting-started/install)
- ESLint and Prettier plugins for the IDE of choice (see
  [Configure linter and code formatter in IDE](#configure-linter-and-code-formatter-in-ide))

## Install

In order to install or update dependencies run `yarn` in command line. Do this right after cloning the repo or pulling
new changes from git to be always up-to-date.

## Start

Then start the app using `yarn start` command which builds this package, starts it locally and watches for file changes. Frontend
will be hosted at http://localhost:8080/ by default.

## Build

Build this app using `yarn build` command which builds this package into `dist` folder.

**Note:** You don't need to build this package in order to run it locally (see [Start](#start)).

## Validate code

Validate source code using `yarn validate` command which checks if the code follows code guidelines and is formatted
properly. Format whole source code using `yarn format` command.

### Configure linter and code formatter in IDE

In this section there are instructions about how to configure linter and code formatter in IDE. When this setup is done
linter will highlight errors and code smells in editor while code formatter will format opened file on save following
Prettier's code guidelines.

#### Visual Studio Code

1. Open `Extensions` and install `ESLint` and `Prettier - Code Formatter`
2. Restart Visual Studio Code
3. Open `Settings`
4. Search for `Eslint: Always Show Status` and check the checkbox
5. Search for `Editor: Default Formatter` and select `esbenp.prettier-vscode`
6. Search for `Editor: Format On Save` and check the checkbox
7. Save and close `Settings`. You might need to restart editor again

#### Rider and other IDEs from Jetbrains family

1. Open `Preferences`
2. Go to `Plugins` and install `Prettier`. (There is no need to install ESLint as it is integrated into IDE). You might
   need to restart IDE after this
3. Go to `Languages & Frameworks > JavaScript > Code Quality Tools > ESLint`
   1. Check `Automatic ESLint configuration`
4. Go to `Languages & Frameworks > JavaScript > Prettier`
   1. `Node interpreter` has to be selected automatically but if not use `Project node` version
   2. Select `Prettier package` from `node_modules/prettier`
   3. Enter `{**/*,*}.{js,ts,jsx,tsx,json}` as glob pattern for `Run for files` field
   4. Check `On code reformat` and `On save` checkboxes
5. Click `OK` button. You might need to restart IDE again

## Unit tests

There are few commands to run unit tests:

- `yarn unit-test:watch` runs all unit tests and watches for file changes
- `yarn unit-test:coverage` runs all unit tests and generates test coverage report (report can be opened in browser from
  `coverage/lcov-report/index.html` file)

## End-to-end tests

There are few ways to run end-to-end tests:

- `yarn e2e-test` runs app in development mode and opens Cypress Test Runner with feature-rich and convenient UI in
  browser where you can select which tests to run
- `yarn e2e-test:ci` runs app in production mode and then runs all e2e tests in command line

## Folder structure

- `public` - Static files (e.g. html files, images, fonts, etc.)
- `src` - Source folder
  - `components` - React components
    - `App` - App component folder which is a root component, other component folders should have same structure and might contain group of related components
      - `App.tsx` - Component itself
      - `App.test.tsx` - Component's unit tests
      - `AppStyles.ts` - Component's styles
    - `index.ts` - Re-exports all the components for more convenient importing
  - `services` - Services, e.g. ApiService
  - `types` - Types, interfaces, enums, etc.
  - `config.ts` - Main configuration file
  - `index.tsx` - Entry point for frontend code

## Technology stack

- **TypeScript** - programming language, extends JavaScript by adding types (https://www.typescriptlang.org/)
- **React** - JavaScript library for building user interfaces (https://reactjs.org/)
- **Material UI** - library which contains big set of styled React components (https://material-ui.com/)
- **Axios** - Promise based HTTP client (https://github.com/axios/axios)
- **Webpack** - static module bundler, bundles source code into single file (https://webpack.js.org/)
- **ESLint** - static code analyser, finds problems in JavaScript/TypeScript code (https://eslint.org/)
- **Prettier** - code formatter, automatically formats code according to their own code guidelines (https://prettier.io/)
- **Jest** - unit testing library, used as a test runner here (https://jestjs.io/)
- **React Testing Library** - unit testing library, used as an assertion library for React applications (https://testing-library.com/)
