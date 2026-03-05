import registrationPage from '../pages/registrationPage';
import data from '../fixtures/data.json';

describe('Registration Suite', () => {

  beforeEach(() => {
    registrationPage.visit('/account/reset/request');
    registrationPage.goToRegister();
  });

  it('registration successfully with valid data', () => {
    const u = data.registration.validUser;
    registrationPage.emailInput().should('be.visible');
    registrationPage.fillForm(u.username, u.email, u.password, u.confirmPassword);
    registrationPage.submit();
    registrationPage.successToast().should('be.visible');
  });

  it('registration the same user should throw an error', () => {
    const u = data.registration.validUser;
    registrationPage.fillForm(u.username, u.email, u.password, u.confirmPassword);
    registrationPage.submit();
    registrationPage.successToast().should('be.visible');

    //we try to register again the same user
    registrationPage.fillForm(u.username, u.email, u.password, u.confirmPassword);
    registrationPage.errorToast().should('be.visible');
  });

  it('shows error for invalid username', () => {
    const u = data.registration.validUser;
    registrationPage.fillForm(data.registration.invalidUsername, u.email, u.password, u.confirmPassword);
    registrationPage.submit();
    registrationPage.feedbackError().should('be.visible');
  });

  it('shows error for invalid email', () => {
    const u = data.registration.validUser;
    registrationPage.fillForm(u.username, data.registration.invalidEmail, u.password, u.confirmPassword);
    registrationPage.submit();
    registrationPage.feedbackError().should('be.visible');
  });

  it('shows error for invalid password', () => {
    const u = data.registration.validUser;
    registrationPage.fillForm(u.username, u.email, data.registration.invalidPassword, u.confirmPassword);
    registrationPage.submit();
    registrationPage.feedbackError().should('be.visible');
  });

  it('shows error when passwords do not match', () => {
    const u = data.registration.validUser;
    registrationPage.fillForm(u.username, u.email, u.password, data.registration.mismatchedPassword);
    registrationPage.submit();
    registrationPage.feedbackError().should('be.visible'); 
  });

  it('shows errors when all fields are empty', () => {
    registrationPage.submit();
    registrationPage.feedbackError().should('be.visible');
  });
});
