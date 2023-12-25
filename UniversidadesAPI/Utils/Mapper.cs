using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using UniversidadesAPI.ApiModels;
using UniversidadesAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UniversidadesAPI.Utils
{
    public static class Mapper
    {
        public static CarreraDTO MapToCarreraDTO(this Carrera carrera)
        {
            var carreraDTO = new CarreraDTO()
            {
                Id = carrera.Id,
                Nombre = carrera.Nombre,
                CargaHorarioSemanal = carrera.CargaHorarioSemanal,
                Direccion = carrera.Direccion,
                PlanDeEstudiosUrl = carrera.PlanDeEstudiosUrl,
                PorcentajeDesercion = carrera.PorcentajeDesercion,
                PrecioCuota = carrera.PrecioCuota,
                Publica = carrera.Publica,
                TiempoPromedioFinalizacion = carrera.TiempoPromedioFinalizacion,
            };

            if (carrera.EstadisticaEntidad != null)
            {
                carreraDTO.Estadisticas = new EstadisticasDTO()
                {
                    ExigenciaAcademica = carrera.EstadisticaEntidad.ExigenciaAcademica,
                    RelacionCalidadPrecio = carrera.EstadisticaEntidad.RelacionCalidadPrecio,
                    Politizacion = carrera.EstadisticaEntidad.Politizacion,
                    CalidadAdministrativa = carrera.EstadisticaEntidad.CalidadUniversidad,
                    DisponibilidadDeHorarios = carrera.EstadisticaEntidad.DisponibilidadDeHorarios,
                    CalidadDeProfesores = carrera.EstadisticaEntidad.CalidadDeProfesores,
                    DificultadIngreso = carrera.EstadisticaEntidad.DificultadIngreso,
                    BolsaDeTrabajo = carrera.EstadisticaEntidad.BolsaDeTrabajo,
                    SalidaLaboral = carrera.EstadisticaEntidad.SalidaLaboral,
                    Infraestructura = carrera.EstadisticaEntidad.Infraestructura,
                    SatisfaccionProfesion = carrera.EstadisticaEntidad.SatisfaccionProfesion,
                    CalidadUniversidad = carrera.EstadisticaEntidad.CalidadUniversidad
                };
            }

            return carreraDTO;
        }

        public static Carrera MapToCarrera(this CreateCarreraDTO carrera)
        {
            return new Carrera()
            {
                Nombre = carrera.Nombre,
                Publica = carrera.Publica,
                Direccion = carrera.Direccion,
                PlanDeEstudiosUrl = carrera.PlanDeEstudiosUrl,
                PrecioCuota = carrera.PrecioCuota,
                CargaHorarioSemanal = carrera.CargaHorarioSemanal,
                TiempoPromedioFinalizacion = carrera.TiempoPromedioFinalizacion,
                PorcentajeDesercion = carrera.PorcentajeDesercion,
                FacultadId = carrera.FacultadId
            };
        }

        public static FacultadDTO MapToFacultadDTO(this Facultad facultad)
        {
            var facultadDTO = new FacultadDTO()
            {
                Id = facultad.Id,
                Nombre = facultad.Nombre,
                Imagen = facultad.Imagen,
                Publica = facultad.Publica,
                Direccion = facultad.Direccion,
                PaginaWeb = facultad.PaginaWeb,
                UniversidadId = facultad.UniversidadId
            };

            if (facultad.Universidad != null)
            {
                facultadDTO.NombreUniversidad = facultad.Universidad.Nombre;
            }

            if (facultad.EstadisticaEntidad != null)
            {
                facultadDTO.Estadisticas = new EstadisticasDTO()
                {
                    ExigenciaAcademica = facultad.EstadisticaEntidad.ExigenciaAcademica,
                    RelacionCalidadPrecio = facultad.EstadisticaEntidad.RelacionCalidadPrecio,
                    Politizacion = facultad.EstadisticaEntidad.Politizacion,
                    CalidadAdministrativa = facultad.EstadisticaEntidad.CalidadUniversidad,
                    DisponibilidadDeHorarios = facultad.EstadisticaEntidad.DisponibilidadDeHorarios,
                    CalidadDeProfesores = facultad.EstadisticaEntidad.CalidadDeProfesores,
                    DificultadIngreso = facultad.EstadisticaEntidad.DificultadIngreso,
                    BolsaDeTrabajo = facultad.EstadisticaEntidad.BolsaDeTrabajo,
                    SalidaLaboral = facultad.EstadisticaEntidad.SalidaLaboral,
                    Infraestructura = facultad.EstadisticaEntidad.Infraestructura,
                    SatisfaccionProfesion = facultad.EstadisticaEntidad.SatisfaccionProfesion,
                    CalidadUniversidad = facultad.EstadisticaEntidad.CalidadUniversidad
                };
            }

            return facultadDTO;
        }
    }
}
