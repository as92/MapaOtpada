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
        success: function (response) {
            $('#spremiModal').modal('hide');
            $("#spremljenoInfo").show().delay(3000).fadeOut();
        }
    });
    return false;
}
$('#formSpremi').submit(function (e) {
    e.preventDefault();
    var sirina = $('#sirina').val();
    var duzina = $('#duzina').val();
    var opis = $('#opis').val();
    writeToDatabase(sirina, duzina, opis);
});

