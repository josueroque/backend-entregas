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
  <tr>
    <td>No</td>
    <td>Nombre</td>
    <td>Varchar</td>
    <td>Nombre del curso</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>FechaPublicacion</td>
    <td>Datetime</td>
    <td>Fecha de publicacion del curso</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>AreaId</td>
    <td>Integer</td>
    <td>Codigo del area a la que pertenece el curso</td>
    <td>Si</td>
    <td>Area</td>
  </tr>
    <tr>
    <td>No</td>
    <td>Publico</td>
    <td>Boolean</td>
    <td>Determina si el curso es de acceso privado o publico</td>
    <td>No</td>
    <td></td>
  </tr>
  
</table>

### Tabla: CursoVideo
Descripcion: Tabla intermedia que sirve para representar la relacion muchos a muchos entre las tablas Curso y Video. Se modelo de esta forma porque se considera que un curso puede estar compuesto de varios videos, a su vez un video puede formar parte de varios cursos. Ejemplo: Video sobre el tema "Currificacion en Javascript" podria aparecer en un curso de Javascript como en uno de React.  

<table>
  <thead>
    <td>Llave Primaria</td>
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
    <td>Si</td>
    <td>Curso</td>
  </tr>
  <tr>
    <td>Si</td>
    <td>VideoId</td>
    <td>Integer</td>
    <td>Identificador del video</td>
    <td>Si</td>
    <td>Video</td>
  </tr>
</table>

### Tabla: CursoArticulo
Descripcion: Tabla intermedia que sirve para representar la relacion muchos a muchos entre las tablas Curso y Articulo. Se modelo de esta forma porque se considera que un curso puede estar compuesto de varios articulos, a su vez un articulo puede formar parte de varios cursos. 
<table>
  <thead>
    <td>Llave Primaria</td>
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
    <td>Si</td>
    <td>Curso</td>
  </tr>
  <tr>
    <td>Si</td>
    <td>ArticuloId</td>
    <td>Integer</td>
    <td>Identificador del articulo</td>
    <td>Si</td>
    <td>Articulo</td>
  </tr>
</table>

### Tabla: Video
Descripcion: Tabla que almacenara todos los videos que componen los diferentes cursos. Como se puede apreciar en el diagrama un video podria pertenecer a uno o mas cursos.  
<table>
  <thead>
    <td>Llave Primaria</td>
    <td>Nombre Campo</td>
    <td>Tipo Dato</td>
    <td>Descripcion</td>
    <td>Llave Foranea</td>
    <td>Tabla Relacionada</td>
  </thead>
  <tr>
    <td>Si</td>
    <td>VideoId</td>
    <td>Integer</td>
    <td>Identificador del video</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>Nombre</td>
    <td>Varchar</td>
    <td>Nombre del video</td>
    <td>No</td>
    <td></td>
  </tr>
    <tr>
    <td>No</td>
    <td>Descipcion</td>
    <td>Varchar</td>
    <td>Descripcion del video</td>
    <td>No</td>
    <td></td>
  </tr>
</table>

### Tabla: Articulo
Descripcion: Tabla que almacenara todos los articulos que componen los diferentes cursos. Como se puede apreciar en el diagrama un articulos podria pertenecer a uno o mas cursos.  
<table>
  <thead>
    <td>Llave Primaria</td>
    <td>Nombre Campo</td>
    <td>Tipo Dato</td>
    <td>Descripcion</td>
    <td>Llave Foranea</td>
    <td>Tabla Relacionada</td>
  </thead>
  <tr>
    <td>Si</td>
    <td>ArticuloId</td>
    <td>Integer</td>
    <td>Identificador del articulo</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>Nombre</td>
    <td>Varchar</td>
    <td>Nombre del articulo</td>
    <td>No</td>
    <td></td>
  </tr>
    <tr>
    <td>No</td>
    <td>Descipcion</td>
    <td>Varchar</td>
    <td>Descripcion del articulo</td>
    <td>No</td>
    <td></td>
  </tr>
</table>

### Tabla: Usuario
Descripcion: Tabla que almacenara todos los usuarios registrados en la plataforma.  
<table>
  <thead>
    <td>Llave Primaria</td>
    <td>Nombre Campo</td>
    <td>Tipo Dato</td>
    <td>Descripcion</td>
    <td>Llave Foranea</td>
    <td>Tabla Relacionada</td>
  </thead>
  <tr>
    <td>Si</td>
    <td>UsuarioId</td>
    <td>Integer</td>
    <td>Identificador del usuario</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>Nombre</td>
    <td>Varchar</td>
    <td>Nombre del usuario</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>Email</td>
    <td>Varchar</td>
    <td>Direccion de correo electronico</td>
    <td>No</td>
    <td></td>
  </tr>
  <tr>
    <td>No</td>
    <td>Activo</td>
    <td>Boolean</td>
    <td>Determina si el usuario esta activo</td>
    <td>No</td>
    <td></td>
  </tr>
</table>
