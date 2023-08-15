import { Selector } from 'testcafe';
import Curso from './Curso';

const curso = new Curso();
fixture('Curso')
    .page(curso.url)

test('Deve criar um novo curso', async t => {
    await t
        .typeText(curso.inputNome, `Curso TestCafé ${new Date().toString()}`)
        .typeText(curso.inputCargaHoraria, '10')
        .click(Selector(curso.selectPublicoAlvo))
        .click(Selector(curso.opcaoEmpregado))
        .typeText(curso.inputValor, '1000');

    await t
        .click(Selector('.btn-success'));

    await t
        .expect(curso.titulodaPagina.innerText).eql('Listagem de cursos - CursoOnline.Web')
});

test('Deve validar campos obrigatórios', async t => {
    await t
        .click(Selector('.btn-sucess'));
    await t
        .expect(curso.toastMessage.withText('Nome inválido').count).eql(1)
        .expect(curso.toastMessage.withText('Valor precisa ser maior que 0.').count).eql(1)
        .expect(curso.toastMessage.withText('CargaHorária precisa ser maior que 0.').count).eql(1);

})