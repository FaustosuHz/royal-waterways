using Dominio.Entidades;
using Dominio.ValueObjects.VOEquipo;
using Dominio.ValueObjects.VOObjetoCeleste;
using Dominio.ValueObjects.VOShared;
using Dominio.ValueObjects.VOUsuario;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class SeedData
    {
        private StellarMindsContext _context;

        public SeedData(StellarMindsContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.Usuarios.Any()) CrearUsuarios();
            if (!_context.Equipos.Any()) CrearEquipos();
            if (!_context.ObjetosCelestes.Any()) CrearObjetosCelestes();
            if (!_context.Prestamos.Any()) CrearPrestamos();
            if (!_context.Observaciones.Any()) CrearObservaciones();
        }

        public void CrearUsuarios()
        {

            _context.Usuarios.Add(
     new Administrador(
         new VONombre("Carlos"),
         new VOApellido("Perez"),
         new VODireccion("Av Italia 1234"),
         new VOTelefono("099123456"),
         new VOEmail("carlos.perez@gmail.com"),
         new VONombreUsuario("cperez01"),
         new VOContrasenia("Admin123!")
     ));

            _context.Usuarios.Add(
                new Administrador(
                    new VONombre("Laura"),
                    new VOApellido("Gomez"),
                    new VODireccion("Bvar Artigas 2200"),
                    new VOTelefono("099123457"),
                    new VOEmail("laura.gomez@gmail.com"),
                    new VONombreUsuario("lgomez01"),
                    new VOContrasenia("Admin456!")
                ));

            _context.Usuarios.Add(
                new Administrador(
                    new VONombre("Martin"),
                    new VOApellido("Suarez"),
                    new VODireccion("Rivera 1500"),
                    new VOTelefono("099123458"),
                    new VOEmail("martin.suarez@gmail.com"),
                    new VONombreUsuario("msuarez01"),
                    new VOContrasenia("Admin789!")
                ));

            _context.Usuarios.Add(
                new Coordinador(
                    new VONombre("Fausto"),
                    new VOApellido("Aristimuno"),
                    new VODireccion("19 de Abril 3406"),
                    new VOTelefono("091994433"),
                    new VOEmail("fausto@gmail.com"),
                    new VONombreUsuario("faristimuno"),
                    new VOContrasenia("Coord123!")
                ));

            _context.Usuarios.Add(
                new Coordinador(
                    new VONombre("Sofia"),
                    new VOApellido("Mendez"),
                    new VODireccion("8 de Octubre 1200"),
                    new VOTelefono("091994434"),
                    new VOEmail("sofia.mendez@gmail.com"),
                    new VONombreUsuario("smendez01"),
                    new VOContrasenia("Coord456!")
                ));

            _context.Usuarios.Add(
                new Coordinador(
                    new VONombre("Diego"),
                    new VOApellido("Fernandez"),
                    new VODireccion("Luis A Herrera 2100"),
                    new VOTelefono("091994435"),
                    new VOEmail("diego.fernandez@gmail.com"),
                    new VONombreUsuario("dfernand01"),
                    new VOContrasenia("Coord789!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Juan"),
                    new VOApellido("Martinez"),
                    new VODireccion("Colonia 1234"),
                    new VOTelefono("092111111"),
                    new VOEmail("juan.martinez@gmail.com"),
                    new VONombreUsuario("jmartinez01"),
                    new VOContrasenia("Socio123!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Ana"),
                    new VOApellido("Rodriguez"),
                    new VODireccion("Maldonado 2300"),
                    new VOTelefono("092111112"),
                    new VOEmail("ana.rodriguez@gmail.com"),
                    new VONombreUsuario("arodriguez1"),
                    new VOContrasenia("Socio456!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Pablo"),
                    new VOApellido("Diaz"),
                    new VODireccion("Convencion 1500"),
                    new VOTelefono("092111113"),
                    new VOEmail("pablo.diaz@gmail.com"),
                    new VONombreUsuario("pdiaz0001"),
                    new VOContrasenia("Socio789!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Lucia"),
                    new VOApellido("Castro"),
                    new VODireccion("Durazno 1800"),
                    new VOTelefono("092111114"),
                    new VOEmail("lucia.castro@gmail.com"),
                    new VONombreUsuario("lcastro01"),
                    new VOContrasenia("Socio321!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Federico"),
                    new VOApellido("Morales"),
                    new VODireccion("Yaguaron 1450"),
                    new VOTelefono("092111115"),
                    new VOEmail("federico.morales@gmail.com"),
                    new VONombreUsuario("fmorales01"),
                    new VOContrasenia("Socio654!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Paula"),
                    new VOApellido("Sosa"),
                    new VODireccion("Ejido 1800"),
                    new VOTelefono("092111116"),
                    new VOEmail("paula.sosa@gmail.com"),
                    new VONombreUsuario("psosa0001"),
                    new VOContrasenia("Socio987!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Andres"),
                    new VOApellido("Vega"),
                    new VODireccion("Cerro Largo 2200"),
                    new VOTelefono("092111117"),
                    new VOEmail("andres.vega@gmail.com"),
                    new VONombreUsuario("avega0001"),
                    new VOContrasenia("Socio741!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Florencia"),
                    new VOApellido("Ramos"),
                    new VODireccion("San Jose 1300"),
                    new VOTelefono("092111118"),
                    new VOEmail("florencia.ramos@gmail.com"),
                    new VONombreUsuario("framos001"),
                    new VOContrasenia("Socio852!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Gonzalo"),
                    new VOApellido("Pereira"),
                    new VODireccion("Soriano 2400"),
                    new VOTelefono("092111119"),
                    new VOEmail("gonzalo.pereira@gmail.com"),
                    new VONombreUsuario("gpereira01"),
                    new VOContrasenia("Socio963!")
                ));

            _context.Usuarios.Add(
                new Socio(
                    new VONombre("Micaela"),
                    new VOApellido("Acosta"),
                    new VODireccion("Mercedes 800"),
                    new VOTelefono("092111120"),
                    new VOEmail("micaela.acosta@gmail.com"),
                    new VONombreUsuario("macosta001"),
                    new VOContrasenia("Socio159!")
                ));

            _context.SaveChanges();
        }

        private void CrearEquipos()
        {
            // TELESCOPIOS

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Celestron"),
                    new VOModelo("NexStar 8SE"),
                    new VOCantidadDisponible(3),
                    new VOUnidadMM(203),
                    new VORelacionFocal("f/10"),
                    new VOUnidadMM(2032),
                    new VOUnidadKg(10)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Celestron"),
                    new VOModelo("CPC 800"),
                    new VOCantidadDisponible(2),
                    new VOUnidadMM(203),
                    new VORelacionFocal("f/10"),
                    new VOUnidadMM(2032),
                    new VOUnidadKg(19)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("Explorer 150P"),
                    new VOCantidadDisponible(3),
                    new VOUnidadMM(150),
                    new VORelacionFocal("f/5"),
                    new VOUnidadMM(750),
                    new VOUnidadKg(5)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("Explorer 200P"),
                    new VOCantidadDisponible(2),
                    new VOUnidadMM(200),
                    new VORelacionFocal("f/5"),
                    new VOUnidadMM(1000),
                    new VOUnidadKg(9)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("Evostar 80ED"),
                    new VOCantidadDisponible(4),
                    new VOUnidadMM(80),
                    new VORelacionFocal("f/7"),
                    new VOUnidadMM(600),
                    new VOUnidadKg(4)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("Evostar 100ED"),
                    new VOCantidadDisponible(2),
                    new VOUnidadMM(100),
                    new VORelacionFocal("f/9"),
                    new VOUnidadMM(900),
                    new VOUnidadKg(6)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Orion"),
                    new VOModelo("SkyQuest XT8"),
                    new VOCantidadDisponible(2),
                    new VOUnidadMM(203),
                    new VORelacionFocal("f/6"),
                    new VOUnidadMM(1200),
                    new VOUnidadKg(9)));

            _context.Equipos.Add(
                new EquipoTelescopio(
                    new VOMarca("Meade"),
                    new VOModelo("LX90"),
                    new VOCantidadDisponible(1),
                    new VOUnidadMM(203),
                    new VORelacionFocal("f/10"),
                    new VOUnidadMM(2000),
                    new VOUnidadKg(15)));



            // MONTURAS

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("EQ5"),
                    new VOCantidadDisponible(4),
                    TipoMontura.Ecuatorial,
                    new VOUnidadKg(10),
                    false));

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("HEQ5 Pro"),
                    new VOCantidadDisponible(3),
                    TipoMontura.Ecuatorial,
                    new VOUnidadKg(15),
                    true));

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("EQ6-R Pro"),
                    new VOCantidadDisponible(2),
                    TipoMontura.Ecuatorial,
                    new VOUnidadKg(20),
                    true));

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("Celestron"),
                    new VOModelo("Advanced VX"),
                    new VOCantidadDisponible(3),
                    TipoMontura.Ecuatorial,
                    new VOUnidadKg(14),
                    true));

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("iOptron"),
                    new VOModelo("CEM26"),
                    new VOCantidadDisponible(2),
                    TipoMontura.Hibrida,
                    new VOUnidadKg(12),
                    true));

            _context.Equipos.Add(
                new EquipoMontura(
                    new VOMarca("iOptron"),
                    new VOModelo("GEM45"),
                    new VOCantidadDisponible(2),
                    TipoMontura.Ecuatorial,
                    new VOUnidadKg(20),
                    true));



            // CAMARAS

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("ZWO"),
                    new VOModelo("ASI120MC"),
                    new VOCantidadDisponible(5),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("1280x960"),
                    new VOTamanioPixelMicras(4)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("ZWO"),
                    new VOModelo("ASI224MC"),
                    new VOCantidadDisponible(4),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("1304x976"),
                    new VOTamanioPixelMicras(4)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("ZWO"),
                    new VOModelo("ASI533MC Pro"),
                    new VOCantidadDisponible(3),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("3008x3008"),
                    new VOTamanioPixelMicras(4)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("ZWO"),
                    new VOModelo("ASI294MC Pro"),
                    new VOCantidadDisponible(2),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("4144x2822"),
                    new VOTamanioPixelMicras(5)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("ZWO"),
                    new VOModelo("ASI2600MC Pro"),
                    new VOCantidadDisponible(2),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("6248x4176"),
                    new VOTamanioPixelMicras(4)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("QHY"),
                    new VOModelo("QHY183C"),
                    new VOCantidadDisponible(2),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("5496x3672"),
                    new VOTamanioPixelMicras(2)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("QHY"),
                    new VOModelo("QHY268C"),
                    new VOCantidadDisponible(2),
                    CamaraTipoSensor.CMOS,
                    new VOResolucion("6280x4210"),
                    new VOTamanioPixelMicras(4)));

            _context.Equipos.Add(
                new EquipoCamara(
                    new VOMarca("Atik"),
                    new VOModelo("383L Plus"),
                    new VOCantidadDisponible(1),
                    CamaraTipoSensor.CCD,
                    new VOResolucion("3362x2504"),
                    new VOTamanioPixelMicras(5)));



            // OCULARES

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Celestron"),
                    new VOModelo("X-Cel LX 25mm"),
                    new VOCantidadDisponible(8),
                    new VOUnidadMM(25),
                    new VOAnguloVisionGrado(60)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Celestron"),
                    new VOModelo("X-Cel LX 12mm"),
                    new VOCantidadDisponible(8),
                    new VOUnidadMM(12),
                    new VOAnguloVisionGrado(60)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Baader"),
                    new VOModelo("Hyperion 17mm"),
                    new VOCantidadDisponible(5),
                    new VOUnidadMM(17),
                    new VOAnguloVisionGrado(68)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Baader"),
                    new VOModelo("Hyperion 24mm"),
                    new VOCantidadDisponible(5),
                    new VOUnidadMM(24),
                    new VOAnguloVisionGrado(68)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Tele Vue"),
                    new VOModelo("Plossl 32mm"),
                    new VOCantidadDisponible(4),
                    new VOUnidadMM(32),
                    new VOAnguloVisionGrado(50)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Tele Vue"),
                    new VOModelo("Nagler 13mm"),
                    new VOCantidadDisponible(3),
                    new VOUnidadMM(13),
                    new VOAnguloVisionGrado(82)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Explore Scientific"),
                    new VOModelo("24mm 68"),
                    new VOCantidadDisponible(4),
                    new VOUnidadMM(24),
                    new VOAnguloVisionGrado(68)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Explore Scientific"),
                    new VOModelo("14mm 82"),
                    new VOCantidadDisponible(4),
                    new VOUnidadMM(14),
                    new VOAnguloVisionGrado(82)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Orion"),
                    new VOModelo("Sirius Plossl 25mm"),
                    new VOCantidadDisponible(6),
                    new VOUnidadMM(25),
                    new VOAnguloVisionGrado(52)));

            _context.Equipos.Add(
                new EquipoOcular(
                    new VOMarca("Sky-Watcher"),
                    new VOModelo("Super Plossl 10mm"),
                    new VOCantidadDisponible(6),
                    new VOUnidadMM(10),
                    new VOAnguloVisionGrado(52)));

            _context.SaveChanges();
        }

        private void CrearObjetosCelestes()
        {
            // PLANETAS

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Luna"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(-12.74m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Mercurio"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(-2.48m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Venus"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(-4.89m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Marte"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(-2.94m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Jupiter"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(-2.94m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Saturno"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(0.46m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Urano"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(5.38m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Neptuno"),
                    TipoObjetoCeleste.Planeta,
                    new VOMagnitudAparente(7.78m)));



            // ESTRELLAS

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Polaris"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(1.98m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Sirius"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(-1.46m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Betelgeuse"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(0.42m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Rigel"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(0.13m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Vega"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(0.03m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Altair"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(0.77m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Deneb"),
                    TipoObjetoCeleste.Estrella,
                    new VOMagnitudAparente(1.25m)));



            // NEBULOSAS

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Nebulosa de Orion"),
                    TipoObjetoCeleste.Nebulosa,
                    new VOMagnitudAparente(4.00m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Nebulosa Laguna"),
                    TipoObjetoCeleste.Nebulosa,
                    new VOMagnitudAparente(6.00m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Nebulosa Trifida"),
                    TipoObjetoCeleste.Nebulosa,
                    new VOMagnitudAparente(6.30m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Nebulosa Roseta"),
                    TipoObjetoCeleste.Nebulosa,
                    new VOMagnitudAparente(9.00m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Nebulosa Helix"),
                    TipoObjetoCeleste.Nebulosa,
                    new VOMagnitudAparente(7.30m)));



            // GALAXIAS

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Andromeda"),
                    TipoObjetoCeleste.Galaxia,
                    new VOMagnitudAparente(3.44m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Galaxia del Triangulo"),
                    TipoObjetoCeleste.Galaxia,
                    new VOMagnitudAparente(5.72m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Galaxia Bode"),
                    TipoObjetoCeleste.Galaxia,
                    new VOMagnitudAparente(6.94m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Galaxia del Cigarro"),
                    TipoObjetoCeleste.Galaxia,
                    new VOMagnitudAparente(8.41m)));

            _context.ObjetosCelestes.Add(
                new ObjetoCeleste(
                    new VONombre("Remolino"),
                    TipoObjetoCeleste.Galaxia,
                    new VOMagnitudAparente(8.40m)));

            _context.SaveChanges();
        }

        private void CrearPrestamos()
        {
            Socio socio1 = _context.Usuarios.OfType<Socio>().ElementAt(0);
            Socio socio2 = _context.Usuarios.OfType<Socio>().ElementAt(1);
            Socio socio3 = _context.Usuarios.OfType<Socio>().ElementAt(2);
            Socio socio4 = _context.Usuarios.OfType<Socio>().ElementAt(3);
            Socio socio5 = _context.Usuarios.OfType<Socio>().ElementAt(4);

            Coordinador coord1 = _context.Usuarios.OfType<Coordinador>().ElementAt(0);
            Coordinador coord2 = _context.Usuarios.OfType<Coordinador>().ElementAt(1);
            Coordinador coord3 = _context.Usuarios.OfType<Coordinador>().ElementAt(2);

            EquipoTelescopio tel1 = _context.Equipos.OfType<EquipoTelescopio>().First(x => x.Modelo.Value == "Explorer 150P");
            EquipoTelescopio tel2 = _context.Equipos.OfType<EquipoTelescopio>().First(x => x.Modelo.Value == "Explorer 200P");
            EquipoTelescopio tel3 = _context.Equipos.OfType<EquipoTelescopio>().First(x => x.Modelo.Value == "Evostar 80ED");

            EquipoMontura mon1 = _context.Equipos.OfType<EquipoMontura>().First(x => x.Modelo.Value == "EQ5");
            EquipoMontura mon2 = _context.Equipos.OfType<EquipoMontura>().First(x => x.Modelo.Value == "HEQ5 Pro");
            EquipoMontura mon3 = _context.Equipos.OfType<EquipoMontura>().First(x => x.Modelo.Value == "EQ6-R Pro");

            EquipoOcular ocu1 = _context.Equipos.OfType<EquipoOcular>().First(x => x.Modelo.Value == "X-Cel LX 25mm");
            EquipoOcular ocu2 = _context.Equipos.OfType<EquipoOcular>().First(x => x.Modelo.Value == "Hyperion 17mm");

            EquipoCamara cam1 = _context.Equipos.OfType<EquipoCamara>().First(x => x.Modelo.Value == "ASI120MC");
            EquipoCamara cam2 = _context.Equipos.OfType<EquipoCamara>().First(x => x.Modelo.Value == "ASI533MC Pro");

            Prestamo p1 = new Prestamo(socio1, tel1, mon1, null, ocu1,
                DateTime.Today.AddDays(-20), DateTime.Today.AddDays(-10));
            p1.Devolver();

            Prestamo p2 = new Prestamo(socio2, tel2, mon2, null, ocu2,
                DateTime.Today.AddDays(-15), DateTime.Today.AddDays(-5));
            p2.Devolver();

            Prestamo p3 = new Prestamo(socio3, tel3, mon2, cam1, null,
                DateTime.Today.AddDays(-10), DateTime.Today.AddDays(5));

            Prestamo p4 = new Prestamo(socio4, tel1, mon1, null, ocu1,
                DateTime.Today.AddDays(-8), DateTime.Today.AddDays(7));

            Prestamo p5 = new Prestamo(socio5, tel2, mon3, cam2, null,
                DateTime.Today.AddDays(-6), DateTime.Today.AddDays(8));

            Prestamo p6 = new Prestamo(socio1, tel3, mon2, cam1, null,
                DateTime.Today.AddDays(-4), DateTime.Today.AddDays(10));

            Prestamo p7 = new Prestamo(socio2, tel1, mon1, null, ocu2,
                DateTime.Today.AddDays(-3), DateTime.Today.AddDays(12));

            Prestamo p8 = new Prestamo(socio3, tel2, mon3, cam2, null,
                DateTime.Today.AddDays(-2), DateTime.Today.AddDays(15));

            _context.Prestamos.Add(p1);
            _context.Prestamos.Add(p2);
            _context.Prestamos.Add(p3);
            _context.Prestamos.Add(p4);
            _context.Prestamos.Add(p5);
            _context.Prestamos.Add(p6);
            _context.Prestamos.Add(p7);
            _context.Prestamos.Add(p8);

            _context.SaveChanges();

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p1, coord1, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p1, coord1, TipoAccionAuditoria.Devolucion));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p2, coord2, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p2, coord2, TipoAccionAuditoria.Devolucion));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p3, coord3, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p4, coord1, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p5, coord2, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p6, coord3, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p7, coord1, TipoAccionAuditoria.Prestamo));

            _context.AuditoriasPrestamo.Add(
                new AuditoriaPrestamo(p8, coord2, TipoAccionAuditoria.Prestamo));

            _context.SaveChanges();
        }

        private void CrearObservaciones()
        {
            Socio socio1 = _context.Usuarios.OfType<Socio>().ElementAt(0);
            Socio socio2 = _context.Usuarios.OfType<Socio>().ElementAt(1);
            Socio socio3 = _context.Usuarios.OfType<Socio>().ElementAt(2);
            Socio socio4 = _context.Usuarios.OfType<Socio>().ElementAt(3);
            Socio socio5 = _context.Usuarios.OfType<Socio>().ElementAt(4);

            Prestamo p1 = _context.Prestamos.ElementAt(0);
            Prestamo p2 = _context.Prestamos.ElementAt(1);
            Prestamo p3 = _context.Prestamos.ElementAt(2);
            Prestamo p4 = _context.Prestamos.ElementAt(3);
            Prestamo p5 = _context.Prestamos.ElementAt(4);

            ObjetoCeleste luna =
                _context.ObjetosCelestes.First(o => o.Nombre.Value == "Luna");

            ObjetoCeleste jupiter =
                _context.ObjetosCelestes.First(o => o.Nombre.Value == "Jupiter");

            ObjetoCeleste polaris =
                _context.ObjetosCelestes.First(o => o.Nombre.Value == "Polaris");

            ObjetoCeleste nebulosaOrion =
                _context.ObjetosCelestes.First(o => o.Nombre.Value == "Nebulosa de Orion");

            ObjetoCeleste andromeda =
                _context.ObjetosCelestes.First(o => o.Nombre.Value == "Andromeda");

            Observacion o1 = new Observacion(
                socio1,
                p1,
                DateTime.Today.AddDays(-18),
                luna);

            o1.RegistrarResultadoIA(
                ResultadoObservacion.IDEAL,
                "Excelente combinación para observación lunar.");

            Observacion o2 = new Observacion(
                socio2,
                p2,
                DateTime.Today.AddDays(-13),
                jupiter);

            o2.RegistrarResultadoIA(
                ResultadoObservacion.IDEAL,
                "Configuración adecuada para observar detalles planetarios.");

            Observacion o3 = new Observacion(
                socio3,
                p3,
                DateTime.Today.AddDays(-3),
                polaris);

            o3.RegistrarResultadoIA(
                ResultadoObservacion.ADECUADO,
                "Observación posible aunque existen configuraciones más apropiadas.");

            Observacion o4 = new Observacion(
                socio4,
                p4,
                DateTime.Today.AddDays(-6),
                nebulosaOrion);

            o4.RegistrarResultadoIA(
                ResultadoObservacion.ADECUADO,
                "La nebulosa puede observarse correctamente con este equipo.");

            Observacion o5 = new Observacion(
                socio5,
                p5,
                DateTime.Today.AddDays(-2),
                andromeda);

            o5.RegistrarResultadoIA(
                ResultadoObservacion.NO_RECOMENDABLE,
                "La distancia focal y resolución disponibles limitan significativamente la captura de detalles de la galaxia.");

            _context.Observaciones.Add(o1);
            _context.Observaciones.Add(o2);
            _context.Observaciones.Add(o3);
            _context.Observaciones.Add(o4);
            _context.Observaciones.Add(o5);

            _context.SaveChanges();
        }

    }
}