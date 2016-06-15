function initialize() {
 var myLatlng = new google.maps.LatLng(43.511390686035156, 16.475044250488281);
 var mapOptions = {
  zoom: 14,
  center: myLatlng,
  mapTypeControl: true,
  scaleControl: true,
  mapTypeControlOptions: {
    style: google.maps.MapTypeControlStyle.DROPDOWN_MENU
},
navigationControl: true,
navigationControlOptions: {
    style: google.maps.NavigationControlStyle.DEFAULT
},
mapTypeId: google.maps.MapTypeId.ROADMAP,
backgroundColor: 'white'
}




var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
map.addListener('dblclick', function(e) {
          // 3 seconds after the center of the map has changed, pan back to the
          // marker.
          //alert(e.latLng);
          writeToDatabase(e.latLng.lng(), e.latLng.lat(), "Kakav opis makni se");
		  //console.log("Širina: "+e.latLng.lat()+" i Dužina: "+e.latLng.lng());
		  id = e.latLng.lat()+e.latLng.lng()
		  addMarkers(id, map, e.latLng);    
   });
}


function addMarkers(id,map,koordinate){	
	//koordinate = new google.maps.LatLng(sirina, duljina)
	overlay = new CustomMarker(
		koordinate, 
		map,
		{
			marker_id: id
		}
     );
}

function writeToDatabase(duzina, sirina, opis) {
    var koordinate = {};
    koordinate.Duzina = sirina;
    koordinate.Sirina = duzina;
    koordinate.Opis = opis;
    $.ajax({
        type: "POST",
        url: "Default.aspx/SpremiKoordinate",
        data: '{koordinate: ' + JSON.stringify(koordinate) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            $("#spremljenoInfo").show().delay(3000).fadeOut();
            //window.location.reload();
        }
    });
    return false;
}

google.maps.event.addDomListener(window, 'load', initialize);
