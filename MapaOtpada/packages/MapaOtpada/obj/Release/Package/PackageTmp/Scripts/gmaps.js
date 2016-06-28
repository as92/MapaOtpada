function addMarkers(id, map, koordinate) {
	overlay = new CustomMarker(
		koordinate, 
		map,
		{
			marker_id: id
		}
     );
}

function showSpremi(sirina,duzina) {
    $('#ContentPlaceHolder1_sirina').val(sirina);
    $('#ContentPlaceHolder1_duzina').val(duzina);
    $('#ContentPlaceHolder1_opis').attr('required','required');
    $('#ContentPlaceHolder1_fileUpload').attr('required','required');
    $('#spremiModal').modal('show');
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


var querystr = getParameterByName('spremi');
console.log(querystr);
if (querystr == "ok") {
    $('#spremljenoInfo').show().delay(3000).fadeOut();
}
//function writeToDatabase(sirina,duzina, opis, slika) {
//    var koordinate = {};
//    koordinate.Sirina = sirina;
//    koordinate.Duzina = duzina;
//    koordinate.Opis = opis;
//    koordinate.Slika = "Images/"+slika;
//    $.ajax({
//        type: "POST",
//        url: "Default.aspx/SpremiKoordinate",
//        data: '{koordinate: ' + JSON.stringify(koordinate) + '}', // funkcija SpremiKoordinate iz .cs prima koordinate
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//        }
//    });
//    return false;
//}

//$('#formSpremi').submit(function (e) {
//    e.preventDefault();
//    var sirina = $('#sirina').val();
//    var duzina = $('#duzina').val();
//    var opis = $('#opis').val();
//    var slika = $('input[type=file]').val().replace(/C:\\fakepath\\/i, '');
//    writeToDatabase(sirina, duzina, opis, slika);
//});






