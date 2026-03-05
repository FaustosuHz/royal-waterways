class todoItemPage {

createTodoButton() {
    return cy.get('[data-cy=entityCreateButton]');
}

editTodoButton() {
     return cy.get('[data-cy="entityEditButton"]')
}
    
deleteTodoButton() {
return cy.get('[data-cy="entityDeleteButton"]');
}

confirmDeleteButton() {
  return cy.get('[data-cy="entityConfirmDeleteButton"]');
}

cancelDeleteButton() {
return cy.contains('Cancel');
}

todoNameInput() {
    return cy.get('[data-cy=title]');
}

todoDescriptionInput() {
    return cy.get('[data-cy=description]');
}

todoFolderSelect() {
    return cy.get('#to-do-item-folder');
}

toastSuccess() {
    return cy.contains('created');
}

toastUpdate() {
    return cy.contains('updated');
}

toastDelete() {
    return cy.contains('is deleted');
}

toastError() {
     return cy.contains('Error');
}

clickSaveButton() {
    return cy.get('[data-cy=entityCreateSaveButton]').click();
}
  

createTodo(title, description) {
    this.createTodoButton().click();
    this.todoNameInput().type(title);
    this.todoDescriptionInput().type(description);
    this.clickSaveButton();
}

createTodoWithFolder(title, description) {
    this.createTodoButton().click();
    this.todoNameInput().type(title);
    this.todoDescriptionInput().type(description);

    this.todoFolderSelect()
        .find('option')
        .then(options => {
            const lastValue = options[options.length - 1].value;
            this.todoFolderSelect().select(lastValue);
        });

    this.clickSaveButton();
}

createTodoWithoutTitle(description) {
    this.createTodoButton().click();
    this.todoDescriptionInput().type(description);
    this.clickSaveButton();
}

editTodo(newName) {
    this.editTodoButton().last().click();
    this.todoNameInput().clear().type(newName);
    this.clickSaveButton();
}


deleteTodo() {
    this.deleteTodoButton().last().click();
    this.confirmDeleteButton().click();
}

cancelDelete() {
    this.deleteTodoButton().last().click();
    this.cancelDeleteButton().click();
}
}

export default new todoItemPage();