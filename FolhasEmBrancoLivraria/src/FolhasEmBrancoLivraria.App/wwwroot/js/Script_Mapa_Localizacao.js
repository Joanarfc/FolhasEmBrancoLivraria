var latitude = -15.801703768032851;
var longitude = -47.926140964530234;

map = L.map('mapDiv').setView([latitude, longitude], 13);

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: 'Map data &copy; <a href="https://www.folhasembranco.com/">folhasembranco.com</a>',
    maxZoom: 18,
}).addTo(map);

// adiciona um marcador no mapa
marker = L.marker([latitude, longitude]).addTo(map);

// adiciona um popup no marcador
marker.bindPopup("<b>St. Sudoeste Comércio Local Sudoeste 103</b><br />- Cruzeiro / Sudoeste / Octogonal, Brasília - DF<br />, 70670-520").openPopup();
