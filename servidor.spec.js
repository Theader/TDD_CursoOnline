import { Selector } from 'testcafe';

fixture{ 'Servidor' }
    .page('localhost:3000')

test('Validando se est� de p�', async t => {
    await t.expect(Selector('title').innerText).eql('Home Page - CursoOnline.Web');
});