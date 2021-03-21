module.exports = {
  rootDir: "./",
  verbose: true,
  clearMocks: true,
  restoreMocks: true,
  preset: "ts-jest",
  testEnvironment: "jsdom",
  testMatch: ["**/*.test.ts?(x)"],
  collectCoverageFrom: ["src/**/*.{ts,tsx}"],
  coverageDirectory: "coverage",
  coveragePathIgnorePatterns: ["src/index.tsx"],
  coverageThreshold: {
    global: {
      branches: 80,
      functions: 80,
      lines: 80,
      statements: 80,
    },
  },
};
