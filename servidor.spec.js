import { Selector } from 'testcafe';
import Page from './page';

const page = new Page();

fixture{ 'Servidor' }
    .page(page.urlBase)

test('Validando se est� de p�', async t => {
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});