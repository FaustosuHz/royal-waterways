const { defineConfig } = require("cypress");

module.exports = defineConfig({
  allowCypressEnv: false,

  e2e: {
    baseUrl: "https://qa-challenge.ensolvers.com",
    setupNodeEvents(on, config) {
    },
  },
});