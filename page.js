import { Selector } from 'testcafe';

export default class Page {
    constructor() {
        this.urlBase = 'localhost:3000';
        this.titulodaPagina = Selector('title');
        this.toastMessage = Selector('.toast-message');
    }
}