using Dominio.Entidades;
using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using LogicaAplicacion.Mapper;

namespace LogicaAplicacion.CasosUso.AuditoriaPrestamoCU
{
    public class AddAuditoriaPrestamo
        : ICUAdd<AuditoriaPrestamoDto>
    {
        private readonly IRepositorioAuditoriaPrestamo _repo;
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioUsuario _repoUsuario;

        public AddAuditoriaPrestamo(
            IRepositorioAuditoriaPrestamo repo,
            IRepositorioPrestamo repoPrestamo,
            IRepositorioUsuario repoUsuario
        )
        {
            _repo = repo;
            _repoPrestamo = repoPrestamo;
            _repoUsuario = repoUsuario;
        }

        public void Execute(AuditoriaPrestamoDto dto)
        {
            Prestamo prestamo =
                _repoPrestamo.GetById(dto.prestamoId);

            Usuario coordinador =
                _repoUsuario.GetById(dto.coordinadorId);

            AuditoriaPrestamo auditoria =
                AuditoriaPrestamoMapper.FromDto(
                    dto,
                    prestamo,
                    coordinador
                );

            _repo.Add(auditoria);
        }
    }
}