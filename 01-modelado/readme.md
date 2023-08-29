# Modelado Base de Datos Sistema de Cursos Online

## Diagrama Entidad Relacion

<img src="/01-modelado/images/diagram.png" alt="MarineGEO circle logo"/>

## Diccionario de Datos
### Tabla: Curso
Descripcion: En esta tabla se almacenaran todos los cursos disponibles en la plataforma. Estara relacionada con la tabla Area por medio del campo AreaId, lo que determinara la categoria a la que pertenece el curso. El campo FechaPublicacion permitira cumplir con el requerimiento de poder consultar y mostrar los cursos en base a su fecha de publicacion.

<table>
  <thead>
    <td>Llave Primaria </td>
    <td>Nombre Campo</td>
    <td>Tipo Dato</td>
    <td>Descripcion</td>
    <td>Llave Foranea</td>
    <td>Tabla Relacionada</td>
  </thead>
  <tr>
    <td>Si</td>
    <td>CursoId</td>
    <td>Integer</td>
    <td>Identificador del curso</td>
    <td>No</td>
    <td></td>
  </tr>
</table>
