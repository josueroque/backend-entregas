Use LemonMusic

/* Listar las pistas ordenadas por el número de veces que aparecen en playlists de forma descendente */
SELECT a.TrackId, a.Name, COUNT(a.TrackId) AS TotalPlaylists
FROM Track a
INNER JOIN
PlaylistTrack b
ON a.TrackId = b.TrackId
GROUP BY a.TrackId, A.Name
ORDER BY TotalPlaylists DESC

/*Listar las pistas más compradas (la tabla InvoiceLine tiene los registros de compras) */
Select TOP 5 a.TrackId, a.Name, SUM(b.Quantity) as SalesNumber 
FROM Track a
INNER JOIN
InvoiceLine b
ON a.TrackId = b.TrackId
GROUP BY a.TrackId, a.Name
ORDER BY SalesNumber DESC

/* Listar los artistas más comprados */
Select TOP 5 a.ArtistId, a.Name, SUM(d.Quantity) as SalesNumber 
FROM Artist a
INNER JOIN
Album b
ON b.ArtistId= a.ArtistId
INNER JOIN Track c
ON c.AlbumId = b.AlbumId
INNER JOIN 
InvoiceLine d
ON d.TrackId = c.TrackId
GROUP BY a.ArtistId, a.Name
ORDER BY SalesNumber DESC

/* Listar las pistas que aún no han sido compradas por nadie */
SELECT a.TrackId, a.Name 
FROM Track a
WHERE TrackId NOT IN (SELECT TrackId FROM InvoiceLine)

/* Listar los artistas que aún no han vendido ninguna pista */
Select a.ArtistId, a.Name, COUNT(d.Quantity) as SalesNumber 
FROM Artist a
INNER JOIN
Album b
ON b.ArtistId= a.ArtistId
INNER JOIN Track c
ON c.AlbumId = b.AlbumId
LEFT JOIN 
InvoiceLine d
ON d.TrackId = c.TrackId
GROUP BY a.ArtistId, a.Name
HAVING COUNT(d.Quantity) = 0