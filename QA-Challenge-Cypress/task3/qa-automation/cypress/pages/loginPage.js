class loginPage {

  usernameInput() {
    return cy.get('[data-cy="username"]')
  }

  passwordInput() {
    return cy.get('[data-cy="password"]')
  }

  loginButton() {
    return cy.get('[data-cy="submit"]')
  }

  rememberMeCheckBox() {
    return cy.get('#rememberMe')
  }

  accountButton() {
    return cy.get('.svg-inline--fa.fa-user.fa-w-14');
}

  logoutButton() {
    return cy.get('[data-cy="logout"]') 
}

  forgotPasswordButton(){
    return cy.get('[data-cy="forgetYourPasswordSelector"]')
}

  recoveryEmail() {
    return cy.get('#email')
}

toastSuccessEmailSend() {
  return cy.contains('Check your emails for details on how to reset your password.');
}

  loginError() {
    return cy.get('[data-cy="loginError"]')
  }

  errorMessage() {
    return cy.get('.invalid-feedback')
  }

  visit(url) {
    cy.visit(url)
  }

  login(username, password) {
    this.usernameInput().type(username)
    this.passwordInput().type(password)
  }

  quickLogin(username, password) {
    this.usernameInput().type(username)
    this.passwordInput().type(password)
    this.loginButton().click()
  }

  clickSubmitButton(){
    this.loginButton().click()
  }

  clickRememberMeCheckBox(){
    this.rememberMeCheckBox().click()
  }

  Logout(){
  this.accountButton().click()
  this.logoutButton().click()
  }

  clickForgotPassword(){
    this.forgotPasswordButton.click()
  }

  typeRecoveryEmail(email) {
    this.recoveryEmail().type(email)
  }

}

export default new loginPage()