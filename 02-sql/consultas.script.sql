USE LemonMusic

/* Listar las pistas (tabla Track) con precio mayor o igual a 1€ */
SELECT TrackId,Name, Composer, UnitPrice
FROM Track
WHERE UnitPrice>=1;

/* Listar las pistas de más de 4 minutos de duración */
SELECT TrackId, Name, Composer, UnitPrice, ((Milliseconds/1000)/60) AS Minutes 
FROM Track
WHERE ((Milliseconds/1000)/60) > 4
 
/* Listar las pistas que tengan entre 2 y 3 minutos de duración */
SELECT TrackId, Name, Composer, UnitPrice, ((Milliseconds/1000)/60) AS Minutes 
FROM Track
WHERE ((Milliseconds/1000)/60) >= 2 AND ((Milliseconds/1000)/60) <= 3

/* Listar las pistas que uno de sus compositores (columna Composer) sea Mercury */
SELECT TrackId, Name, Composer, UnitPrice, ((Milliseconds/1000)/60) AS Minutes 
FROM Track
WHERE Composer Like '%Mercury%';

/*Calcular la media de duración de las pistas (Track) de la plataforma */
SELECT AVG((Milliseconds/1000)/60) AS AverageMinutes 
FROM Track

/* Listar los clientes (tabla Customer) de USA, Canada y Brazil */
Select FirstName + ' '+ LastName As Name,City, State, Country   FROM Customer
WHERE Country IN('USA', 'Canada',  'Brazil')

/* Listar todas las pistas del artista 'Queen' (Artist.Name = 'Queen') */
SELECT a.TrackId, a.Name, a.Composer, a.UnitPrice,b.Name AS ArtistName 
FROM Track a 
INNER JOIN Artist b ON a.Composer = b.Name 
AND b.Name = 'Queen'

/* Listar las pistas del artista 'Queen' en las que haya participado como compositor David Bowie */
SELECT a.TrackId, a.Name, a.Composer, a.UnitPrice,b.Name AS ArtistName 
FROM Track a 
INNER JOIN Artist b ON a.Composer = b.Name 
AND b.Name = 'Queen'
AND a.Composer LIKE '%David Bowie%'

/* Listar las pistas de la playlist 'Heavy Metal Classic' */
SELECT a.TrackId, a.Name,a.Composer, c.Name as PlayListName
FROM Track a 
INNER JOIN PlaylistTrack b 
ON a.TrackId = b.TrackId
INNER JOIN Playlist c
ON b.PlaylistId = c.PlaylistId
WHERE c.Name = 'Heavy Metal Classic'

/* Listar las playlist junto con el número de pistas que contienen */
SELECT a.PlaylistId, a.Name, (Select Count(*) From PlaylistTrack WHERE PlaylistId = a.PlaylistId) as TracksNumber 
FROM Playlist a 

/* Listar las playlist (sin repetir ninguna) que tienen alguna canción de AC/DC */
SELECT DISTINCT a.PlaylistId, a.Name, e.Name
FROM Playlist a 
INNER JOIN 
PlaylistTrack b
ON a.PlaylistId = b.PlaylistId 
INNER JOIN Track c
ON b.TrackId = c.TrackId
INNER JOIN Album d
ON c.AlbumId = d.AlbumId
INNER JOIN Artist e
ON d.ArtistId= e.ArtistId
WHERE e.Name = 'AC/DC'

/* Listar las playlist que tienen alguna canción del artista Queen, junto con la cantidad que tienen */
SELECT DISTINCT a.PlaylistId, a.Name, e.Name as Artist, 
(SELECT COUNT(*) FROM PlaylistTrack z
	INNER JOIN Track c
	ON z.TrackId = c.TrackId
	INNER JOIN Album d
	ON c.AlbumId = d.AlbumId
	INNER JOIN Artist e
	ON d.ArtistId= e.ArtistId
	WHERE e.Name = 'Queen'
	AND a.PlaylistId = z.PlaylistId) AS TotalQueenTracks
FROM Playlist a 
INNER JOIN 
PlaylistTrack b
ON a.PlaylistId = b.PlaylistId 
INNER JOIN Track c
ON b.TrackId = c.TrackId
INNER JOIN Album d
ON c.AlbumId = d.AlbumId
INNER JOIN Artist e
ON d.ArtistId= e.ArtistId
WHERE e.Name = 'Queen'

/* Listar las pistas que no están en ninguna playlist */
SELECT a.TrackId, a.Name  
FROM Track a
WHERE a.TrackId NOT IN (SELECT TrackId from PlaylistTrack)

/* Listar los artistas que no tienen album */
SELECT a.ArtistId, a.Name  
FROM Artist a
WHERE a.ArtistId NOT IN (SELECT ArtistId from Album)
ORDER BY a.Name

/* Listar los artistas con el número de albums que tienen */
SELECT a.ArtistId, a.Name ,COUNT(b.ArtistId) AS AlbumsNumber  
FROM Artist a
LEFT JOIN
Album b ON a.ArtistId = b.ArtistId
GROUP BY a.Name, a.ArtistId
ORDER BY a.Name
