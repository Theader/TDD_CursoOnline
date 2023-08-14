import { Selector } from 'testcafe';

fixture('Curso')
    .page('localhost:3000/Curso/Novo')

test('Deve criar um novo curso', async t => {
    await t
        .typeText(Selector('[name="Nome"]'), 'Curso TestCafé $(new Date().toString()')
        .typeText(Selector('[name="CargaHoraria"]'), '10')
        .click(Selector('[name="PublicoAlvo"]'))
        .click(Selector('option[value="Empregado"]'))
        .click(Selector('[value="Online"]'))
        .typeText(Selector('[name="Valor"]'), '1000');

    await t
        .click(Selector('.btn-success'));
    await t
        .expect(Selector('title').innerText).eql('Listagem de cursos - CursoOnline.Web')
});

test('Deve validar campos obrigatórios', async t => {
    await t
        .click(Selector('.btn-sucess'));
    await t
        .expect(Selector('.toast-message').withText('Nome inválido').count).eql(1)
        .expect(Selector('.toast-message').withText('Valor precisa ser maior que 0.').count).eql(1)
        .expect(Selector('.toast-message').withText('CargaHorária precisa ser maior que 0.').count).eql(1);

})