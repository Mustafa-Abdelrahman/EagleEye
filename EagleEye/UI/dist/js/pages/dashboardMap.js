var mymap = L.map('mapView').setView([30.033333,31.233334], 13);
L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibW9zdGFmYWFiZGVscmFobWFuIiwiYSI6ImNqd2h4a2FpMDBqeHc0Ym41bG9vc2Uyc20ifQ.hSU-ewch930GLP88NNC3Kg', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: 'your.mapbox.access.token'
}).addTo(mymap);