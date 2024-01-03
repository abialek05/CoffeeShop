function initMap() {
    new google.maps.Map(document.getElementById("map"), {
        mapId: "87f24803f9621220",
        center: { lat: 48.85, lng: 2.35 },
        zoom: 12,
    });
}

window.initMap = initMap;