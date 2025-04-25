using DataAccess.CRUD;
using DTO;

namespace BL;

public class NotaManager
{
    private readonly NotaCrudFactory _notaCrud;

    public NotaManager()
    {
        _notaCrud = new NotaCrudFactory();
    }

    public List<RegistroNota> ObtenerNotasPorGrupo(int grupoId)
    {
        return _notaCrud.RetrieveByGrupo(grupoId);
    }
    
    public List<Alumno> ObtenerEstudiantesDelGrupo(int grupoId)
    {
        return _notaCrud.ObtenerEstudiantesPorGrupo(grupoId);
    }

    public string RegistrarOModificarNota(RegistroNota nota)
    {
        return _notaCrud.Create(nota);
    }
    
    public string RegistrarNota(string cedulaAlumno, int grupoId, float nota)
    {
        var registro = new RegistroNota
        {
            Alumno = new Alumno { Cedula = cedulaAlumno },
            Grupo = new Grupo { Id = grupoId },
            Nota = nota
        };

        return RegistrarOModificarNota(registro);
    }
    
    public List<Grupo> ObtenerGruposDelProfesor(string cedulaProfesor)
    {
        return _notaCrud.ObtenerGruposPorProfesor(cedulaProfesor);
    }
}