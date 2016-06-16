function addMarkers(id, map, koordinate) {
    console.log("pozvana sam");
	overlay = new CustomMarker(
		koordinate, 
		map,
		{
			marker_id: id
		}
     );
}

function writeToDatabase(sirina,duzina, opis) {
    var koordinate = {};
    koordinate.Sirina = sirina;
    koordinate.Duzina = duzina;
    koordinate.Opis = opis;
    $.ajax({
        type: "POST",
        url: "Default.aspx/SpremiKoordinate",
        data: '{koordinate: ' + JSON.stringify(koordinate) + '}', // funkcija SpremiKoordinate iz .cs prima koordinate
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            $("#spremljenoInfo").show().delay(3000).fadeOut();
        }
    });
    return false;
}

