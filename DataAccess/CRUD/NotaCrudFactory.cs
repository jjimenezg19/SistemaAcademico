using DataAccess.Mapper;
using System.Collections.Generic;
using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;

namespace DataAccess.CRUD
{
    public class NotaCrudFactory : CrudFactory
    {
        private readonly NotaMapper _mapper;

        public NotaCrudFactory()
        {
            _mapper = new NotaMapper();
            dao = MySqlDao.GetInstance();
        }

        public override string Create(BaseClass entityDTO)
        {
            var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            var operation = _mapper.GetCreateStatement(entityDTO, outputParam);
            dao.ExecuteStoredProcedure(operation);
            return outputParam.Value.ToString();
        }

        public override void Update(BaseClass entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO, null);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO, null);
            dao.ExecuteStoredProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var results = dao.ExecuteStoredProcedureWithQuery(_mapper.GetRetrieveAllStatement());
            var objects = _mapper.BuildObjects(results);

            var castedList = new List<T>();
            foreach (var obj in objects)
            {
                if (obj is T castedObj)
                {
                    castedList.Add(castedObj);
                }
            }
            return castedList;
        }

        public override BaseClass RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);
            if (result == null) return null;
            return _mapper.BuildObject(result);
        }

        public List<RegistroNota> RetrieveByGrupo(int grupoId)
        {
            var operation = _mapper.GetRetrieveByGrupoStatement(grupoId);
            var results = dao.ExecuteStoredProcedureWithQuery(operation);
            var objects = _mapper.BuildObjects(results);
            return objects.ConvertAll(x => (RegistroNota)x);
        }
        
        public List<Alumno> ObtenerEstudiantesPorGrupo(int grupoId)
        {
            var operation = _mapper.GetRetrieveEstudiantesPorGrupoStatement(grupoId);
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return result.Select(r => (Alumno)new AlumnoMapper().BuildObject(r)).ToList();
        }
        
        public List<Grupo> ObtenerGruposPorProfesor(string cedulaProfesor)
        {
            var operation = _mapper.GetRetrieveGruposPorProfesorStatement(cedulaProfesor);
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return null;
            //result.Select(r => (Grupo) //GrupoMapper().BuildObject(r)).ToList();
        }
    }
}