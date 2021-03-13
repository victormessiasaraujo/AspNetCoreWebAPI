using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        public Aluno[] GetAllAlunos(bool preencheObjetoCompleto = false);

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool preencheObjetoCompleto = false);

        public Aluno GetAllAlunoById(int alunoId, bool preencheObjetoCompleto = false);

        public Professor[] GetAllProfessores(bool preencheObjetoCompleto = false);

        public Professor[] GetAllAProfessoresByDisciplinaId(int disciplinaId, bool preencheObjetoCompleto = false);

        public Professor GetAllProfessorById(int professorId, bool preencheObjetoCompleto = false);
    }
}