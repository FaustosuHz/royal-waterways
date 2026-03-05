class folderPage {

  createFolderButton() {
    return cy.get('[data-cy="entityCreateButton"]');
  }

  folderNameInput() {
    return cy.get('[data-cy="name"]');
  }

  saveFolderButton() {
    return cy.get('[data-cy="entityCreateSaveButton"]');
  }

  folderList() {
    return cy.get('[data-cy="folder-list"]');
  }

  toastSuccess() {
  return cy.contains('A new folder is created');
  }

  toastUpdate() {
  return cy.contains('updated');
  }

  toastError() {
  return cy.contains('Error');
  }

  toastDelete() {
  return cy.contains('deleted');
  }

  editFolderButton() {
    return cy.get('[data-cy="entityEditButton"]');
  }

  deleteFolderButton() {
    return cy.get('[data-cy="entityDeleteButton"]');
  }

  confirmDeleteButton() {
    return cy.get('[data-cy="entityConfirmDeleteButton"]');
  }

  cancelDeleteButton() {
    return cy.contains('Cancel');
  }


  clickSaveButton() {
  this.saveFolderButton().click();
  }

  clickCreateFolderButton() {
  this.createFolderButton().click();
  }

  createFolder(name) {
    this.createFolderButton().click();
    this.folderNameInput().clear().type(name);
    this.saveFolderButton().click();
  }

  editFolder(name) {
    this.editFolderButton().last().click();
    this.folderNameInput().clear().type(name);
    this.saveFolderButton().click();
  }

  deleteFolder() {
    this.deleteFolderButton().last().click();
    this.confirmDeleteButton().click();
  }

  CancelDelete() {
    this.deleteFolderButton().last().click();
    this.cancelDeleteButton().click();
  }
}

export default new folderPage();