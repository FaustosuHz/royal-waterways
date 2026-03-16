class registrationPage {

  usernameInput() {
    return cy.get('[data-cy="username"]');
  }

  emailInput() {
    return cy.get('[data-cy="email"]');
  }

  passwordInput() {
    return cy.get('[data-cy="firstPassword"]');
  }

  confirmPasswordInput() {
    return cy.get('[data-cy="secondPassword"]');
  }

  submitButton() {
    return cy.get('[data-cy="submit"]');
  }

  feedbackError() {
    return cy.get('.invalid-feedback');
  }

  successToast() {
    return cy.contains('Registration saved! Please check your email for confirmation.');
  }

  errorToast() {
    return cy.contains('error');
  }

  visit(url) {
    cy.visit(url);
  }

  accountButton() {
    return cy.get('.svg-inline--fa.fa-user.fa-w-14');
}

   registerButton() {
    return cy.get('[data-cy="register"]');
}
   submitButton() {
    return cy.get('[data-cy="submit"]');
}

   fillForm(username, email, password, confirmPassword) {
    if (username !== undefined) this.usernameInput().clear().type(username);
    if (email !== undefined) this.emailInput().clear().type(email);
    if (password !== undefined) this.passwordInput().clear().type(password);
    if (confirmPassword !== undefined) this.confirmPasswordInput().clear().type(confirmPassword);
  }

    submit() {
    this.submitButton().click();
  }
    goToRegister() {
    this.accountButton().click();
    this.registerButton().click();

  }
}

export default new registrationPage();