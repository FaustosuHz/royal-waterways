import todoItemPage from '../pages/todoItemPage';
import LoginPage from '../pages/loginPage';
import data from '../fixtures/data.json';

describe('Manage To-do Items Tests', () => {

    const d = data.login;
    const t = data.todos;

    beforeEach(() => {
        LoginPage.visit('/login');
        LoginPage.quickLogin(d.validUser.username, d.validUser.password);
        cy.url().should('include', '/');
        LoginPage.visit('/to-do-item');
    });

    it('Should create a new todo item without folder', () => {
        todoItemPage.createTodo(t.validTodo.title, t.validTodo.description);
        todoItemPage.toastSuccess().should('be.visible');
    });

    it('Should create a todo item with folder', () => {
        todoItemPage.createTodoWithFolder(t.todoWithoutFolder.title, t.todoWithoutFolder.description);
        todoItemPage.toastSuccess().should('be.visible');
    });

    it('Should not allow creating a todo with empty title', () => {
        todoItemPage.createTodoWithoutTitle(t.validTodo.description);
        todoItemPage.toastError().should('be.visible');
    });

    it('Should be possible to edit a todo item', () => {
        todoItemPage.createTodo(t.updateTodo.oldTitle, t.updateTodo.description);
        todoItemPage.editTodo(t.updateTodo.newTitle);
        todoItemPage.toastUpdate().should('be.visible');
    });

    it('Should delete todo item', () => {
        todoItemPage.createTodo(t.deleteTodo.title, t.deleteTodo.description);
        todoItemPage.deleteTodo();
        todoItemPage.toastDelete().should('be.visible');
    });

    it('Should cancel deletion of todo item', () => {
        todoItemPage.createTodo(t.deleteTodo.title, t.deleteTodo.description);
        todoItemPage.cancelDelete();

        todoItemPage.toastDelete().should('not.exist');
    });
});
