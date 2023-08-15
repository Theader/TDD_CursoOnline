import { Selector } from 'testcafe';
import Curso from './Curso';

const curso = new Curso();
fixture('Curso')
    .page(curso.url)

test('Deve criar um novo curso', async t => {
    await t
        .typeText(curso.inputNome, `Curso TestCaf� ${new Date().toString()}`)
        .typeText(curso.inputCargaHoraria, '10')
        .click(Selector(curso.selectPublicoAlvo))
        .click(Selector(curso.opcaoEmpregado))
        .typeText(curso.inputValor, '1000');

    await t
        .click(Selector('.btn-success'));

    await t
        .expect(curso.titulodaPagina.innerText).eql('Listagem de cursos - CursoOnline.Web')
});

test('Deve validar campos obrigat�rios', async t => {
    await t
        .click(Selector('.btn-sucess'));
    await t
        .expect(curso.toastMessage.withText('Nome inv�lido').count).eql(1)
        .expect(curso.toastMessage.withText('Valor precisa ser maior que 0.').count).eql(1)
        .expect(curso.toastMessage.withText('CargaHor�ria precisa ser maior que 0.').count).eql(1);

})