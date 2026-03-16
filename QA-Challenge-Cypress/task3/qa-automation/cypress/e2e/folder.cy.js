import folderPage from '../pages/folderPage';
import LoginPage from '../pages/loginPage';
import data from '../fixtures/data.json';

describe('Manage Folders Tests', () => {

    const d = data.login;
    const f = data.folders;

    beforeEach(() => {
        LoginPage.visit('/login');
        LoginPage.quickLogin(d.validUser.username, d.validUser.password);
        cy.url().should('include', '/');
        LoginPage.visit('/folder');
    });

    it('Success new folder creatrion', () => {
        folderPage.createFolder(f.validFolder.name);
        folderPage.toastSuccess().should('be.visible');
    });

    it('Should not allow creating a folder with empty name', () => {
        folderPage.createFolderButton().click();
        folderPage.folderNameInput().should('be.visible');
        folderPage.clickSaveButton();
        folderPage.toastError().should('be.visible');
    });

    it('Should not allow creating a folder with a too large name', () => {
        folderPage.createFolder(f.invalidFolder.tooLongName);
        folderPage.toastError().should('be.visible');
    });

    it('Should not allow creating a folder with duplicate name', () => {
        folderPage.createFolder(f.validFolder.name);
        folderPage.createFolder(f.validFolder.name);
        folderPage.toastError().should('be.visible');
    });

    it('Success edit folder name', () => {
        folderPage.createFolder(f.updateFolder.oldName);
        folderPage.editFolder(f.updateFolder.newName);
        folderPage.toastUpdate().should('be.visible');
    });

    it('Should not edit folder name if the same name is selected', () => {
        folderPage.createFolder(f.updateFolder.oldName);
        folderPage.editFolder(f.updateFolder.oldName);
        folderPage.toastError().should('be.visible');
    });

    it('Should be posible to delete a folder', () => {
        folderPage.createFolder(f.deleteFolder.name);
        folderPage.deleteFolder();
        folderPage.toastDelete().should('be.visible');
    });

    it('Should be posible to cancel a folder deletion', () => {
        folderPage.createFolder(f.deleteFolder.name);
        folderPage.CancelDelete()
        folderPage.toastDelete().should('not.exist');
    });
});
