import LoginPage from '../pages/loginPage'
import data from '../fixtures/data.json'

describe('Login suite', () => {

  beforeEach(() => {
    LoginPage.visit('/login')
  })

  const d = data.login;

  it('successful login with valid credentials', () => {
    LoginPage.login(d.validUser.username, data.login.validUser.password);
    LoginPage.clickSubmitButton();
    cy.url().should('include', '/');
  })

  it('successful login with valid credentials and remember me checkbox', () => {
    LoginPage.login(d.validUser.username, data.login.validUser.password);
    LoginPage.clickRememberMeCheckBox();
    LoginPage.clickSubmitButton();
    cy.url().should('include', '/');
  })

  it('login with invalid credentials shows an error message', () => {
    LoginPage.login(d.invalidUser.username, data.login.invalidUser.password);
    LoginPage.clickSubmitButton();
    LoginPage.loginError().should('be.visible');
  })

  it('shows error with empty credentials', () => {
    LoginPage.clickSubmitButton();
    LoginPage.errorMessage().should('be.visible');
  })
  
  it('successful logout', () => {
    LoginPage.login(d.validUser.username, data.login.validUser.password);
    LoginPage.clickSubmitButton();
    cy.url().should('include', '/');
    LoginPage.Logout();

    LoginPage.visit('/');
    LoginPage.usernameInput().should('be.visible');
    LoginPage.passwordInput().should('be.visible');
  })

  it('successful password recovery email send UI', () => {
    LoginPage.visit('/account/reset/request');

    LoginPage.typeRecoveryEmail(d.email.correctEmail);
    LoginPage.clickSubmitButton();
    LoginPage.toastSuccessEmailSend().should('be.visible');
  })

  it('wrong email in password recovery email should display an error', () => {
    LoginPage.visit('/account/reset/request');

    LoginPage.typeRecoveryEmail(d.email.wrongEmail);
    LoginPage.clickSubmitButton();
    LoginPage.errorMessage().should('be.visible');
  })
})
